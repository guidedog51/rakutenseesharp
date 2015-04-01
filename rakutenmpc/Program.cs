using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rakutenmpc
{
    class Program
    {

        enum Validation {tests, firstoccurence, reversestring};
        string inputBuffer;

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine("Welcome to the C# coding test!");
            Console.WriteLine("Press 1 for First Occurrence");
            Console.WriteLine("Press 2 for Reverse A String, or");
            Console.WriteLine("Press q to quit.");

            ConsoleKeyInfo cki = Console.ReadKey(true);
            switch (cki.Key.ToString().ToLower())
            {
                case "q":
                    break;
                case "d1":
                    FirstOccurence();
                    break;
                case "d2":
                    ReverseAString();
                    break;
                default:
                    break;
            }
        }

        static void FirstOccurence()
        {
            Console.WriteLine("You chose First Occurence");
            Console.WriteLine("Enter an integer between 0 and 999,999,999 or");
            Console.WriteLine("Press r to generate one.");

            ConsoleKeyInfo cki = Console.ReadKey(true);

            switch (cki.Key.ToString().ToLower())
            {
                case "r":
                    Random rnd = new Random();
                    var val = rnd.Next(0, 999999999).ToString();
                    Console.WriteLine(string.Format("You entered {0}", val));
                    int ret = GetFirstOccurence();
                    Console.WriteLine(string.Format("Search string occurs at position {0}", ret));

                    Console.WriteLine("Press r to repeat");
                    Console.WriteLine("Press m for main menu, or");
                    Console.WriteLine("Press any other key to quit.");

                    cki = Console.ReadKey(true);
                    switch (cki.Key.ToString().ToLower())
                    {
                        case "r":
                            FirstOccurence();
                            break;
                        case "m":
                            Menu();
                            break;
                        default:
                            break;
                    }
                        break;
                    default:
                        break;
                }
        }

        static int GetFirstOccurence()
        {
            Console.WriteLine("Now enter a search string:");

            string ret = ValidateInput(Validation.reversestring, Console.ReadLine());

            return 0;
        }
        static int GetReverseString()
        {
            Console.WriteLine("Now enter a search string:");

            string ret = ValidateInput(Validation.reversestring, Console.ReadLine());

            return 0;
        }

        static void ReverseAString()
        {
            Console.WriteLine("You chose Reverse A String");
            ConsoleKeyInfo cki = Console.ReadKey(true);
        }

        static string ValidateInput(Validation what, string input)
        {
            var ret = string.Empty;
            return ret;
        }
    }
}
