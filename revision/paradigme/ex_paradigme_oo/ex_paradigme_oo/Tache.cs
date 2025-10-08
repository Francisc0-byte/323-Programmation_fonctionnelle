using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex_paradigme_oo
{
    class Tache
    {
        // Étape 1 : Définir les propriétés Id, Description, EstTerminee
        public int Id { get; set; }
        public string Description { get; set; }
        public bool EstTerminee { get; set; }

        public Tache(int id, string description)
        {
            Id=id;
            Description=description;
            EstTerminee=false;
        }

        // Étape 2 : Méthode pour marquer la tâche comme terminée
        public void MarquerCommeTerminee()
        {
            // Modifier EstTerminee à true
            EstTerminee=true;
        }

        // Étape 3 : Méthode pour afficher les infos de la tâche
        public void Afficher()
        {
            // Afficher Id, Description, et état
            string statut = EstTerminee ? "Terminé" : "Pas terminé";
            Console.WriteLine($"{statut} Tâche {Id}: {Description}");
        }
    }
}
