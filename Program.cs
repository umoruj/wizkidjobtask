using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace wizkidjobtask
{
    class Palindrome {
        public static bool DoOperation(string word) {

            //check if string is empty or null
            if(string.IsNullOrEmpty(word)) {
                return false;
            } else {
                // remove special characters
                string noSpecialCharacters = Regex.Replace(word, "[^a-zA-Z0-9]", "", RegexOptions.Compiled);

                // return bool of whether string is a palindrome or not
                return noSpecialCharacters.SequenceEqual(noSpecialCharacters.Reverse());
            }
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;

            Console.WriteLine("Wizkid job Task test C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp){

                // Ask user to make choice
                string stringInput1 = "";
                Console.WriteLine("Choose an operation from the following list:");
                Console.WriteLine("\ta - Palidrome check");
                Console.WriteLine("\tb - Multiples check");
                Console.Write("Your option? ");
                stringInput1 = Console.ReadLine();

                // check if string is empty or null

                while (string.IsNullOrEmpty(stringInput1)){

                    Console.Write("Please insert a value: ");
                    stringInput1 = Console.ReadLine();
                }

                switch(stringInput1) {
                    case "a":
                    string palindromString = "";
                    Console.Write("Type a word or sentence, and then press Enter: ");
                    palindromString = Console.ReadLine();
                    bool resultPalidrome = Palindrome.DoOperation(palindromString.ToLower());
                    if (resultPalidrome) {
                        Console.WriteLine("The word or sentence is a palindrome");
                    } else {
                        Console.WriteLine("The word or sentence is not a palindrome");
                    }
                    break;
                    case "b":
                    Console.WriteLine("b was chosen");
                    break;
                    default:
                    Console.WriteLine("An invalid selection was made");
                    break;
                }

                Console.WriteLine("------------------------\n");

                // Ask if user want to continue or exit
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
            }

            return;
        }
    }
}
