using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapi.SwapiExplorer
{
    public static class Extension
    {
        public static void Write(this IEnumerable<object>target,char separator=',')
        {
            Console.WriteLine(string.Join(separator,target));
        }
    }
}
