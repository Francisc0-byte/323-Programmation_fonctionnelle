using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Linq;

class Program
{
    
    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product { Location = 1, Provider = "Bornand", ProductName = "Pommes", Quantity = 20,Unit = "kg", Price = 5.50f },
            new Product { Location = 1, Provider = "Bornand", ProductName = "Poires", Quantity = 16,Unit = "kg", Price = 5.50f },
            new Product { Location = 1, Provider = "Bornand", ProductName = "Pastèques", Quantity = 14,Unit = "pièce", Price = 5.50f },
            new Product { Location = 1, Provider = "Bornand", ProductName = "Melons", Quantity = 5,Unit = "kg", Price = 5.50f },
            new Product { Location = 2, Provider = "Dumont", ProductName = "Noix", Quantity = 20,Unit = "sac", Price = 5.50f },
            new Product { Location = 2, Provider = "Dumont", ProductName = "Raisin", Quantity = 6,Unit = "kg", Price = 5.50f },
            new Product { Location = 2, Provider = "Dumont", ProductName = "Pruneaux", Quantity = 13,Unit = "kg", Price = 5.50f },
            new Product { Location = 2, Provider = "Dumont", ProductName = "Myrtilles", Quantity = 12,Unit = "kg", Price = 5.50f },
            new Product { Location = 10, Provider = "Cherix", ProductName = "Myrtilles", Quantity = 9, Unit = "kg", Price = 4.20f },
            new Product { Location = 10, Provider = "Cherix", ProductName = "Groseilles", Quantity = 10, Unit = "kg", Price = 4.40f },
            new Product { Location = 5, Provider = "Blanc", ProductName = "Pruneaux", Quantity = 5, Unit = "kg", Price = 9.00f },
            new Product { Location = 5, Provider = "Blanc", ProductName = "Myrtilles", Quantity = 18, Unit = "kg", Price = 5.60f },
            new Product { Location = 5, Provider = "Blanc", ProductName = "Groseilles", Quantity = 10, Unit = "kg", Price = 2.10f },
            new Product { Location = 5, Provider = "Blanc", ProductName = "Pêches", Quantity = 20, Unit = "kg", Price = 6.40f }
        };
        //0. La quantité de groseilles disponibles sur le marché
        string choice = "Groseilles";
        var quantiteDispo = products.Where(produit => produit.ProductName ==choice).Sum(produit => produit.Quantity);
        Console.WriteLine($"Il y a {quantiteDispo} {choice} au total dans le marché");

        //1.Le chiffre d’affaire possible **total * *pour chaque marchand(tout produit confondu)
        var chiffreAff = products.GroupBy(p => p.Provider).Select(groupe => new
        {
            //on cree une nouvelle liste anonyme
            Provider = groupe.Key,
            chiffreAff = groupe.Sum(p => p.Price * p.Quantity),
        });

        foreach (var item in chiffreAff){
            Console.WriteLine($"Le chiffre d'affaire total pour {item.Provider} et de {item.chiffreAff} fr" );
        }
        var chiffre = chiffreAff.Select(p => p.chiffreAff);
        var chiffreMoyMax = chiffre.Max();
        var chiffreMoyMin = chiffre.Min();
        var chiffreMoyAvg = chiffre.Average();
        //2. Le plus grand, le plus petit et la moyenne de ces chiffres d’affaire

        Console.WriteLine($"le plus grand chiffre d'affaire est {chiffreMoyMax}");
        Console.WriteLine($"le plus petit chiffre d'affaire est {chiffreMoyMin}");
        Console.WriteLine($"La moyenne de chiffre d'affaire est {chiffreMoyAvg}");

    }

    class AnonProduct
    {
        public string ProviderAnon { get; set; }
        public string Name { get; set; }
        public float CA { get; set; }

        public override string ToString()
        {
            return $"{ProviderAnon},{Name},{CA}";
        }
    }

    class Product
    {
        public int Location { get; set; }

        public string Provider { get; set; }
        public string ProductName { get; set; }

        public int Quantity { get; set; }
        public string Unit { get; set; }
        public float Price { get; set; }
    }

}

