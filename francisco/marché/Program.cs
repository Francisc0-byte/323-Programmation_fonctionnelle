using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using OfficeOpenXml;

class Programm
{
    static void Main()
    {
        //string path = @"C:\Users\pc96ihd\Documents\GitHub\323-Programmation_fonctionnelle\francisco\marché\donné\";
        ////string fileName = ;
        //string filepath = path + fileName;

        //fileName = Console.ReadLine();
        //if (!File.Exists(filepath))
        //{
        //    Console.WriteLine("fichier introuvable");
        //    //Console.ReadKey();
        //    return;
        //}
        //else
        //    Console.WriteLine("Fichier trouver");

        //Console.ReadKey();


        List<Product> products = new List<Product>();

        products.Add(new Product { Location = "1", Provider = "Bornand", Produit = "Pommes", Quantity = 20, Unit = "kg", Price = 6.90m });
        products.Add(new Product { Location = "1", Provider = "Bornand", Produit = "Poires", Quantity = 16, Unit = "kg", Price = 3.50m });
        products.Add(new Product { Location = "1", Provider = "Bornand", Produit = "Pastèques", Quantity = 14, Unit = "pièce", Price = 6.00m });
        products.Add(new Product { Location = "1", Provider = "Bornand", Produit = "Melons", Quantity = 5, Unit = "kg", Price = 7.00m });

        products.Add(new Product { Location = "2", Provider = "Dumont", Produit = "Noix", Quantity = 20, Unit = "sac", Price = 8.60m });
        products.Add(new Product { Location = "2", Provider = "Dumont", Produit = "Raisin", Quantity = 6, Unit = "kg", Price = 5.60m });
        products.Add(new Product { Location = "2", Provider = "Dumont", Produit = "Pruneaux", Quantity = 13, Unit = "kg", Price = 8.10m });
        products.Add(new Product { Location = "2", Provider = "Dumont", Produit = "Myrtilles", Quantity = 12, Unit = "kg", Price = 8.90m });
        products.Add(new Product { Location = "2", Provider = "Dumont", Produit = "Groseilles", Quantity = 12, Unit = "kg", Price = 5.20m });

        products.Add(new Product { Location = "3", Provider = "Vonlanthen", Produit = "Pêches", Quantity = 8, Unit = "kg", Price = 8.70m });
        products.Add(new Product { Location = "3", Provider = "Vonlanthen", Produit = "Haricots", Quantity = 6, Unit = "kg", Price = 6.90m });
        products.Add(new Product { Location = "3", Provider = "Vonlanthen", Produit = "Courges", Quantity = 18, Unit = "pièce", Price = 4.30m });
        products.Add(new Product { Location = "3", Provider = "Vonlanthen", Produit = "Tomates", Quantity = 12, Unit = "kg", Price = 9.40m });
        products.Add(new Product { Location = "3", Provider = "Vonlanthen", Produit = "Pommes", Quantity = 20, Unit = "kg", Price = 3.90m });

        products.Add(new Product { Location = "4", Provider = "Barizzi", Produit = "Poires", Quantity = 5, Unit = "kg", Price = 6.30m });
        products.Add(new Product { Location = "4", Provider = "Barizzi", Produit = "Pastèques", Quantity = 6, Unit = "pièce", Price = 2.50m });
        products.Add(new Product { Location = "4", Provider = "Barizzi", Produit = "Melons", Quantity = 14, Unit = "kg", Price = 4.20m });
        products.Add(new Product { Location = "4", Provider = "Barizzi", Produit = "Noix", Quantity = 20, Unit = "sac", Price = 7.50m });
        products.Add(new Product { Location = "4", Provider = "Barizzi", Produit = "Raisin", Quantity = 15, Unit = "kg", Price = 7.20m });

        products.Add(new Product { Location = "5", Provider = "Blanc", Produit = "Pruneaux", Quantity = 5, Unit = "kg", Price = 9.00m });
        products.Add(new Product { Location = "5", Provider = "Blanc", Produit = "Myrtilles", Quantity = 18, Unit = "kg", Price = 5.60m });
        products.Add(new Product { Location = "5", Provider = "Blanc", Produit = "Groseilles", Quantity = 10, Unit = "kg", Price = 2.10m });
        products.Add(new Product { Location = "5", Provider = "Blanc", Produit = "Pêches", Quantity = 20, Unit = "kg", Price = 6.40m });
        products.Add(new Product { Location = "5", Provider = "Blanc", Produit = "Haricots", Quantity = 9, Unit = "kg", Price = 2.90m });

        products.Add(new Product { Location = "6", Provider = "Repond", Produit = "Courges", Quantity = 12, Unit = "pièce", Price = 7.40m });
        products.Add(new Product { Location = "6", Provider = "Repond", Produit = "Tomates", Quantity = 12, Unit = "kg", Price = 4.20m });
        products.Add(new Product { Location = "6", Provider = "Repond", Produit = "Pommes", Quantity = 15, Unit = "kg", Price = 6.50m });
        products.Add(new Product { Location = "6", Provider = "Repond", Produit = "Poires", Quantity = 18, Unit = "kg", Price = 2.40m });
        products.Add(new Product { Location = "6", Provider = "Repond", Produit = "Pastèques", Quantity = 7, Unit = "pièce", Price = 5.70m });

        products.Add(new Product { Location = "7", Provider = "Mancini", Produit = "Pêches", Quantity = 10, Unit = "kg", Price = 2.90m });
        products.Add(new Product { Location = "7", Provider = "Mancini", Produit = "Haricots", Quantity = 11, Unit = "kg", Price = 6.70m });
        products.Add(new Product { Location = "7", Provider = "Mancini", Produit = "Courges", Quantity = 10, Unit = "pièce", Price = 6.40m });
        products.Add(new Product { Location = "7", Provider = "Mancini", Produit = "Tomates", Quantity = 13, Unit = "kg", Price = 1.50m });
        products.Add(new Product { Location = "7", Provider = "Mancini", Produit = "Pommes", Quantity = 14, Unit = "kg", Price = 7.00m });

        products.Add(new Product { Location = "8", Provider = "Favre", Produit = "Poires", Quantity = 5, Unit = "kg", Price = 8.40m });
        products.Add(new Product { Location = "8", Provider = "Favre", Produit = "Pastèques", Quantity = 5, Unit = "pièce", Price = 1.70m });
        products.Add(new Product { Location = "8", Provider = "Favre", Produit = "Haricots", Quantity = 5, Unit = "kg", Price = 3.00m });
        products.Add(new Product { Location = "8", Provider = "Favre", Produit = "Courges", Quantity = 17, Unit = "pièce", Price = 2.00m });
        products.Add(new Product { Location = "8", Provider = "Favre", Produit = "Tomates", Quantity = 9, Unit = "kg", Price = 5.20m });

        products.Add(new Product { Location = "9", Provider = "Bovay", Produit = "Pommes", Quantity = 13, Unit = "kg", Price = 7.70m });
        products.Add(new Product { Location = "9", Provider = "Bovay", Produit = "Poires", Quantity = 5, Unit = "kg", Price = 3.80m });
        products.Add(new Product { Location = "9", Provider = "Bovay", Produit = "Pastèques", Quantity = 20, Unit = "pièce", Price = 2.10m });
        products.Add(new Product { Location = "9", Provider = "Bovay", Produit = "Melons", Quantity = 20, Unit = "kg", Price = 6.40m });
        products.Add(new Product { Location = "9", Provider = "Bovay", Produit = "Noix", Quantity = 13, Unit = "sac", Price = 8.80m });

        products.Add(new Product { Location = "10", Provider = "Cherix", Produit = "Raisin", Quantity = 8, Unit = "kg", Price = 7.10m });
        products.Add(new Product { Location = "10", Provider = "Cherix", Produit = "Pruneaux", Quantity = 19, Unit = "kg", Price = 7.90m });
        products.Add(new Product { Location = "10", Provider = "Cherix", Produit = "Myrtilles", Quantity = 9, Unit = "kg", Price = 4.20m });
        products.Add(new Product { Location = "10", Provider = "Cherix", Produit = "Groseilles", Quantity = 10, Unit = "kg", Price = 4.40m });
        products.Add(new Product { Location = "10", Provider = "Cherix", Produit = "Pêches", Quantity = 9, Unit = "kg", Price = 4.40m });

        products.Add(new Product { Location = "11", Provider = "Beaud", Produit = "Haricots", Quantity = 19, Unit = "kg", Price = 8.40m });
        products.Add(new Product { Location = "11", Provider = "Beaud", Produit = "Courges", Quantity = 16, Unit = "pièce", Price = 8.70m });
        products.Add(new Product { Location = "11", Provider = "Beaud", Produit = "Tomates", Quantity = 18, Unit = "kg", Price = 5.30m });
        products.Add(new Product { Location = "11", Provider = "Beaud", Produit = "Pommes", Quantity = 8, Unit = "kg", Price = 7.30m });
        products.Add(new Product { Location = "11", Provider = "Beaud", Produit = "Poires", Quantity = 13, Unit = "kg", Price = 9.20m });

        products.Add(new Product { Location = "12", Provider = "Corbaz", Produit = "Pastèques", Quantity = 15, Unit = "pièce", Price = 7.40m });
        products.Add(new Product { Location = "12", Provider = "Corbaz", Produit = "Melons", Quantity = 12, Unit = "kg", Price = 1.60m });
        products.Add(new Product { Location = "12", Provider = "Corbaz", Produit = "Noix", Quantity = 11, Unit = "sac", Price = 7.50m });
        products.Add(new Product { Location = "12", Provider = "Corbaz", Produit = "Raisin", Quantity = 16, Unit = "kg", Price = 4.50m });
        products.Add(new Product { Location = "12", Provider = "Corbaz", Produit = "Pruneaux", Quantity = 20, Unit = "kg", Price = 3.30m });

        products.Add(new Product { Location = "13", Provider = "Amaudruz", Produit = "Myrtilles", Quantity = 18, Unit = "kg", Price = 5.70m });
        products.Add(new Product { Location = "13", Provider = "Amaudruz", Produit = "Groseilles", Quantity = 19, Unit = "kg", Price = 8.00m });
        products.Add(new Product { Location = "13", Provider = "Amaudruz", Produit = "Pêches", Quantity = 12, Unit = "kg", Price = 5.50m });
        products.Add(new Product { Location = "13", Provider = "Amaudruz", Produit = "Haricots", Quantity = 13, Unit = "kg", Price = 5.20m });
        products.Add(new Product { Location = "13", Provider = "Amaudruz", Produit = "Courges", Quantity = 7, Unit = "pièce", Price = 9.60m });

        products.Add(new Product { Location = "14", Provider = "Bühlmann", Produit = "Tomates", Quantity = 12, Unit = "kg", Price = 7.70m });
        products.Add(new Product { Location = "14", Provider = "Bühlmann", Produit = "Pommes", Quantity = 17, Unit = "kg", Price = 1.90m });
        products.Add(new Product { Location = "14", Provider = "Bühlmann", Produit = "Poires", Quantity = 7, Unit = "kg", Price = 3.00m });
        products.Add(new Product { Location = "14", Provider = "Bühlmann", Produit = "Pastèques", Quantity = 11, Unit = "pièce", Price = 6.90m });
        products.Add(new Product { Location = "14", Provider = "Bühlmann", Produit = "Melons", Quantity = 7, Unit = "kg", Price = 4.70m });

        products.Add(new Product { Location = "15", Provider = "Crizzi", Produit = "Noix", Quantity = 10, Unit = "sac", Price = 1.60m });
        products.Add(new Product { Location = "15", Provider = "Crizzi", Produit = "Raisin", Quantity = 17, Unit = "kg", Price = 7.80m });
        products.Add(new Product { Location = "15", Provider = "Crizzi", Produit = "Pruneaux", Quantity = 18, Unit = "kg", Price = 9.00m });
        products.Add(new Product { Location = "15", Provider = "Crizzi", Produit = "Myrtilles", Quantity = 12, Unit = "kg", Price = 3.00m });
        products.Add(new Product { Location = "15", Provider = "Crizzi", Produit = "Groseilles", Quantity = 12, Unit = "kg", Price = 3.50m });


        int Provider = 0;

        foreach ( Product product in products)
        {
            if (product.Produit.ToLower()== "pêches")
            {
                Provider++;
            }
        }
        Console.WriteLine($"Il y a {Provider} vendeur de pêches");
       
        int nombre = 0;
        Product bestSeller = null;
        foreach (Product product in products)
        {
            if (product.Produit.ToLower() == "pastèques")
            {
                if (product.Quantity > nombre)
                {
                    nombre = product.Quantity;
                    bestSeller = product;
                }
                Console.WriteLine($"Il y a {product.Provider} qui vend des pastèques et vend {product.Quantity} à l'emplacement {product.Location}");

            }
        }
        Console.WriteLine($"Le meilleur est {bestSeller.Provider} avec {bestSeller.Quantity}");
    }
    class Product
    {
        public string Location {  get; set; }

        public string Provider {  get; set; }
        public string Produit { get; set; }

        public int Quantity {  get; set; }
        public string Unit {get; set;}
        public decimal Price { get; set; }
    }
}