using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex_paradigme_oo
{
    class GestionnaireDeTaches
    {
        // Étape 4 : Créer une liste de Tache et un compteur d’Id
        private List<Tache> taches = new List<Tache>();
        private int prochainId = 1;

        // Étape 5 : Ajouter une nouvelle tâche
        public void AjouterTache(string description)
        {
            // Créer une tâche avec Id unique et l’ajouter à la liste
            var tache = new Tache (prochainId++,description);
            taches.Add (tache);
            Console.WriteLine("Tache ajoutée");
        }

        // Étape 6 : Supprimer une tâche par son Id
        public void SupprimerTache(int id)
        {
            // Retirer la tâche correspondante de la liste
            var tache = taches.Find(t=>t.Id == id);
        }

        // Étape 7 : Afficher toutes les tâches
        public void AfficherToutes()
        {
            // Parcourir la liste et appeler Afficher() sur chaque tâche
        }

        // Étape 8 : Marquer une tâche comme terminée
        public void MarquerTacheCommeTerminee(int id)
        {
            // Rechercher la tâche et appeler MarquerCommeTerminee()
        }
    }
}
