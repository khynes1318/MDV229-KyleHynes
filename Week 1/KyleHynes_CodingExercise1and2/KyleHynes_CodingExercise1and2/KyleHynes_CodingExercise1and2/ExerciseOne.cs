using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyleHynes_CodingExercise1and2
{
    class ExerciseOne
    {
        static public void Execute()
        {
            List<string> brands = new List<string> {"Puma","Abercrombie", "Adidas", "Levi", "Converse", "Roxy", "Underarmour", "Rue21", "Pacsun", "H&M", "Hollister", "Forever 21", "Tillys", "REI", "Ralph Lauren", "Finish Line", "Haynes", "Champion", "Kirkland", "Goodfellow"};

            bool programIsRunning = true;
            while (programIsRunning)
            {
                //clear console to clean up for user
                Console.Clear();
                //welcome user and display menu for interaction
                Console.WriteLine("Welcome to the week 1 exercise 1 program!\n================\n");
                Console.WriteLine("What would you like to do with the list of clothing lines?");
                Console.WriteLine(
                    "\n1) Display clothing brands (A-Z)\n" +
                    "2) Display clpthing brands (Z-A)\n" +
                    "3) Randomly choose a brand...then delete it\n" +
                    "4) Back to main menu\n");
                Console.Write("\nSelection: ");
                //Catch user response, convert tp lower case for validation
                string input = Console.ReadLine().ToLower();

                //create switch statement to validate response and execute user choice
                switch (input)
                {
                    case "1":
                    case "one":
                        {
                            //array length validation
                            if (brands.Count == 0)
                            {
                                NoMoreBrands();
                            }
                            else
                            {
                                AlphabetizeAsc(brands);
                            }
                        }
                        break;
                    case "2":
                    case "two":
                        {
                            //array length validation
                            if (brands.Count == 0)
                            {
                                NoMoreBrands();
                            }
                            else
                            {
                                AlphabetizeDesc(brands);
                            }
                        }
                        break;
                    case "3":
                    case "three":
                        {
                            //array length validation
                            if (brands.Count == 0)
                            {
                                NoMoreBrands();
                            }
                            else
                            {
                                Console.Write("\n");

                                bool selectionLoop = true;
                                while (selectionLoop)
                                {
                                    Console.Clear();
                                    int i = 1;
                                    Console.WriteLine("Available Brands\n================");
                                    foreach(string brand in brands)
                                    {
                                        Console.WriteLine($"{i}) {brand}");
                                        i++;
                                    }

                                    Console.WriteLine("\nPlease select one of the following...\n");
                                    Console.WriteLine(
                                        "1) Randonly select a brand from the list one at a time\n" +
                                        "2) Randomly select a brand till there are no brands left\n" +
                                        "3) Go Back!\n");
                                    string input2 = Console.ReadLine().ToLower();
                                    switch (input2)
                                    {
                                        case "1":
                                        case "one":
                                            {
                                                //create new random object
                                                Random ran = new Random();

                                                //grab random string and store in variable
                                                string ranBrand = brands[ran.Next(brands.Count)];
                                                Console.Write("\n");
                                                Console.WriteLine($"You have randomly selected {ranBrand} from the availble brands list...\n");
                                                Console.WriteLine($"{ranBrand} has been succesfully deleted...");

                                                //give user option to halt the deletion of the index

                                                Console.Write($"\nUndo deletion of {ranBrand}? (Yes or No) ");

                                                string undoCheck = Console.ReadLine().ToLower();
                                                switch (undoCheck)
                                                {
                                                    case "yes":
                                                        {
                                                            Console.WriteLine($"Deletion of {ranBrand} has been canceled...");

                                                            Console.WriteLine("\nPress any key to continue...");
                                                            Console.ReadKey();
                                                        }
                                                        break;
                                                    case "no":
                                                        {
                                                            Console.WriteLine($"\n{ranBrand} has been permenently deleted...");
                                                            //remove chosen string from array
                                                            brands.Remove(ranBrand);
                                                            Console.WriteLine("\nPress any key to continue...");
                                                            Console.ReadKey();
                                                        }
                                                        break;
                                                }
                                                
                                            }
                                            break;
                                        case "2":
                                        case "two":
                                            {
                                                Console.WriteLine("Choosing this menu will result in the permanent deletion of all brands...\n");
                                                Console.Write("Are you sure you want to proceed? (Yes or No) ");
                                                string deletionCheck = Console.ReadLine().ToLower();

                                                switch (deletionCheck)
                                                {
                                                    case "yes":
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("This program will now randomly generate a brand, delete it, then repeat until no brands remain...\n");

                                                            Console.WriteLine("\nPress any key to execute program...\n");
                                                            Console.ReadKey();
                                                            int p = 1;
                                                            while (brands.Count > 0)
                                                            {
                                                                int l = 1;
                                                                Console.WriteLine($"Deletion Loop {p}\n================");
                                                                foreach (string brand in brands)
                                                                {
                                                                    Console.WriteLine($"{l}) {brand}");
                                                                    l++;
                                                                }

                                                                Random ran = new Random();

                                                                //grab random string and store in variable
                                                                string ranBrand = brands[ran.Next(brands.Count)];
                                                                Console.Write("\n");
                                                                Console.WriteLine($"You have randomly selected {ranBrand} from the availble brands list...\n");
                                                                Console.WriteLine($"{ranBrand} has been succesfully deleted...\n================\n");
                                                                brands.Remove(ranBrand);

                                                                p++;
                                                            }

                                                            selectionLoop = false;

                                                            Console.WriteLine("\nAll brands have been deleted...");
                                                            Console.WriteLine("\nPress any key to continue...");
                                                            Console.ReadKey();
                                                        }
                                                        break;
                                                    case "no":
                                                        {
                                                            Console.WriteLine($"Deletion of brands has been canceled...");

                                                            Console.WriteLine("\nPress any key to continue...");
                                                            Console.ReadKey();
                                                        }
                                                        break;
                                                }
                                            }
                                            break;
                                        case "3":
                                        case "three":
                                        case "exit":
                                            {
                                                selectionLoop = false;
                                            }
                                            break;
                                    }
                                }

                            }
                        }
                        break;
                    case "4":
                    case "four":
                        {
                            Console.WriteLine("Press any key to return to the main menu...\n");
                            Console.ReadKey();
                            programIsRunning = false;
                        }
                        break;
                }


            }

        }
        
        //method to print that array is empty to user
        public static void NoMoreBrands()
        {
            Console.Write("\n");
            Console.WriteLine("There are no more brands left to display!\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        //Method to print array in ascending alphabetical order
        public static void AlphabetizeAsc(List<string> brands)
        {

            Console.Write("\n");

            //sort arry
            brands.Sort();

            //printed sorted array to console
            int i = 1;
            foreach (var brand in brands)
            {
                Console.WriteLine($"{i}) {brand}");
                i++;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        //Method to print array in descending alphabetical order
        public static void AlphabetizeDesc(List<string> brands)
        {

            Console.Write("\n");

            //sort arry
            brands.Sort();

            //Reverse sorted array 
            brands.Reverse();

            //printed sorted array to console
            int i = 1;
            foreach (var brand in brands)
            {
                Console.WriteLine($"{i}) {brand}");
                i++;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        
    }
}
