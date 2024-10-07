using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zork
{
    public class Program
    {
        private static void Main(string[] args)
        {
            const string defaultGameFilename = "Zork.json";

            var gameFilename = args.Length > 0 ? args[0] : defaultGameFilename;

            var game = Game.Load(gameFilename);

            Console.WriteLine("Welcome to Zork!");
            game.Run();
            Console.WriteLine("Thank you for playing!");
        }

        public static string Input()
        {
            Console.Write("> ");
            var input = Console.ReadLine().Trim().ToLower();

            return input;
        }

        public static void Output(string output)
        {
            Console.WriteLine($"{output}\n");
        }

    }
}
