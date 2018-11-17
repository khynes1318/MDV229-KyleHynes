using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<String, List<string>> colors = new Dictionary<string, List<string>>();

            //add values and info for colors
            List<string> redFacts = new List<string>();
            redFacts.Add("Made from orange and violet");
            redFacts.Add("The color of blood");
            redFacts.Add("Sailors saw a red sky in the morning at bad, but a red sky in the evening as good!");
            colors["Red"] = redFacts;

            List<string> orangeFacts = new List<string>();
            orangeFacts.Add("Made from red and yellow");
            orangeFacts.Add("Biblically associated with saints");
            orangeFacts.Add("The Golden Gate Bridge is coated in a color called International Orange");
            colors["Orange"] = orangeFacts;

            List<string> yellowFacts = new List<string>();
            yellowFacts.Add("Made from red and green");
            yellowFacts.Add("In Japan, yellow is the color of courage");
            yellowFacts.Add("In Egypt, yellow is the color of mourning");
            colors["Yellow"] = yellowFacts;

            List<string> greenFacts = new List<string>();
            greenFacts.Add("Made from yellow and blue");
            greenFacts.Add("Green is the national color of Ireland");
            greenFacts.Add("The human eye is most sensitive to the color green");
            colors["Green"] = greenFacts;

            List<string> blueFacts = new List<string>();
            blueFacts.Add("Blue is a primary color, and cannot be made from other colors");
            blueFacts.Add("In ancient Rome, blue was worn by public servants");
            blueFacts.Add("8% of the worlds population has blue eyes");
            colors["Blue"] = blueFacts;

            List<string> indigoFacts = new List<string>();
            indigoFacts.Add("Made from red and blue");
            indigoFacts.Add("Also known as Ultramarine");
            indigoFacts.Add("Named after the plant indigofera tincoria");
            colors["Indigo"] = indigoFacts;

            List<string> violetFacts = new List<string>();
            violetFacts.Add("Made from equal amounts of true blue and red");
            violetFacts.Add("Associated with royalty");
            violetFacts.Add("In the color spectrum, it is closer to blue then it is to purple.");
            colors["Violet"] = violetFacts;

            //create loop that cycles through menu for user to opearte
            bool programIsRunning = true;
            while (programIsRunning)
            {
                Console.Clear();

                Console.WriteLine("Welcome to the color facts program!\n================\n");
                Console.WriteLine("What is your favorite color?\n");

                int i = 1;

                //loop to print colors in the dictionary
                foreach (string color in colors.Keys)
                {
                    Console.WriteLine($"{i}) {color}");
                    i++;
                }
                Console.WriteLine($"{i}) Exit");

                string input = Console.ReadLine().ToLower();

                //switch to execute user selection
                switch (input)
                {
                    case "1":
                    case "one":
                    case "red":
                        {
                            Console.Clear();
                            Console.WriteLine("Facts about the color Red\n============\n");

                            //loop to print values of the selected key from the dictionary
                            int a = 0;
                            foreach (string fact in colors.Values.ElementAt(0))
                            {
                                Console.WriteLine(fact);
                               
                            }

                            Console.Write("\n");
                            Console.WriteLine("Press any key to continue...\n");
                            Console.ReadKey();
                        }
                        break;
                    case "2":
                    case "two":
                    case "orange":
                        {
                            Console.Clear();
                            Console.WriteLine("Facts about the color Orange\n============\n");
                            //loop to print values of the selected key from the dictionary
                            int a = 0;
                            foreach (string fact in colors.Values.ElementAt(1))
                            {
                                Console.WriteLine(fact);

                            }
                        }
                        break;
                    case "3":
                    case "three":
                    case "yellow":
                        {
                            Console.Clear();
                            Console.WriteLine("Facts about the color Yellow\n============\n");
                            //loop to print values of the selected key from the dictionary
                            int a = 0;
                            foreach (string fact in colors.Values.ElementAt(2))
                            {
                                Console.WriteLine(fact);

                            }
                        }
                        break;
                    case "4":
                    case "four":
                    case "green":
                        {
                            Console.Clear();
                            Console.WriteLine("Facts about the color Green\n============\n");
                            //loop to print values of the selected key from the dictionary
                            int a = 0;
                            foreach (string fact in colors.Values.ElementAt(3))
                            {
                                Console.WriteLine(fact);

                            }
                        }
                        break;
                    case "5":
                    case "five":
                    case "blue":
                        {
                            Console.Clear();
                            Console.WriteLine("Facts about the color Blue\n============\n");
                            //loop to print values of the selected key from the dictionary
                            int a = 0;
                            foreach (string fact in colors.Values.ElementAt(4))
                            {
                                Console.WriteLine(fact);

                            }
                        }
                        break;
                    case "6":
                    case "six":
                    case "indigo":
                        {
                            Console.Clear();
                            Console.WriteLine("Facts about the color Indigo\n============\n");
                            //loop to print values of the selected key from the dictionary
                            int a = 0;
                            foreach (string fact in colors.Values.ElementAt(5))
                            {
                                Console.WriteLine(fact);

                            }
                        }
                        break;
                    case "7":
                    case "seven":
                    case "violet":
                        {
                            Console.Clear();
                            Console.WriteLine("Facts about the color Violet\n============\n");
                            //loop to print values of the selected key from the dictionary
                            int a = 0;
                            foreach (string fact in colors.Values.ElementAt(6))
                            {
                                Console.WriteLine(fact);

                            }
                        }
                        break;
                    case "8":
                    case "eight":
                    case "exit":
                        {
                            Console.Clear();
                            Console.WriteLine("You have successfully exited the program\n\nHave a great day!\n");
                            programIsRunning = false;
                        }
                        break;

                }
            }
        }
    }
}
