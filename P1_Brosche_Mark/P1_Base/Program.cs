using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_Base
{
    public class FactorCalculation
    {
        /////////////////////////////// Prime Factoring Algorithm: /////////////////////////////////////////////
        // To calculate prime factors without the given array, find the lowest integer that divides cleanly into the
        // user defined number, add it to a list and continue dividing by that number and adding it to the list until
        // it no longer divides cleanly, then find the next lowest integer and repeat until the original number is 1.
        public static List<int> PrimeFactorer(int num)
        {
            List<int> primeFactors = new List<int>();
            for (int divisor = 2; num > 1; divisor++)        // Starting with the first prime number (2), and not ending until 
            {                                                // 'num' is 1, increase 'mod' every iteration
                while (num % divisor == 0)                   // While 'mod' divides cleanly into 'num' then keep iterating
                {
                    num /= divisor;                          // Set num equal to the division of itself by 'mod' to reduce it
                    primeFactors.Add(divisor);               // Add the prime factor to the List!
                }
            }
            return primeFactors;
        }

        /////////////////////////////// Common Factor List Assembler: //////////////////////////////////////////
        public static List<int> CommonFactors(List<int> smaller_list, List<int> bigger_list)
        {
            List<int> comFactors = new List<int>();
            List<int> uncomFactors = new List<int>();
            for (int i = 0; i < smaller_list.Count; i++)                // Step through the smaller factor list elements (i).
            {
                if (bigger_list.Contains(smaller_list[i]))              // If the larger list contains the same element... 
                {
                    comFactors.Add(smaller_list[i]);                    // ...add it to the common list...                    
                    bigger_list.Remove(smaller_list[i]);                // ...and delete that instance from the bigger list.
                }
            }
            return comFactors;
        }
        
        ////////////////////////////// GCF Algorithm: ///////////////////////////////////////////////////////////
        public static int GreatestCommonFactor(List<int> cFactors, int a, int b)
        {
            int GCF = 1;
            for (int i = 0; i < cFactors.Count; i++)
            {
                GCF *= cFactors[i];                                           // Set GCF equal to its product with each list item.        
            }
            Console.WriteLine("The GCF of " + a + " and " + b + " is: " + GCF);
            return GCF;
        }

        ////////////////////////////// LCD Algorithm: ///////////////////////////////////////////////////////////
        public static void LeastCommonDenominator(int GCF, int a, int b)
        {
            int LCD = a * b / GCF ;
            Console.WriteLine("The LCD of " + a + " and " + b + " is: " + LCD);
        }

        ////////////////////////////// Euclidean Algorithm: /////////////////////////////////////////////////////
        public static int EuclidsAlgo(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b) a %= b;
                else b %= a;
            }
            if (a == 0) return b;
            else return a;
        }
    }


    class Program
    {
        // Instructor-provided code (with edits from Brosche):
        static void Main(string[] args)
        {
            int a = -1, b = -1;
            string sa, sb;
            //The following array of primes is not used in my code.
            //int[] primes = {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 
            //               47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97};

            bool isContinue = true;

            while (isContinue)
            {
                bool aValid = false, bValid = false;
                Console.WriteLine("Enter the first number:");
                while (!aValid)
                {
                    sa = Console.ReadLine();
                    try
                    {
                        a = Int32.Parse(sa);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0} is not a valid integer.", sa);
                    }
                    if (a < 1)
                        Console.WriteLine("Please enter a number greater than 1.");
                    else
                        aValid = true;
                }

                Console.WriteLine("Enter the second number:");
                while (!bValid)
                {
                    sb = Console.ReadLine();
                    try
                    {
                        b = Int32.Parse(sb);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0} is not a valid integer.", sb);
                    }
                    if (b < 1)
                        Console.WriteLine("Please enter a number greater than 1.");
                    else
                        bValid = true;

                }

                /////////////////////////// Brosche main code begins here: /////////////////////////////////////////////////

                // Calculate the prime factors of 'a' (the first number), add to a list, and output to Console:               
                List<int> aFactors = FactorCalculation.PrimeFactorer(a);                    // Method defined in the 'Methods' class
                Console.WriteLine("The prime factors of " + a + " are:");
                aFactors.ForEach(item => Console.Write(item + " "));
                Console.WriteLine();

                // Calculate the prime factors of 'b' (the second number), add to a list, and output to Console:
                List<int> bFactors = FactorCalculation.PrimeFactorer(b);
                Console.WriteLine("The prime factors of " + b + " are:");                
                bFactors.ForEach(item => Console.Write(item + " "));
                Console.WriteLine();

                // Determine the common factors of 'a' and 'b', populate them into a new list, and write to the console:
                Console.WriteLine("The common factors of " + a + " and " + b + " are:");
                List<int> cFactors = new List<int>();
                if (aFactors.Count <= bFactors.Count)                           // Evaluate common factors based on which list of primes is smaller.
                {
                    cFactors = FactorCalculation.CommonFactors(aFactors, bFactors);       // Method defined in the 'Methods' class
                }
                else
                {                                                           
                    cFactors = FactorCalculation.CommonFactors(bFactors, aFactors);
                }
                cFactors.ForEach(item => Console.Write(item + " "));
                Console.WriteLine();

                // Calculate the greatest common factor (GCF) of 'a' and 'b' based on the list of common factors.
                int GCF = FactorCalculation.GreatestCommonFactor(cFactors, a, b);         // Method defined in the 'Methods' class

                //Determine Least Common Denominator (LCD) from the GCF and common prime factors.
                FactorCalculation.LeastCommonDenominator(GCF, a, b);

                //Euclidian Algorithm
                Console.WriteLine("Do you want to repeat that GCF calculation using the Euclidean Algorithm? Y/N");
                string newLoop = Console.ReadLine();
                if (newLoop[0] == 'Y' || newLoop[0] == 'y')
                {
                    int euclid = FactorCalculation.EuclidsAlgo(a, b);
                    Console.WriteLine("The Euclidean GCF of " + a + " and " + b + " is: " + euclid);
                    isContinue = true;
                    Console.WriteLine();                    
                }
                else
                    isContinue = false;

                /////////////////////////////////// End of Brosche Code ///////////////////////////////////////

                Console.WriteLine("\nDo you want to continue? Y/N");
                newLoop = Console.ReadLine();
                if (newLoop[0] == 'Y' || newLoop[0] == 'y')
                {
                    Console.WriteLine();
                    isContinue = true;
                }
                else
                    isContinue = false;
            }
        }
    }
}
