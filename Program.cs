using System;
using System.Linq;

namespace wizkidjobtask
{
    class Palindrome {
        public static bool DoOperation(string word) {
            return word.SequenceEqual(word.Reverse());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;

            Console.WriteLine("Palindrome check in C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp){
                string stringInput1 = "";
                bool result = false;

                Console.Write("Type a word or sentence, and then press Enter: ");
                stringInput1 = Console.ReadLine();
                

                while (string.IsNullOrEmpty(stringInput1)){

                    Console.Write("This is not valid input. Please enter a word or sentence: ");
                    stringInput1 = Console.ReadLine();
                }

                result = Palindrome.DoOperation(stringInput1.ToLower());
                Console.WriteLine("Your result: {0:0.##}\n", result);

                Console.WriteLine("------------------------\n");

                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
            }

            return;
        }
    }
}
