using System;
using System.Collections.Generic;
using System.Text;

namespace Helppad
{
    /// <summary>
    /// A helper collection to resolve severals math taks
    /// </summary>
    public static class XMath
    {
        /// <summary>
        /// method named SolveLinearEquation that takes three parameters:
        /// a, b, and c, which represent the coefficients of a linear equation
        /// in the form ax + b = c. The method returns a tuple containing the solution 
        /// of the equation, or null if the equation has no solution.
        /// 
        /// This method first checks if the equation is solvable,
        /// and returns null if it is not. If the equation is solvable,
        /// it calculates the solution(s) using the provided 
        /// coefficients and returns a tuple containing the solution(s).
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static (double? x, double? y)? SolveLinearEquation(double a, double b, double c)
        {
            // Check if the equation is solvable
            if (a == 0 && b == 0)
            {
                // The equation has no solution
                return null;
            }

            if (a == 0)
            {
                // The equation has one solution
                double y = c / b;
                return (null, y);
            }
            else
            {
                // The equation has two solutions
                double x = (c - b) / a;
                double y = c / b;
                return (x, y);
            }
        }

        /// <summary>
        /// method named SolveQuadraticEquation that takes three parameters:
        /// a, b, and c, which represent the coefficients of a quadratic 
        /// equation in the form ax^2 + bx + c = 0. The method returns a
        /// tuple containing the solutions of the 
        /// equation, or null if the equation has no real solutions.
        /// 
        /// This method first calculates the discriminant of the equation,
        /// which is the value under the square root in the quadratic formula.
        /// If the discriminant is negative, the equation has no real solutions
        /// and the method returns null. If the discriminant is zero, the equation
        /// has one real solution and the method returns a tuple containing the
        /// solution. If the discriminant is positive, the equation has two real
        /// solutions and the method returns a tuple containing both solutions.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static (double? x1, double? x2)? SolveQuadraticEquation(double a, double b, double c)
        {
            // Calculate the discriminant
            double discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
            {
                // The equation has no real solutions
                return null;
            }

            if (discriminant == 0)
            {
                // The equation has one real solution
                double x = -b / (2 * a);
                return (x, null);
            }
            else
            {
                // The equation has two real solutions
                double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                return (x1, x2);
            }
        }

        /// <summary>
        /// This method takes an array of integers representing
        /// the coefficients of a polynomial equation, and returns
        /// a list of integers containing the solutions to the
        /// equation. If the equation has no solutions, the method
        /// returns an empty list. If the equation has one solution,
        /// the method returns a list containing that solution.
        /// </summary>
        /// <param name="coefficients">array coefficients</param>
        /// <returns></returns>
        public static List<int> SolvePolynomialEquation(int[] coefficients)
        {
            // Check the degree of the polynomial
            int degree = coefficients.Length - 1;
            if (degree < 1)
            {
                // The equation has no solutions
                return new List<int>();
            }
            if (degree == 1)
            {
                // The equation is linear, use the formula x = -c / b
                int x = -coefficients[0] / coefficients[1];
                return new List<int> { x };
            }
            else
            {
                // The equation is quadratic or higher, use the quadratic formula
                double a = coefficients[degree];
                double b = coefficients[degree - 1];
                double c = coefficients[degree - 2];
                double discriminant = b * b - 4 * a * c;
                if (discriminant < 0)
                {
                    // The equation has no real solutions
                    return new List<int>();
                }
                else if (discriminant == 0)
                {
                    // The equation has one real solution
                    int x = (int)(-b / (2 * a));
                    return new List<int> { x };
                }
                else
                {
                    // The equation has two real solutions
                    int x1 = (int)((-b + Math.Sqrt(discriminant)) / (2 * a));
                    int x2 = (int)((-b - Math.Sqrt(discriminant)) / (2 * a));
                    return new List<int> { x1, x2 };
                }

            }

        }

        /// <summary>
        /// This method checks if the sum of the angles is 180 degrees,
        /// which is a necessary condition for the triangle to be valid.
        /// It then checks if any of the angles is 90 degrees, which is
        /// a sufficient condition for the triangle to be a rectangle.
        /// If either of these conditions is not met,
        /// the method returns false. 
        /// Otherwise, it returns true.
        /// </summary>
        /// <param name="angle1"></param>
        /// <param name="angle2"></param>
        /// <param name="angle3"></param>
        /// <returns></returns>
        public static bool IsTriangleRectangle(int angle1, int angle2, int angle3)
        {
            // Check if the sum of the angles is 180 degrees
            if (angle1 + angle2 + angle3 != 180)
            {
                return false;
            }

            // Check if any of the angles is 90 degrees
            if (angle1 == 90 || angle2 == 90 || angle3 == 90)
            {
                return true;
            }

            // No angles are 90 degrees, so the triangle is not a rectangle
            return false;
        }

        /// <summary>
        /// This method first checks if the sum of the angles is 180 degrees.
        /// If it is not, it throws an exception.
        /// Otherwise, it calculates the lengths of the sides using the Law of Sines.
        /// 
        /// It is important to note that the Law of Sines only works 
        /// for triangles where the sum of the angles is 180 degrees.
        /// If the sum of the angles is not 180 degrees, the triangle is invalid and the
        /// Law of Sines cannot be used to calculate the side lengths.
        /// 
        /// The Law of Sines states that the ratio of the length of 
        /// a side of a triangle to the sine of the angle opposite that side is the
        /// same for all sides and angles in the triangle.
        /// </summary>
        /// <param name="angleA"></param>
        /// <param name="angleB"></param>
        /// <param name="angleC"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Tuple<double, double, double> CalculateTriangleSides(double angleA, double angleB, double angleC)
        {
            // Check if the sum of the angles is 180 degrees
            if (angleA + angleB + angleC != 180)
            {
                throw new ArgumentException("The sum of the angles must be 180 degrees.");
            }

            // Calculate the lengths of the sides using the Law of Sines
            double sideA = double.NaN;
            double sideB = double.NaN;
            double sideC = double.NaN;

            if (angleA != 0)
            {
                sideA = 1 / Math.Sin(angleA * Math.PI / 180);
            }
            if (angleB != 0)
            {
                sideB = 1 / Math.Sin(angleB * Math.PI / 180);
            }
            if (angleC != 0)
            {
                sideC = 1 / Math.Sin(angleC * Math.PI / 180);
            }

            // Return the side lengths
            return new Tuple<double, double, double>(sideA, sideB, sideC);
        }

        /// <summary>
        /// Simple method to resolve sigmoid function.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double CalculateSigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        /// <summary>
        /// Takes a string representing an arithmetic 
        /// expression and returns the result of evaluating the expression.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static double EvaluateExpression(string expression)
        {
            // Use a stack to evaluate the expression
            var stack = new Stack<double>();

            // Iterate through the characters in the expression
            for (int i = 0; i < expression.Length; i++)
            {
                // Get the current character
                char c = expression[i];

                // If the character is a digit, parse it as a double and push it onto the stack
                if (char.IsDigit(c))
                {
                    int j = i + 1;
                    while (j < expression.Length && (char.IsDigit(expression[j]) || expression[j] == '.'))
                    {
                        j++;
                    }

                    double value = double.Parse(expression.Substring(i, j - i));
                    stack.Push(value);
                    i = j - 1;
                }

                // If the character is an operator, pop the top two values from the stack,
                // perform the operation, and push the result back onto the stack
                else if (c == '+')
                {
                    double b = stack.Pop();
                    double a = stack.Pop();
                    stack.Push(a + b);
                }
                else if (c == '-')
                {
                    double b = stack.Pop();
                    double a = stack.Pop();
                    stack.Push(a - b);
                }
                else if (c == '*')
                {
                    double b = stack.Pop();
                    double a = stack.Pop();
                    stack.Push(a * b);
                }
                else if (c == '/')
                {
                    double b = stack.Pop();
                    double a = stack.Pop();
                    stack.Push(a / b);
                }
                else if (c == '^')
                {
                    double b = stack.Pop();
                    double a = stack.Pop();
                    stack.Push(Math.Pow(a, b));
                }
            }

            // Return the result of the expression
            return stack.Pop();
        }

    }
}
