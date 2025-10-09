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
        //partie 1
        //filtrage de mot à 4 caractere ou plus
        string[] words = { "bonjour", "hello", "monde", "vert", "rouge", "bleu", "jaune" };

        //var lenghtWords = from word in words
        //                  where word.Length >=4
        //                  select word;
        //foreach ( var word in lenghtWords )
        //{
        //    Console.WriteLine( word );
        //}

        //crée un filtre lambda
        //filtre pour le x
        Func<string, bool> noX = word => !word.Contains("x");
        //filtre pour un mot plus grand que 4 lettre
        Func<string, bool> fourOrMore = word => word.Length > 4;
        //filtre pour calcule la moyenne
        Func<string, bool> sameAsAvg = word => word.Length == words.Average(word2 => word2.Length);

        //met les filtres dans une liste
        var filtre = new List<Func<string, bool>>();
        filtre.Add(noX);
        filtre.Add(fourOrMore);
        filtre.Add(sameAsAvg);

        Console.WriteLine($"Liste de mots : {String.Join(',', words)}");
        Console.WriteLine("1. Pas de x v1");
        Console.WriteLine("2. >= 4");
        Console.WriteLine("3. = moyenne de longueur dans la liste");
        Console.Write("\nChoix: ");

        int choice = Convert.ToInt32(Console.ReadLine()) - 1;

        var filteredData = words.Where(filtre[choice]);

        Console.WriteLine($"Resultat: {string.Join(" ", filteredData)}\n");

        //part 2
        Console.WriteLine($"Dans l'ordre inverse celui naturellement calculé");
        Console.WriteLine("Triés a-z");
        Console.WriteLine("Triés z-a");
        IEnumerable<string> reverseName = filteredData.Reverse();

        //foreach(string word in reverseName)
        //{
        //    Console.WriteLine(word);
        //}

        Console.WriteLine(string.Join(" ", reverseName));

        IEnumerable<string> reverseName2 = filteredData.OrderByDescending(word => word);
        Console.WriteLine(string.Join(" ", reverseName2));

        IEnumerable<string> nameOrder = filteredData.OrderBy(word => word);
        Console.WriteLine(string.Join(" ", nameOrder));
        //Console.WriteLine(string.Join(" ", words.Where(noX)));

        //string result = string.Join(" ", words.Where(noX));

        //Console.WriteLine(result);


        //Console.WriteLine(string.Join(" ",words.Where(fourOrMore)));


        //Console.WriteLine(string.Join(" ",words.Where(sameAsAvg)));

        Console.Read();

    }
}