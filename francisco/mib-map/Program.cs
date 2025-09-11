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

            //...

            
        };
        //var nomAnonymes = products.Select(p => p.Provider.Length > 4 ? p.Provider.Substring(0, 3) + "..." : p.Provider);

        var ap = products.Select(product => new AnonProduct() { 
            ProviderAnon = product.Provider.Length > 4 ? product.Provider.Substring(0, 3) + "..." + product.Provider[^1] : product.Provider, 
            Name = "pasteque", 
            CA = product.Quantity * product.Price 
        });

        Console.WriteLine(String.Join('\n',ap));
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

