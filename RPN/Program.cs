using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace RBN
{
    class Program
    {
        public static List<int> primeList = new List<int>();
        public static List<int> rpnList = new List<int>();

        static void Main(string[] args)
        {
            Boolean finished = false;
            Console.WriteLine("Enter the upper limit you want, then the program will list all the RPNs up to that number and then you can choose one");
            string userinput = Console.ReadLine();
            long input = (long)Convert.ToDouble(userinput);
            findPrimes(input);
            Console.WriteLine("Complete... " + rpnList.Count);
            Console.WriteLine();
            while (!finished)
            {

                Console.WriteLine("What RPN do you want? Enter Q if you want to exit the program.");
                string userInput = Console.ReadLine();
                if (userInput.ToUpper().Contains("Q"))
                {
                    finished = !finished;
                    Environment.Exit(0);
                }
                else
                {
                    int userInputRNP = Int32.Parse(userInput) - 1;
                    Console.WriteLine(rpnList.ElementAt(userInputRNP));
                }
                Console.WriteLine();
            }
        }

        public static string amountOfRightMostDigits(int x, int z)
        {
            string SubString = x.ToString().Substring(x.ToString().Length - z);
            return SubString;
        }
        private static void checkSubsequent(int x) //finds the digit length and passes it to primeListContains
        {

            //this does all the if statements below but I put it into a far loop instead
            for (int i = 2; i < 13; i++)
            {
                if (x.ToString().Length == i)
                {
                    primeListContains(x, i);
                }
            }

        } 
        public static void primeListContains(int x, int z) //to recursively check the numbers to the right
        {
          if (primeList.Contains(Int32.Parse(amountOfRightMostDigits(x, (z-1)))))
            {
                rpnList.Add(x);
                Console.WriteLine(x);
            }

        }
        
        public static void findPrimes(long maxNumber) //find all the primes
        {
            //add all the single digit primes first
            rpnList.Add(2); Console.WriteLine("2");
            rpnList.Add(3); Console.WriteLine("3");
            rpnList.Add(5); Console.WriteLine("5");
            rpnList.Add(7); Console.WriteLine("7");
            //below I find all the remaining primes 
            long sqrt = (long)Convert.ToDouble(Math.Sqrt(maxNumber));
            bool[] prime = new bool[maxNumber];
            for (int x = 2; x < maxNumber; x++) //here I set all the boolean values to 2
            {
                prime[x] = true;
            }
            
            for (int y = 2; y < sqrt; y++) //make all values which are multiples false, also < sqrt to speed up algorithm

            {
                if (prime[y])
                {
                    for (long z = 2; (z * y) < maxNumber; z++)
                    {
                        prime[z * y] = false;
                    }
                }
            }
            for (int x = 2; x < maxNumber; x++) //add each number to a list of primes and then check if the trailiing digits are primes i.e RBN
            {
                bool result = x.ToString().Contains(0.ToString());
                if ((prime[x] == true) && (!result))
                {
                    primeList.Add(x);
                    checkSubsequent(x);
                    //Console.WriteLine(x);
                }
            }
        }
    }


}

