using System;
using MasterMindLibrary;

namespace MasterMindGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            for (int i = 0; i < 10; i++)
            {
                ColourSet set = new ColourSet();
                Console.WriteLine(set.ToString());
            }
            Console.ReadKey();
        }
    }
}
