using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace SwapiExplorer
{
    class Program
    {
        static async Task Main()
        {
            var films = await GetAsync<FilmResult>("films/");
            var people = await GetAsync<PersonResult>("people/");
            var planets = await GetAsync<PlanetResult>("planets/");
            var starships = await GetAsync<StarshipResult>("starships/");

            // 1. Film avec le titre le plus long
            var longestTitle = films.results.MaxBy(f => f.title.Length)?.title;
            Console.WriteLine($"🎬 Titre le plus long : {longestTitle}");

            // 2. Personnage le plus présent
            var mostSeenCharacter = films.results
                .SelectMany(f => f.characters)
                .GroupBy(c => c)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();

            var character = await GetAsync<Person>(ExtractQuery(mostSeenCharacter));
            Console.WriteLine($"🧍 Personnage le plus présent : {character.name}");

            // 3. Planète la plus peuplée
            var mostPopulated = planets.results
                .Where(p => long.TryParse(p.population, out _))
                .MaxBy(p => long.Parse(p.population));
            Console.WriteLine($"🌍 Planète la plus peuplée : {mostPopulated?.name} ({mostPopulated?.population})");

            // 4. Combien de X-Wing pour un Star Destroyer ?
            var xwing = starships.results.FirstOrDefault(s => s.name.Contains("X-wing", StringComparison.OrdinalIgnoreCase));
            var destroyer = starships.results.FirstOrDefault(s => s.name.Contains("Star Destroyer", StringComparison.OrdinalIgnoreCase));
            var xwingCost = long.TryParse(xwing?.cost_in_credits, out var xCost) ? xCost : 0;
            var destroyerCost = long.TryParse(destroyer?.cost_in_credits, out var dCost) ? dCost : 0;
            var count = xwingCost > 0 ? dCost / xwingCost : 0;
            Console.WriteLine($"🚀 On peut acheter {count} X-Wing avec un Star Destroyer");

            // 5. Obi-Wan peut-il piloter le Millennium Falcon ?
            var obiwan = people.results.FirstOrDefault(p => p.name == "Obi-Wan Kenobi");
            var falcon = starships.results.FirstOrDefault(s => s.name == "Millennium Falcon");
            var canPilot = falcon?.pilots.Contains(obiwan?.url) ?? false;
            Console.WriteLine($"🧭 Obi-Wan peut-il piloter le Falcon ? {(canPilot ? "Oui" : "Non")}");

            // 6. Vaisseau le plus rapide en vitesse lumière
            var fastest = starships.results
                .Where(s => double.TryParse(s.max_atmosphering_speed, out _) && double.TryParse(s.hyperdrive_rating, out _))
                .Select(s => new {
                    s.name,
                    vmax = double.Parse(s.max_atmosphering_speed) * double.Parse(s.hyperdrive_rating)
                })
                .MaxBy(s => s.vmax);
            Console.WriteLine($"⚡ Vaisseau le plus rapide : {fastest?.name} (vmax = {fastest?.vmax})");

            // 7. Combien de vaisseaux plus rapides que la moyenne atmosphérique ?
            var speeds = starships.results
                .Where(s => double.TryParse(s.max_atmosphering_speed, out _))
                .Select(s => double.Parse(s.max_atmosphering_speed))
                .ToList();
            var avgSpeed = speeds.Average();
            var fasterCount = speeds.Count(s => s > avgSpeed);
            Console.WriteLine($"📈 Vaisseaux plus rapides que la moyenne ({avgSpeed:F0}) : {fasterCount}");

            // 8. Budget total en CHF
            var totalCredits = starships.results
                .Where(s => long.TryParse(s.cost_in_credits, out _))
                .Sum(s => long.Parse(s.cost_in_credits));
            var totalCHF = totalCredits * 0.778;
            Console.WriteLine($"💰 Budget total de la flotte : {totalCHF:N0} CHF");

            // 9. Générer le CSV
            var csvLines = starships.results.Select(s =>
            {
                var filmTitles = s.films.Select(f => films.results.FirstOrDefault(film => f.EndsWith($"/{film.id}/"))?.title.ToLower().Replace(" ", "-"));
                var pilotPlanets = s.pilots.Select(p => people.results.FirstOrDefault(person => person.url == p)?.homeworld)
                                           .Distinct()
                                           .Select(hw => planets.results.FirstOrDefault(pl => pl.url == hw)?.name.ToLower().Replace(" ", "-"));
                return $"{s.name},{s.cost_in_credits},{s.length},{string.Join("-", filmTitles)},{string.Join("-", pilotPlanets)}";
            });

            await File.WriteAllLinesAsync("vaisseau.txt", csvLines);
            Console.WriteLine("📄 Fichier vaisseau.txt généré !");
        }

        static async Task<T> GetAsync<T>(string query)
        {
            using var client = new HttpClient();
            var json = await client.GetStringAsync("https://swapi.dev/api/" + query);
            return JsonSerializer.Deserialize<T>(json);
        }

        static string ExtractQuery(string url) => url.Replace("https://swapi.dev/api/", "");

        public record FilmResult(int count, List<Film> results);
        public record Film(string title, List<string> characters, string url)
        {
            public int id => int.Parse(url.Split('/').Last(x => !string.IsNullOrEmpty(x)));
        }

        public record PersonResult(int count, List<Person> results);
        public record Person(string name, string url, string homeworld);

        public record PlanetResult(int count, List<Planet> results);
        public record Planet(string name, string population, string url);

        public record StarshipResult(int count, List<Starship> results);
        public record Starship(string name, string cost_in_credits, string length, string max_atmosphering_speed, string hyperdrive_rating, List<string> pilots, List<string> films);
    }
}