using System;
using System.Collections.Generic;

namespace Helppad.Algorithms
{
    /// <summary>
    /// This class contains math algorithms.
    /// </summary>
    public class Math
    {
        /// <summary>
        /// This method returns the greatest common divisor of two numbers.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The greatest common divisor of the two numbers.</returns>
        public static int Gcd(int a, int b)
        {
            // Check if the numbers are equal.
            if (a == b)
            {
                return a;
            }

            // Check if the first number is greater than the second number.
            if (a > b)
            {
                // Swap the numbers.
                int temp = a;
                a = b;
                b = temp;
                
                // Recursively call the method.
                return Gcd(a, b);
            }

            // Check if the first number is divisible by the second number.
            if (a % b == 0)
            {
                return b;
            }

            // Recursively call the method.
            return Gcd(b, a % b);
        }

        /// <summary>
        /// This method returns the least common multiple of two numbers.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The least common multiple of the two numbers.</returns>
        public static int Lcm(int a, int b)
        {
            // Calculate the greatest common divisor.
            int gcd = Gcd(a, b);

            // Calculate the least common multiple.
            return (a * b) / gcd;
        }

        /// <summary>
        /// This method returns the factorial of a number.
        /// </summary>
        /// <param name="n">The number.</param>
        /// <returns>The factorial of the number.</returns>
        public static int Factorial(int n)
        {
            // Check if the number is equal to 0.
            if (n == 0)
            {
                return 1;
            }

            // Recursively call the method.
            return n * Factorial(n - 1);
        }

        /// <summary>
        /// This method returns the sum of all numbers from 1 to n.
        /// </summary>
        /// <param name="n">The number.</param>
        /// <returns>The sum of all numbers from 1 to n.</returns>
        public static int SumOfNumbers(int n)
        {
            // Check if the number is equal to 0.
            if (n == 0)
            {
                return 0;
            }

            // Recursively call the method.
            return n + SumOfNumbers(n - 1);
        }

        /// <summary>
        /// This method determines if a number is prime.
        /// </summary>
        /// <param name="n">The number.</param>
        /// <returns>True if the number is prime, false otherwise.</returns>
        public static bool IsPrime(int n)
        {
            // use iteration over 2, 3, 5, 7, ... to check if n is divisible by any of these
            for (int i = 2; i <= System.Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// This method takes two numbers, one is the target and other is the number to check if is power of the target.
        /// and returns true if the number is power of the target, false otherwise.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="n">The number to check if is power of the target.</param>
        /// <returns>True if the number is power of the target, false otherwise.</returns>
        public static bool IsPowerOf(int target, int n)
        {
            // Check if the number is equal to 0.
            if (n == 0)
            {
                return true;
            }

            // Check if the number is equal to the target.
            if (n == target)
            {
                return true;
            }

            // Check if the number is divisible by the target.
            if (n % target == 0)
            {
                // Recursively call the method.

                return IsPowerOf(target, n / target);
            }

            // Return false.
            return false;
        }
        
        /// <summary>
        /// Computes the nth Fibonacci number.
        /// </summary>
        /// <param name="n">The nth Fibonacci number.</param>
        /// <returns>The nth Fibonacci number.</returns>
        public static int Fibonacci(int n)
        {
            // Check if the number is equal to 0.
            if (n == 0)
            {
                return 0;
            }

            // Check if the number is equal to 1.
            if (n == 1)
            {
                return 1;
            }

            // Recursively call the method.
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        /// <summary>
        /// Computes the pascal triangle of a given size.
        /// </summary>
        /// <param name="size">The size of the triangle.</param>
        /// <returns>The pascal triangle of the given size.</returns>
        public static int[] PascalTriangle(int size)
        {
            var currentLine = new int[]{1};

            var currentLineSize = size + 1;

            for (int numIndex = 1; numIndex < currentLineSize; numIndex += 1) 
            {
                currentLine[numIndex] = (currentLine[numIndex - 1] * (size - numIndex + 1)) / numIndex;
            }

            return currentLine;
        }

        /// <summary>
        /// Get the last digit of a number.
        /// </summary>
        /// <param name="n">The number.</param>
        /// <returns>The last digit of the number.</returns>
        public static int LastDigit(int n)
        {
            return n % 9;
        }
    }
}