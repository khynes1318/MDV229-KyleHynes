using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyleHynes_CodingExercise1and2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool programIsRunning = true;

            while (programIsRunning)
            {
                //Clear the console to clean up for user
                Console.Clear();

                //welcome user and display menu for interaction
                Console.WriteLine("Welcome to the week 1 coding challenge menu...\n================\n");
                Console.WriteLine(
                    "1) Exercise 1\n" +
                    "2) Exercise 2\n" +
                    "3) Exit");
                Console.Write("\nSelection: ");

                //catch user input...convert to lower for validation
                string input = Console.ReadLine().ToLower();


                //create switch to validate response and execute user choice
                switch (input)
                {
                    case "1":
                    case "one":
                    case "exercise 1":
                    case "exercise one":
                        {
                            ExerciseOne.Execute();
                        }
                        break;
                    case "2":
                    case "two":
                    case "exercise 2":
                    case "exercise two":
                        {
                            ExerciseTwo.Execute();
                        }
                        break;
                    case "3":
                    case "three":
                    case "exit":                    
                        {
                            Console.Clear();
                            Console.WriteLine("User has chosen to exit the program\n");
                            Console.WriteLine("Have a great day!\n");
                            programIsRunning = false;
                        }
                        break;

                }
            }
        }
    }
}
