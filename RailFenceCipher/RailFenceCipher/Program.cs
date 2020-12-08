using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailFenceCipher
{

    class Program
    {
        static void Main(string[] args)
        {
            Test();
            Console.ReadKey();
        }
        public static void Test()
        {
            Console.WriteLine("Enter text:");
            string text = Console.ReadLine();

            Console.WriteLine("Enter rails:");
            int rails = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.WriteLine("Encoded:");
            Console.WriteLine(RailFenceCipher.Encoded(text, rails));

            Console.WriteLine();

            Console.WriteLine("Decoded:");
            Console.WriteLine(RailFenceCipher.Decoded(text, rails));
        }
    }
}

