using System;
using System.Linq;

namespace Assignment1_S19
{
    class Program
    {
        public static void Main()
        {
            int a = 1, b = 15;
            printPrimeNumbers(a, b);

            int n1 = 5;
            double r1 = getSeriesResult(n1);
            Console.WriteLine("The sum of the series is: " + r1);
           

            long n2 = 15;
            long r2 = decimalToBinary(n2);
            Console.WriteLine("Binary conversion of the decimal number " + n2 + " is: " + r2);


            long n3 = 1111;
            long r3 = binaryToDecimal(n3);
            Console.WriteLine("Decimal conversion of the binary number " + n3 + " is: " + r3);
            

            int n4 = 5;
            printTriangle(n4);

            int[] arr = new int[] { 1, 2, 3, 2, 2, 1, 3, 2 };
            computeFrequency(arr);

            // write your self-reflection here as a comment
            /* By doing this assignment it helped me to revise the knowldge on basic algorithms and also the necessity of using "try...catch" in our code,
             * also the use of different data types. */

        }

        public static void printPrimeNumbers(int x, int y)
        {
            /* run the loop starting from x and till y and find check if each number is prime or not using isPrime() function and print the result */
            try
            {
                Console.Write("The prime numbers between {0} and {1} are : \n", x, y);
                //loop for iterating through each number between the range
                for (int num = x; num <= y; num++)
                {
                    //Method for checking if a number is prime or not
                    isPrime(num);
            }
                Console.WriteLine();

            }
            catch
            {
                Console.WriteLine("Exception occured while computing printPrimeNumbers()");
            }
            
        }
        
        public static double getSeriesResult(int n)
        {
            /* run the loop from 1 to n and find the corresponding factorial using the factorial function and divide it by i+1, and then multiply by the toggle variable
             * (term) to obtain the alternate + and - and atlast we use the math.round to round the result to 3 decimals */
            try
            {
               double term = 1;  //variable for doing the toggle 
               double res = 0;  //variable for storing the final result
               for(int i = 1; i <= n; i++)
                {
                   res += (factorial(i))*term / (i + 1);
                   term = term * (-1);  //toggling between - and +
                }

                return Math.Round(res,3);

            }
            catch
            {
                Console.WriteLine("Exception occured while computing getSeriesResult()");
            }

            return 0;
        }

        public static long decimalToBinary(long n)
        {
            /* We are diving the decimal by 2 during each iteration and the reminder is converted to string and concantinated with the output to 
             * obtain the required binary result and atlast it is converted to Int64*/
            try
            {
                
                long remainder;
                string result = string.Empty;
                while (n > 0)
                {
                    remainder = n % 2;
                    n /= 2;
                    result = remainder.ToString() + result; 
                    
                }
                return Convert.ToInt64(result);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing decimalToBinary()");
            }

            return 0;
        }

        public static int binaryToDecimal(long n)
        {
            /*logic for this function is to divide the binary by 10 each time the loop runs and multiply the 
            reminder with the base1 variable which is power of 2*/
            try
            {
                long num = n; 
                long dec_value = 0; //variable for storing the final decimal value

                int base1 = 1;  //variable for value of power of 2
                while (num > 0)
                {
                    long reminder = num % 10;
                    num = num / 10;

                    dec_value += reminder * base1;

                    base1 = base1 * 2; 
                }

                return Convert.ToInt32(dec_value);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing binaryToDecimal()");
            }

            return 0;
        }

        public static void printTriangle(int n)
        {
            try
            {
                int a, x;
                Console.WriteLine("Print paramid");
                for (int i = 1; i <= n; i++)
                {
                    //loop for putting the initial spaces
                    for (a = 1; a <= (n - i); a++)
                    {
                        Console.Write(" ");
                    }
                    //loop for printitng the required *'s till half 
                    for (x = 1; x <= i; x++)
                    {
                        Console.Write('*');
                    } 
                        
                    //loop for printing the required rest of the *'s
                    for (x = (i - 1); x >= 1; x--)
                    {
                        Console.Write('*');
                    }
                 Console.WriteLine();
                    
                }
                
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }
        }

        public static void computeFrequency(int[] a)
        {
            /* this I have done using linq, by using the groupby function and then sorting and selecting the required output */
            try
            {
                //grouping using linq
                var output = a
                    .GroupBy(val => val)
                    .OrderBy(val => val.Key)
                    .Select(val => new { value = val.Key, count = val.Count() });
                Console.WriteLine(String.Format("{0,5} {1,8}", "Number", "Frequency"));
                foreach (var item in output)
                {
                    Console.WriteLine(String.Format("|{0,5}|{1,8}|", item.value.ToString(), item.count.ToString()));

                }

                Console.ReadLine();

            }
            catch
            {
                Console.WriteLine("Exception occured while computing computeFrequency()");
            }
        }
        //function for finding the factorial
        public static int factorial(int n)
        {
            /* run the loop from 1 to n and keep on multiplying the result by i to obtain the factorial of n */
            try
            {
                int result = n;

                for (int i = 1; i < n; i++)
                {
                    result = result * i;
                }
                return result;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing factorial");
            }
            return 0;
        }
        //function for checking if a number is prime or not
        public static void isPrime(int n)
        {
            /* we divide n by 2 to n/2 and see if the reminder becomes 0 or not and accordingly we increase the counter and in the end if the counter
             * value is 0 and if the number n is not 1 then it is a prime number */
            try
            {
                int i, ctr;
                ctr = 0;
                if (n > 0)
                {
                    for (i = 2; i <= n / 2; i++)
                    {
                        if (n % i == 0)
                        {
                            ctr++;
                            break;
                        }
                    }
                    if (ctr == 0 && n != 1)
                    {
                        Console.Write("{0} ", n);
                    }

                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing isPrime");
            }

        }
    }
}

