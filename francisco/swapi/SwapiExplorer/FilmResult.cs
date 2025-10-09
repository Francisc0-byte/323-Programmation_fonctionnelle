using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapi.SwapiExplorer
{
   
    // Classe représentant la structure globale de la réponse JSON des films
    internal class FilmResult
    {
        public int count { get; set; } // Nombre total de films
        public List<Film> results { get; set; } = new(); // Liste des films
    }

}
