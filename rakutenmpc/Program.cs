using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rakutenmpc
{
    class Program
    {

        enum DemoType {tests, firstoccurence, reversestring};
        static string inputBuffer, searchBuffer, reverseBuffer;

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

        static void ContinueMenu(DemoType which = DemoType.firstoccurence)
        {
            Console.WriteLine("Press r to repeat");
            Console.WriteLine("Press m for main menu, or");
            Console.WriteLine("Press any other key to quit.");

            ConsoleKeyInfo cki = Console.ReadKey(true);
            switch (cki.Key.ToString().ToLower())
            {
                case "r":
                    if (which == DemoType.firstoccurence)
                        FirstOccurence(true);
                    else
                        ReverseAString(true);
                    break;
                case "m":
                    Menu();
                    break;
                default:
                    break;
            }
        }

        static void FirstOccurence(bool skipChoice = false)
        {
            if (!skipChoice)
                Console.WriteLine("You chose First Occurence");
            Console.WriteLine("Enter an integer between 0 and 999,999,999 or");
            Console.WriteLine("Press r to generate one.");

            ConsoleKeyInfo cki = Console.ReadKey(true);

            switch (cki.Key.ToString().ToLower())
            {
                case "r":
                    Random rnd = new Random();
                    inputBuffer = rnd.Next(0, 999999999).ToString();
                    Console.WriteLine(string.Format("You entered {0}", inputBuffer));
                    break;
                default:
                    inputBuffer = Console.ReadLine();
                    string res = ValidateInput(DemoType.firstoccurence, inputBuffer);
                    if (res != string.Empty)
                    {
                        Console.WriteLine(res);
                        FirstOccurence(true);
                    }
                    break;
            }
            int ret = GetFirstOccurence();

            string msg = ret < 0 ? "Search string not found" : string.Format("Search string {0} occurs at position {1}: {2}", searchBuffer, ret, getCaretedString(ret));
            Console.WriteLine(msg);

            ContinueMenu();
        }

        static int GetFirstOccurence()
        {
            int res = 0;
            Console.WriteLine("Now enter a search string:");
            searchBuffer = Console.ReadLine();
            string ret = ValidateInput(DemoType.firstoccurence, searchBuffer);
            
            if (ret != string.Empty)
            {
                Console.WriteLine(ret);
                GetFirstOccurence();
            }
            
            //search for the occurence
            res = inputBuffer.IndexOf(searchBuffer);
            return res;
        }

        static void ReverseAString(bool skipTitle = false)
        {
            if (!skipTitle)
                Console.WriteLine("You chose Reverse A String");
            Console.WriteLine("Enter a string to reverse");

            //ConsoleKeyInfo cki = Console.ReadKey(true);
            Console.WriteLine(GetReverseString());

            ContinueMenu(DemoType.reversestring);
        }

        static string GetReverseString()
        {
            reverseBuffer = Console.ReadLine();
            string ret = ValidateInput(DemoType.reversestring, reverseBuffer);

            if (ret != string.Empty)
            {
                Console.WriteLine(ret);
                GetReverseString();
            }

            return new string(reverseBuffer.ToCharArray().Reverse().ToArray());
        }

        static string ValidateInput(DemoType what, string input)
        {
            var ret = string.Empty;

            switch (what)
            {
                case DemoType.tests:
                    break;
                case DemoType.firstoccurence:
                    if (input.Substring(0, 1).Equals("0"))
                    {    
                        ret = string.Format("Invalid input. {0} has lead zero.  Lead zeros not allowed.", input);
                        break;
                    }
                    if (!isPositiveInteger(input))
                    {
                        ret = string.Format("Invalid input. {0} is not a positive integer.", input);
                        break;
                    }
                    if (Int64.Parse(input) > 999999999)
                    {
                        ret = string.Format("Invalid input. {0} is greater than 999,999,999.", input);
                    }
                    break;
                case DemoType.reversestring:
                    if (input.Length > 200000)
                        ret = string.Format("Invalid input.  Length of string exceeds 200,000.");
                    break;
                default:
                    break;
            }
            
            return ret;
        }

        static bool isPositiveInteger(string input) {
            bool ret = false;
            long res = 0;
            if (Int64.TryParse(input, out res))
            {
                if (res > -1)
                    return true;
            }

            return ret;
        }

        static string getCaretedString(int index) {
            int len = searchBuffer.Length;
            StringBuilder sb = new StringBuilder();
            sb.Append(inputBuffer.Substring(0, index));
            sb.Append("^");
            sb.Append(searchBuffer + "^");
            sb.Append(inputBuffer.Substring(index + len));

            return sb.ToString();
        }
    }
}
