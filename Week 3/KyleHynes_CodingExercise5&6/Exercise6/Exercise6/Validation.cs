using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6
{
    class Validation
    {

        public static string ValidateEntry(string message)
        {
            string input = null;

            do
            {
                Console.Write(message);
                input = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(input));
            return input;
        }

        public static decimal GetDecimal(int min, string message)
        {
            decimal validatedDecimal;
            string input = null;

            do
            {
                Console.Write(message);
                input = Console.ReadLine();
            } while (!(decimal.TryParse(input, out validatedDecimal) && (validatedDecimal >= min)));
            return validatedDecimal;
        }

        public static int GetInt(string message = "Enter an integer: ")
        {
            int validatedInt;
            string input = null;
            do
            {
                Console.Write(message);
                input = Console.ReadLine();
            } while (!Int32.TryParse(input, out validatedInt));

            return validatedInt;
        }

        public static int GetInt(int min, int max, string message = "Enter and integer: ")
        {
            int validatedInt;
            string input = null;

            do
            {
                Console.Write(message);
                input = Console.ReadLine();
            } while (!(Int32.TryParse(input, out validatedInt) && (validatedInt >= min && validatedInt <= max)));
            return validatedInt;
        }

        public static bool GetBool(string message = "Enter yes or no: ")
        {
            bool answer = false;
            string input = null;

            bool needAValidResponse = true;

            while (needAValidResponse)
            {
                Console.Write(message);
                input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "yes":
                    case "y":
                    case "t":
                    case "true":
                        {
                            answer = true;
                            needAValidResponse = false;
                        }
                        break;
                    case "no":
                    case "n":
                    case "f":
                    case "false":
                        {
                            needAValidResponse = false;
                        }
                        break;
                }
            }
            return answer;
        }

        public static double GetDouble(string message = "Enter an number: ")
        {
            double validatedDouble;
            string input = null;
            do
            {
                Console.Write(message);
                input = Console.ReadLine();
            } while (!Double.TryParse(input, out validatedDouble));

            return validatedDouble;
        }

        public static double GetDouble(double min, string message)
        {
            double validatedDouble;
            string input = null;

            do
            {
                Console.Write(message);
                input = Console.ReadLine();
            } while (!(Double.TryParse(input, out validatedDouble) && (validatedDouble >= min)));
            return validatedDouble;
        }
    }
}
