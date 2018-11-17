using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyleHynes_CodingExercise1and2
{
    class ExerciseTwo
    {
        static public void Execute()
        {

            //variable to control loop
            bool programIsRunning = true;
            
            //create loop to keep menu going
            while (programIsRunning)
            {
                Console.Clear();

                //variable to track number of guesses
                int a = 1;

                //variable to track guesses remaining
                int c = 10;

                //variable to hold correct answer
                string answer = "Columbia";

                //variable to hold clues
                string hintA = "";
                string hintB = "";
                string hintC = "";
                string hintD = "";
  
                //variable to hold guess
                string guess = null;

                while (guess != answer)
                {
                    if (c>0)
                    {
                        Console.Clear();

                        Console.WriteLine("Welcome to the guessing game!!\n================\n");
                        Console.WriteLine("The object of the game is to guess what the secret clothing brand is!\n");

                        Console.WriteLine("Hints:\n****************");

                        if (a == 1)
                        {
                            hintA = "--------";
                            hintB = "";
                            hintC = "";
                            hintD = "";
                        }
                        else if (a == 2 || a == 3)
                        {
                            hintA = "--l-----a";
                            hintB = "Outdoors";
                            hintC = "";
                            hintD = "";
                        }
                        else if (a >= 4 && a <= 8)
                        {
                            hintA = "--l-m--a";
                            hintB = "Outdoors";
                            hintC = "Colder Enviroments";
                            hintD = "";
                        }
                        else if (a >= 9 || a == 10)
                        {
                            hintA = "--l-m--a";
                            hintB = "Outdoors";
                            hintC = "Colder Enviroments";
                            hintD = "Country";
                        }

                        Console.WriteLine($"Hint 1: {hintA}");
                        Console.WriteLine($"Hint 2: {hintB}");
                        Console.WriteLine($"Hint 3: {hintC}");
                        Console.WriteLine($"Hint 4: {hintD}");

                        Console.Write("\n");


                        if (c > 1)
                        {
                            Console.WriteLine($"{c} guesses remaining!");
                        }
                        else
                        {
                            Console.WriteLine($"{c} guess remaining! LAST GUESS!!!");
                        }

                        Console.Write("\n");

                        Console.Write($"Guess #{a}: ");
                        guess = Console.ReadLine();
                        if (guess == "columbia")
                        {
                            Console.WriteLine("\nYou're really close! Check your punctuation!!\n");
                            Console.WriteLine("Press any key to conitnue...");
                            Console.ReadKey();
                        }
                        a++;
                        c--;
                    }
                    else
                    {

                        hintA = "Columbia";
                        hintB = "Outdoors";
                        hintC = "Colder Enviroments";
                        hintD = "Country";

                        Console.WriteLine("Oh No! You ran out of guesses!\n\nThe correct answer is: Columbia\n");
                        Console.WriteLine("Press any key to conitnue...");
                        Console.ReadKey();
                        programIsRunning = false;

                    }
                }
                Console.WriteLine($"\nYou Did it!! The correct answer is {guess}!!! and you got it on guess #{a}!");

                programIsRunning = false;
                Console.WriteLine("\nThank you for playing! Press any key to continue...");
                Console.ReadKey();

                


            }
        }
    }
}
