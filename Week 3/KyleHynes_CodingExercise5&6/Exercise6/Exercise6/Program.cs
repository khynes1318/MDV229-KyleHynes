using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {

            //create decks dictionary
            Dictionary<string, int> deck = new Dictionary<string, int>();
            //call method to fill dictionary
            deck = FillDeck();

            //create dictionaries to hold players and their delt cards
            Dictionary<string, Dictionary<string, int>> playerOne = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, Dictionary<string, int>> playerTwo = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, Dictionary<string, int>> playerThree = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, Dictionary<string, int>> playerFour = new Dictionary<string, Dictionary<string, int>>();

            //intro user and explain the game
            Console.Clear();
            Console.WriteLine("Welcome to the Card Counting Game!\n============================\n");
            Console.WriteLine("Rules are simple!\n\nEveryone is dealt an even amount of cards...\n\nWhoever has the most value wins!\n");
            Console.WriteLine("Press any key to enter the game...\n");
            Console.ReadKey();


            //variable to use to keep menu running till complete
            bool programIsRunning = true;
            while (programIsRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Card Counting Game!\n============\n");

                Console.WriteLine("First, let's add four players...\n");

                List<string> playersTemp = new List<string>();

                //loop to have user enter players
                
                for (int i = 1; i < 5; i++)
                {
                    string pTemp = Validation.ValidateEntry($"What is the name of player {i}: ");
                    playersTemp.Add(pTemp);
                }
                Console.Write("\n");

                Console.Clear();
                Console.WriteLine("Confirm Player entry...\n");
                
                //print user selected players for confirmation...
                foreach(string pt in playersTemp)
                {
                    Console.WriteLine($"** {pt}");
                }

                Console.Write("\nAre these the correct players? Yes or No: ");
                string input = Console.ReadLine().ToLower();
                //switch to validate response and execute
                switch (input)
                {
                    case "y":
                    case "yes":
                        {

                            //Add players to their respective dictionaries
                            playerOne.Add(playersTemp[0], null);
                            playerTwo.Add(playersTemp[1], null);
                            playerThree.Add(playersTemp[2], null);
                            playerFour.Add(playersTemp[3], null);

                            Console.WriteLine("\nPlayers Confirmed! Let the game begin!!!\n\nPress any key to continue...");
                            Console.ReadKey();
                            programIsRunning = false;
                        }
                        break;
                    case "n":
                    case "no":
                        {
                            playersTemp = null;
                        }
                        break;
                }
            }

                Console.Clear();
                Console.WriteLine("Welcome to the Card Counting Game!\n============\n");

                Console.WriteLine("Now that the players are chosen, let's Shuffle cards!\n\nPress any key to shuffle cards...\n");
            Console.ReadKey();

            //shuffle deck
            Random rand = new Random();
            deck = deck.OrderBy(x => rand.Next())
              .ToDictionary(item => item.Key, item => item.Value);

            Console.Clear();
            Console.WriteLine("Great Job! Deck has been shuffled!\n\nNow let's deal out the cards...\n");

            Console.WriteLine($"Cards in Deck: {deck.Count}\n");
            Console.WriteLine($"{playerOne.Keys.ElementAt(0)}'s Card Count: 0");
            Console.WriteLine($"{playerTwo.Keys.ElementAt(0)}'s Card Count: 0");
            Console.WriteLine($"{playerThree.Keys.ElementAt(0)}'s Card Count: 0");
            Console.WriteLine($"{playerFour.Keys.ElementAt(0)}'s Card Count: 0");

            Console.WriteLine("\nPress any key to deal cards...\n");

            Console.ReadKey();

            Dictionary<string, int> p1Temp = new Dictionary<string, int>();
            Dictionary<string, int> p2Temp = new Dictionary<string, int>();
            Dictionary<string, int> p3Temp = new Dictionary<string, int>();
            Dictionary<string, int> p4Temp = new Dictionary<string, int>();

            int b = 0;
            while (deck.Count > 0)
            {
                p1Temp.Add(deck.ElementAt(b).Key, deck.ElementAt(b).Value);
                deck.Remove(deck.ElementAt(b).Key);

                p2Temp.Add(deck.ElementAt(b).Key, deck.ElementAt(b).Value);
                deck.Remove(deck.ElementAt(b).Key);

                p3Temp.Add(deck.ElementAt(b).Key, deck.ElementAt(b).Value);
                deck.Remove(deck.ElementAt(b).Key);

                p4Temp.Add(deck.ElementAt(b).Key, deck.ElementAt(b).Value);
                deck.Remove(deck.ElementAt(b).Key);
            }

            playerOne[playerOne.Keys.ElementAt(0)] = p1Temp;
            playerTwo[playerTwo.Keys.ElementAt(0)] = p2Temp;
            playerThree[playerThree.Keys.ElementAt(0)] = p3Temp;
            playerFour[playerFour.Keys.ElementAt(0)] = p4Temp;

            Console.Clear();
            Console.WriteLine("Cards Successfully dealt!\n");

            Console.WriteLine($"Cards in Deck: {deck.Count}\n");
            Console.WriteLine($"{playerOne.Keys.ElementAt(0)}'s Card Count: {playerOne.ElementAt(0).Value.Count}");
            Console.WriteLine($"{playerTwo.Keys.ElementAt(0)}'s Card Count: {playerTwo.ElementAt(0).Value.Count}");
            Console.WriteLine($"{playerThree.Keys.ElementAt(0)}'s Card Count: {playerThree.ElementAt(0).Value.Count}");
            Console.WriteLine($"{playerFour.Keys.ElementAt(0)}'s Card Count: {playerFour.ElementAt(0).Value.Count}");

            Console.WriteLine("\nPress any key to view results...\n");

            Console.ReadKey();

            Console.Clear();

            //calculate values of cards
            int p1 = 0;
            int p1N = 1;
            int p1Total = 0;
            while (p1N <= playerOne.ElementAt(0).Value.Count)
            {
                p1Total += playerOne.ElementAt(0).Value.ElementAt(p1).Value;
                p1++;
                p1N++;
            }

            int p2 = 0;
            int p2N = 1;
            int p2Total = 0;
            while (p2N <= playerTwo.ElementAt(0).Value.Count)
            {
                p2Total += playerTwo.ElementAt(0).Value.ElementAt(p2).Value;
                p2++;
                p2N++;
            }

            int p3 = 0;
            int p3N = 1;
            int p3Total = 0;
            while (p3N <= playerThree.ElementAt(0).Value.Count)
            {
                p3Total += playerThree.ElementAt(0).Value.ElementAt(p3).Value;
                p3++;
                p3N++;
            }

            int p4 = 0;
            int p4N = 1;
            int p4Total = 0;
            while (p4N <= playerFour.ElementAt(0).Value.Count)
            {
                p4Total += playerFour.ElementAt(0).Value.ElementAt(p4).Value;
                p4++;
                p4N++;
            }

            Console.WriteLine("Card Counting Game Results!!!\n====================\n");

            if (p1Total > p2Total && p1Total > p3Total && p1Total > p4Total)
            {
                Console.WriteLine($"{playerOne.Keys.ElementAt(0)} is the Winner!!!\n");
            }
            else if (p2Total > p1Total && p2Total > p3Total && p2Total > p4Total)
            {
                Console.WriteLine($"{playerTwo.Keys.ElementAt(0)} is the Winner!!!\n");
            }
            else if (p3Total > p1Total && p3Total > p2Total && p3Total > p4Total)
            {
                Console.WriteLine($"{playerThree.Keys.ElementAt(0)} is the Winner!!!\n");
            }
            else
            {
                Console.WriteLine($"{playerFour.Keys.ElementAt(0)} is the Winner!!!\n");
            }

            Console.WriteLine($"{playerOne.Keys.ElementAt(0)}'s Total Hand Value: {p1Total}");
            Console.WriteLine($"{playerTwo.Keys.ElementAt(0)}'s Total Hand Value: {p2Total}");
            Console.WriteLine($"{playerThree.Keys.ElementAt(0)}'s Total Hand Value: {p3Total}");
            Console.WriteLine($"{playerFour.Keys.ElementAt(0)}'s Total Hand Value: {p4Total}\n");

            Console.WriteLine($"Total value of all cards: {p1Total+p2Total+p3Total+p4Total}");

            Console.WriteLine("\nPress any key to see the full list of players cards...");

            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Players hands\n============\n");

            Console.WriteLine($"{playerOne.Keys.ElementAt(0)}'s Cards\n================\n");
            foreach(KeyValuePair<string, int> hand in playerOne.ElementAt(0).Value)
            {
                Console.WriteLine($"{hand.Key} - {hand.Value}");
            }
            Console.WriteLine("\n-------------------------\n");

            Console.WriteLine("Press any key to see next players hand...\n");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Players hands\n============\n");

            Console.WriteLine($"{playerTwo.Keys.ElementAt(0)}'s Cards\n================\n");
            foreach (KeyValuePair<string, int> hand in playerTwo.ElementAt(0).Value)
            {
                Console.WriteLine($"{hand.Key} - {hand.Value}");
            }
            Console.WriteLine("\n-------------------------\n");

            Console.WriteLine("Press any key to see next players hand...\n");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Players hands\n============\n");

            Console.WriteLine($"{playerThree.Keys.ElementAt(0)}'s Cards\n================\n");
            foreach (KeyValuePair<string, int> hand in playerThree.ElementAt(0).Value)
            {
                Console.WriteLine($"{hand.Key} - {hand.Value}");
            }
            Console.WriteLine("\n-------------------------\n");

            Console.WriteLine("Press any key to see next players hand...\n");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Players hands\n============\n");

            Console.WriteLine($"{playerFour.Keys.ElementAt(0)}'s Cards\n================\n");
            foreach (KeyValuePair<string, int> hand in playerFour.ElementAt(0).Value)
            {
                Console.WriteLine($"{hand.Key} - {hand.Value}");
            }
            Console.WriteLine("\n-------------------------\n");

            Console.WriteLine("Thanks for playing!!\n\nPress any key to exit...\n");
            Console.ReadKey();
        }

        //Method that adds cards to deck
        public static Dictionary<string, int> FillDeck()
        {
            Dictionary<string, int> deckTemp = new Dictionary<string, int>();

            deckTemp.Add("2 of Spades", 2);
            deckTemp.Add("2 of Clubs", 2);
            deckTemp.Add("2 of Hearts", 2);
            deckTemp.Add("2 of Diamonds", 2);

            deckTemp.Add("3 of Spades", 3);
            deckTemp.Add("3 of Clubs", 3);
            deckTemp.Add("3 of Hearts", 3);
            deckTemp.Add("3 of Diamonds", 3);

            deckTemp.Add("4 of Spades", 4);
            deckTemp.Add("4 of Clubs", 4);
            deckTemp.Add("4 of Hearts", 4);
            deckTemp.Add("4 of Diamonds", 4);

            deckTemp.Add("5 of Spades", 5);
            deckTemp.Add("5 of Clubs", 5);
            deckTemp.Add("5 of Hearts", 5);
            deckTemp.Add("5 of Diamonds", 5);

            deckTemp.Add("6 of Spades", 6);
            deckTemp.Add("6 of Clubs", 6);
            deckTemp.Add("6 of Hearts", 6);
            deckTemp.Add("6 of Diamonds", 6);

            deckTemp.Add("7 of Spades", 7);
            deckTemp.Add("7 of Clubs", 7);
            deckTemp.Add("7 of Hearts", 7);
            deckTemp.Add("7 of Diamonds", 7);

            deckTemp.Add("8 of Spades", 8);
            deckTemp.Add("8 of Clubs", 8);
            deckTemp.Add("8 of Hearts", 8);
            deckTemp.Add("8 of Diamonds", 8);

            deckTemp.Add("9 of Spades", 9);
            deckTemp.Add("9 of Clubs", 9);
            deckTemp.Add("9 of Hearts", 9);
            deckTemp.Add("9 of Diamonds", 9);

            deckTemp.Add("10 of Spades", 10);
            deckTemp.Add("10 of Clubs", 10);
            deckTemp.Add("10 of Hearts", 10);
            deckTemp.Add("10 of Diamonds", 10);

            deckTemp.Add("Jack of Spades", 12);
            deckTemp.Add("Jack of Clubs", 12);
            deckTemp.Add("Jack of Hearts", 12);
            deckTemp.Add("Jack of Diamonds", 12);

            deckTemp.Add("Queen of Spades", 12);
            deckTemp.Add("Queen of Clubs", 12);
            deckTemp.Add("Queen of Hearts", 12);
            deckTemp.Add("Queen of Diamonds", 12);

            deckTemp.Add("King of Spades", 12);
            deckTemp.Add("King of Clubs", 12);
            deckTemp.Add("King of Hearts", 12);
            deckTemp.Add("King of Diamonds", 12);

            deckTemp.Add("Ace of Spades", 15);
            deckTemp.Add("Ace of Clubs", 15);
            deckTemp.Add("Ace of Hearts", 15);
            deckTemp.Add("Ace of Diamonds", 15);

            return deckTemp;
        }
    }
}
