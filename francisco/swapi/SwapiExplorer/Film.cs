using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapi.SwapiExplorer
{
    // Classe représentant un film individuel
    internal class Film
    {
        public string title { get; set; } = ""; // Titre du film
        public string opening_crawl { get; set; } = ""; // Texte d'intro
        public string director { get; set; } = ""; // Réalisateur
        public string producer { get; set; } = ""; // Producteur
        public string release_date { get; set; } = ""; // Date de sortie
        public List<string> characters { get; set; } // Liste des personnages

        public Film()
        {
            characters = new List<string>();

        }

        // Méthode d'affichage personnalisée (utile pour les extensions)
        public override string ToString()=> title;
 

    }
}
