using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Étape 1 : Créer une liste de chaînes pour stocker les tâches
        List<string> taches = new List<string>();
        bool continuer = true;

        // Étape 2 : Boucle principale avec menu
        while (continuer)
        {
            // Étape 3 : Afficher le menu
            Console.WriteLine("Menu :");
            Console.WriteLine("1. Afficher les tâches");
            Console.WriteLine("2. Ajouter une tâche");
            Console.WriteLine("3. Supprimer une tâche");
            Console.WriteLine("4. Quitter");

            Console.Write("Choix : ");
            string choix = Console.ReadLine();

            // Étape 4 : Lire le choix et appeler la fonction correspondante
            switch (choix)
            {
                case "1":
                    AfficherTaches(taches);
                    break;
                case "2":
                    Console.Write("Entrez la nouvelle tâche : ");
                    string nouvelleTache = Console.ReadLine(); // Lire l’entrée utilisateur pour la nouvelle tâche
                    AjouterTache(taches, nouvelleTache); // Remplacer "Nouvelle tâche" par l’entrée utilisateur
                    break;
                case "3":
                    Console.Write("Entrez l’index de la tâche à supprimer : ");
                    // Lire l’entrée utilisateur pour l’index à supprimer
                    string input = Console.ReadLine();
                    if(int.TryParse(input, out int val))
                    {
                        SupprimerTache(taches, val); // Remplacer 0 par l’index entré par l’utilisateur
                    }
                    break;
                case "4":
                    // Quitter la boucle
                    continuer = false;
                    break;
                default:
                    // Gérer les choix invalides
                    Console.WriteLine("Choix invalide.");
                    break;
            }
        }
    }

    // Étape 5 : Fonction pour afficher toutes les tâches
    static void AfficherTaches(List<string> taches)
    {
        // Parcourir la liste et afficher chaque tâche avec son index
        if (taches.Count == 0)
        {
            Console.Clear();
            Console.WriteLine("Aucune tâche à afficher.");
            return;
        }
        // Afficher les tâches avec leurs index
        for (int i = 0; i < taches.Count; i++)
        {
            Console.WriteLine($"{i+1}: {taches[i]}");
        }
    }

    // Étape 6 : Fonction pour ajouter une tâche
    static void AjouterTache(List<string> taches, string nouvelleTache)
    {
        Console.Clear();
        // Ajouter la tâche à la liste
        taches.Add(nouvelleTache);
        Console.WriteLine("Tâche ajoutée.");
    }

    // Étape 7 : Fonction pour supprimer une tâche
    static void SupprimerTache(List<string> taches, int index)
    {
        Console.Clear();
        // Supprimer la tâche à l’index donné
        taches.RemoveAt(index-1);
        Console.WriteLine($"Taches: {index}");
    }
}