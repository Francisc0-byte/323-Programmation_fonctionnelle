using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {

        Action a = () =>
        {
            //partie a
            string[] words = { "whatThe!!!", "bonjour", "hello", "monde", "vert", "rouge", "bleu", "jaune", "My kingdom for a horse !", "Ooops I did it again" };

            Console.WriteLine($"{string.Join(", ", words.Skip(1).SkipLast(2))}");

            //partie b
            string[] wordsSpecial = { "+++++", "<<<<<", ">>>>>", "bonjour", "hello", "@@@@", "vert", "rouge", "bleu", "jaune", "#####", "%%%%%%%" };

            var clean = wordsSpecial.Where(word => word.All(letter => char.IsLetterOrDigit(letter)));
            Console.WriteLine(string.Join(" ", clean));

            //partie c
            string[] wordsElite = { "i am the winner", "hello", "monde", "vert", "rouge", "bleu", "i am the looser" };

            Console.WriteLine($"Winner: {wordsElite.First()}\nLosser: {wordsElite.Last()}");

        };
            a();
        Action epsilon = () => { 
        

        };

    }

}