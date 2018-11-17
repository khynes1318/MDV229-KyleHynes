using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //int vars to hold game status
            int roundsPlayed = 1;
            int playerWins = 0;
            int compWins = 0;
            

            //array of game choices
            string[] gameOptions = new string[] { "Rock", "Paper", "Scissors", "Lizard", "Spock"};

            Console.Clear();

            //introduce user to game
            Console.WriteLine("Welcome to the game of Rock, Paper, Scissors, Lizard, Spock!\n====================\n");
            Console.WriteLine("Rules:\n");

           

            Console.WriteLine(
                "**Scissors cuts Paper\n" +
                "**Paper covers Rock\n" +
                "**Rock crushes Lizard\n" +
                "**Rock crushes Lizard\n" +
                "**Lizard poisons Spock\n" +
                "**Scissors decapitates Lizard\n" +
                "**Lizard eats Paper\n" +
                "**Paper disproves Spock\n" +
                "**Spock vaporizes Rock\n" +
                "**(and as it always has) Rock crushes Scissors\n");

            Console.WriteLine("Press any key to continue to game...");

            Console.ReadKey();


            //loop to run til program ends
            while (roundsPlayed <= 10)
            {
                Console.Clear();
                //title output for the user
                Console.WriteLine("Welcome to the game of Rock, Paper, Scissors, Lizard, Spock!\n====================\n");

                //more putput so the user understands whats going on
                Console.WriteLine($"Round: {roundsPlayed}");

                if (roundsPlayed > 1)
                {
                    Console.WriteLine(
                        $"Player Wins: {playerWins}\n" +
                        $"Computer Wins: {compWins}\n");

                    if (playerWins == compWins)
                    {
                        Console.WriteLine("Current Winner: Tied!");
                    }
                    else if (playerWins > compWins)
                    {
                        Console.WriteLine("Current Winner: Player!");
                    }
                    else
                    {
                        Console.WriteLine("Current Winner: Computer!");
                    }
                }

                Console.Write("\n");

                int i = 1;
                int index = 0;

                //loop through array so user can choose
                foreach (string g in gameOptions)
                {
                    Console.WriteLine($"{i}) {g}");
                    i++;
                }
                Console.Write("\n");
                //capture use selection
                index = Validation.GetInt(1, gameOptions.Length, "Selection: ");
                index--;

                //select random index for array
                Random rand = new Random();
                int cIndex = rand.Next(gameOptions.Length);

                Console.Write("\n");
                Console.WriteLine($"Player Choice: {gameOptions[index]}");
                Console.WriteLine($"Computer Choice: {gameOptions[cIndex]}\n");


                //statments to check and display winner
                if (index == cIndex)
                {
                    Console.WriteLine("Results: It's a Tie!!");
                }
                else
                {
                    int winner = WhoWon(index, cIndex);
                    if (winner == 0)
                    {
                        Console.WriteLine("Results: Player Won!!");
                        playerWins++;
                    }
                    else
                    {
                        Console.WriteLine("Results: Computer Won!!");
                        compWins++;
                    }
                }

                roundsPlayed++;
                Console.ReadKey();
            }

            Console.Clear();
            Console.WriteLine("Final Results!!\n============\n");

            Console.WriteLine(
                        $"Player Wins: {playerWins}\n" +
                        $"Computer Wins: {compWins}\n");

            if (playerWins == compWins)
            {
                Console.WriteLine("It's a Tie!!");
            }
            else if (playerWins > compWins)
            {
                Console.WriteLine("Player Wins!");
            }
            else
            {
                Console.WriteLine("Computer Wins!");
            }
            Console.WriteLine("\nThanks For Playing!\n\nPress Any Key To Exit...\n");
            Console.ReadKey();


        }

        //method to determine winner
        public static int WhoWon(int p, int c)
        {
            int w = 0;

            //s/p
            if(p==2 && c == 1)
            {
                w = 0;
            }
            else if (p == 1 && c == 2)
            {
                w = 1;
            }

            //p/r
            else if (p == 1 && c == 0)
            {
                w = 0;
            }
            else if (p == 0 && c == 1)
            {
                w = 1;
            }

            //r/l
            else if (p == 0 && c == 3)
            {
                w = 0;
            }
            else if (p == 3 && c == 0)
            {
                w = 1;
            }

            //l/s
            else if (p == 3 && c == 4)
            {
                w = 0;
            }
            else if (p == 4 && c == 3)
            {
                w = 1;
            }

            //s/s
            else if (p == 4 && c == 2)
            {
                w = 0;
            }
            else if (p == 2 && c == 4)
            {
                w = 1;
            }

            //s/l
            else if (p == 4 && c == 3)
            {
                w = 0;
            }
            else if (p == 3 && c == 4)
            {
                w = 1;
            }

            //l/p
            else if (p == 3 && c == 1)
            {
                w = 0;
            }
            else if (p == 1 && c == 3)
            {
                w = 1;
            }

            //p/s
            else if (p == 1 && c == 4)
            {
                w = 0;
            }
            else if (p == 4 && c == 1)
            {
                w = 1;
            }

            //s/r
            else if (p == 5 && c == 0)
            {
                w = 0;
            }
            else if (p == 0 && c == 5)
            {
                w = 1;
            }

            //r/s
            else if (p == 0 && c == 2)
            {
                w = 0;
            }
            else if (p == 2 && c == 0)
            {
                w = 1;
            }
            return w;
        }
    }
}
