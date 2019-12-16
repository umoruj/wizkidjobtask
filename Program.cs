using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

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

    class Multiples {
        public static List<int> DoOperation(int value) {
            List<int> result = new List<int>();
            int initialValue = 0;
            while(initialValue < 100) {
                if(initialValue % value == 0) {
                    result.Add(initialValue);
                }
                initialValue++;
            }

            return result;
        }
    }

    class FindReplaceEmail{
        public static List<string> DoOperation(string value) {
            List<string> result = new List<string>();
            const string emailPattern =
           @"(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
           + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
             + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
           + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})";

           Regex rx = new Regex(emailPattern,  RegexOptions.Compiled | RegexOptions.IgnoreCase);

           MatchCollection matches = rx.Matches(value);
           int noOfMatches = matches.Count;
           int initialValue = 0;

           while(initialValue < noOfMatches) {
               if (new EmailAddressAttribute().IsValid(matches[initialValue].Value.ToString())){
                   result.Add(matches[initialValue].Value.ToString());
               }
               initialValue++;
           }

           return result;
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
                Console.WriteLine("\tc - Find and Replace Emails");
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
                    // ask user to make a choice
                    string multipleString = "";
                    Console.WriteLine("Choose an operation from the following list to show multiples:");
                    Console.WriteLine("\tFoo - multiple of 3");
                    Console.WriteLine("\tBar - multiples of 5");
                    Console.WriteLine("\tFooBar - multiples of both 3 and 5");
                    Console.Write("Your option? ");
                    multipleString = Console.ReadLine();

                    while (string.IsNullOrEmpty(multipleString)){
                        Console.Write("This is not valid input. Please enter a selection: ");
                        multipleString = Console.ReadLine();
                    }

                    switch(multipleString) {
                        case "Foo":
                        List<int> resultthree = new List<int>();
                        resultthree = Multiples.DoOperation(3);
                        Console.WriteLine(string.Join("\t", resultthree));
                        break;
                        case "Bar":
                        List<int> resultfive = new List<int>();
                        resultfive = Multiples.DoOperation(5);
                        Console.WriteLine(string.Join("\t", resultfive));
                        break;
                        case "FooBar":
                        List<int> resultthreefirst = new List<int>();
                        List<int> resultfiveSecond = new List<int>();
                        resultthreefirst = Multiples.DoOperation(3);
                        resultfiveSecond = Multiples.DoOperation(5);
                        var total = resultthreefirst.Union(resultfiveSecond);
                        Console.WriteLine(string.Join("\t", total.OrderBy(o=>o).ToList()));
                        break;
                        default:
                        Console.WriteLine("An invalid selection was made");
                        break;
                    }

                    break;
                    default:
                    Console.WriteLine("An invalid selection was made");
                    break;
                    case "c":
                    string findReplaceString = "";
                    Console.WriteLine("Please enter string value: ");
                    findReplaceString = Console.ReadLine();
                    while (string.IsNullOrEmpty(findReplaceString)){
                        Console.Write("This is not valid input. Please enter string value: ");
                        findReplaceString = Console.ReadLine();
                    }

                    List<string> findreplacearray = new List<string>();
                    findreplacearray = FindReplaceEmail.DoOperation(findReplaceString);
                    if (findreplacearray.Count > 0) {
                        Console.WriteLine("\n");
                        Console.WriteLine("valid email: " + string.Join("\t", findreplacearray));
                    } else {
                        Console.WriteLine("\n");
                        Console.WriteLine("No valid email found");
                    }
                    

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
