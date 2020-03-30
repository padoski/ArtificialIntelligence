using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Paweł Gładysz,Adam Kierat
namespace Introduction
{
    class Program
    {
        private static double[][] dane;
        static void Main(string[] args)
        {
            Data.ReadData(@"..//data.txt", ref dane);
            Data.Normalize(ref dane);
            Data.Shuffle(ref dane);

            Grafika grafika = new Grafika();
            Console.WriteLine("Gotowe");

            Console.ReadKey();
        }
    }
}
