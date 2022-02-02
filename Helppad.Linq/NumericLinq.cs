using System.Collections.Generic;
using System.Linq;

namespace Helppad.Linq
{
    /// <summary>
    /// The set of the method to extend the numbers linq api.
    /// </summary>
    public static class NumericLinq
    {
        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<short> GreatherThan(this IEnumerable<short> enumerable, short target)
        {
            return enumerable.Where(n => n > target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<short> GreatherEqualThan(this IEnumerable<short> enumerable, short target)
        {
            return enumerable.Where(n => n >= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<short> LessThan(this IEnumerable<short> enumerable, short target)
        {
            return enumerable.Where(n => n < target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<short> LessEqualThan(this IEnumerable<short> enumerable, short target)
        {
            return enumerable.Where(n => n <= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="start"> The target number that start the range.</param>
        /// <param name="end"> The target number that ends the range.</param>
        /// <returns></returns>
        public static IEnumerable<short> InRange(this IEnumerable<short> enumerable, short start, short end)
        {
            return enumerable.Where(n => n <= end && n >= start);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="start"> The target number that start the range.</param>
        /// <param name="end"> The target number that ends the range.</param>
        /// <returns></returns>
        public static IEnumerable<short> InOut(this IEnumerable<short> enumerable, short start, short end)
        {
            return enumerable.Where(n => n > end && n < start);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<ushort> GreatherThan(this IEnumerable<ushort> enumerable, ushort target)
        {
            return enumerable.Where(n => n > target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<ushort> GreatherEqualThan(this IEnumerable<ushort> enumerable, ushort target)
        {
            return enumerable.Where(n => n >= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<ushort> LessThan(this IEnumerable<ushort> enumerable, ushort target)
        {
            return enumerable.Where(n => n < target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<ushort> LessEqualThan(this IEnumerable<ushort> enumerable, ushort target)
        {
            return enumerable.Where(n => n <= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="start"> The target number that start the range.</param>
        /// <param name="end"> The target number that ends the range.</param>
        /// <returns></returns>
        public static IEnumerable<ushort> InRange(this IEnumerable<ushort> enumerable, ushort start, ushort end)
        {
            return enumerable.Where(n => n <= end && n >= start);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="start"> The target number that start the range.</param>
        /// <param name="end"> The target number that ends the range.</param>
        /// <returns></returns>
        public static IEnumerable<ushort> InOut(this IEnumerable<ushort> enumerable, ushort start, ushort end)
        {
            return enumerable.Where(n => n > end && n < start);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<int> GreatherThan(this IEnumerable<int> enumerable, int target)
        {
            return enumerable.Where(n => n > target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<int> GreatherEqualThan(this IEnumerable<int> enumerable, int target)
        {
            return enumerable.Where(n => n >= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<int> LessThan(this IEnumerable<int> enumerable, int target)
        {
            return enumerable.Where(n => n < target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<int> LessEqualThan(this IEnumerable<int> enumerable, int target)
        {
            return enumerable.Where(n => n <= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="start"> The target number that start the range.</param>
        /// <param name="end"> The target number that ends the range.</param>
        /// <returns></returns>
        public static IEnumerable<int> InRange(this IEnumerable<int> enumerable, int start, int end)
        {
            return enumerable.Where(n => n <= end && n >= start);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="start"> The target number that start the range.</param>
        /// <param name="end"> The target number that ends the range.</param>
        /// <returns></returns>
        public static IEnumerable<int> InOut(this IEnumerable<int> enumerable, int start, int end)
        {
            return enumerable.Where(n => n > end && n < start);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<uint> GreatherThan(this IEnumerable<uint> enumerable, uint target)
        {
            return enumerable.Where(n => n > target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<uint> GreatherEqualThan(this IEnumerable<uint> enumerable, uint target)
        {
            return enumerable.Where(n => n >= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<uint> LessThan(this IEnumerable<uint> enumerable, uint target)
        {
            return enumerable.Where(n => n < target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<uint> LessEqualThan(this IEnumerable<uint> enumerable, uint target)
        {
            return enumerable.Where(n => n <= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="start"> The target number that start the range.</param>
        /// <param name="end"> The target number that ends the range.</param>
        /// <returns></returns>
        public static IEnumerable<uint> InRange(this IEnumerable<uint> enumerable, uint start, uint end)
        {
            return enumerable.Where(n => n <= end && n >= start);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="start"> The target number that start the range.</param>
        /// <param name="end"> The target number that ends the range.</param>
        /// <returns></returns>
        public static IEnumerable<uint> InOut(this IEnumerable<uint> enumerable, uint start, uint end)
        {
            return enumerable.Where(n => n > end && n < start);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<long> GreatherThan(this IEnumerable<long> enumerable, long target)
        {
            return enumerable.Where(n => n > target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<long> GreatherEqualThan(this IEnumerable<long> enumerable, long target)
        {
            return enumerable.Where(n => n >= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<long> LessThan(this IEnumerable<long> enumerable, long target)
        {
            return enumerable.Where(n => n < target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<long> LessEqualThan(this IEnumerable<long> enumerable, long target)
        {
            return enumerable.Where(n => n <= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="start"> The target number that start the range.</param>
        /// <param name="end"> The target number that ends the range.</param>
        /// <returns></returns>
        public static IEnumerable<long> InRange(this IEnumerable<long> enumerable, long start, long end)
        {
            return enumerable.Where(n => n <= end && n >= start);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="start"> The target number that start the range.</param>
        /// <param name="end"> The target number that ends the range.</param>
        /// <returns></returns>
        public static IEnumerable<long> InOut(this IEnumerable<long> enumerable, long start, long end)
        {
            return enumerable.Where(n => n > end && n < start);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<ulong> GreatherThan(this IEnumerable<ulong> enumerable, ulong target)
        {
            return enumerable.Where(n => n > target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<ulong> GreatherEqualThan(this IEnumerable<ulong> enumerable, ulong target)
        {
            return enumerable.Where(n => n >= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<ulong> LessThan(this IEnumerable<ulong> enumerable, ulong target)
        {
            return enumerable.Where(n => n < target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<ulong> LessEqualThan(this IEnumerable<ulong> enumerable, ulong target)
        {
            return enumerable.Where(n => n <= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="start"> The target number that start the range.</param>
        /// <param name="end"> The target number that ends the range.</param>
        /// <returns></returns>
        public static IEnumerable<ulong> InRange(this IEnumerable<ulong> enumerable, ulong start, ulong end)
        {
            return enumerable.Where(n => n <= end && n >= start);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="start"> The target number that start the range.</param>
        /// <param name="end"> The target number that ends the range.</param>
        /// <returns></returns>
        public static IEnumerable<ulong> InOut(this IEnumerable<ulong> enumerable, ulong start, ulong end)
        {
            return enumerable.Where(n => n > end && n < start);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<float> GreatherThan(this IEnumerable<float> enumerable, float target)
        {
            return enumerable.Where(n => n > target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<float> GreatherEqualThan(this IEnumerable<float> enumerable, float target)
        {
            return enumerable.Where(n => n >= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<float> LessThan(this IEnumerable<float> enumerable, float target)
        {
            return enumerable.Where(n => n < target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<float> LessEqualThan(this IEnumerable<float> enumerable, float target)
        {
            return enumerable.Where(n => n <= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="start"> The target number that start the range.</param>
        /// <param name="end"> The target number that ends the range.</param>
        /// <returns></returns>
        public static IEnumerable<float> InRange(this IEnumerable<float> enumerable, float start, float end)
        {
            return enumerable.Where(n => n <= end && n >= start);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="start"> The target number that start the range.</param>
        /// <param name="end"> The target number that ends the range.</param>
        /// <returns></returns>
        public static IEnumerable<float> InOut(this IEnumerable<float> enumerable, float start, float end)
        {
            return enumerable.Where(n => n > end && n < start);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<double> GreatherThan(this IEnumerable<double> enumerable, double target)
        {
            return enumerable.Where(n => n > target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<double> GreatherEqualThan(this IEnumerable<double> enumerable, double target)
        {
            return enumerable.Where(n => n >= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<double> LessThan(this IEnumerable<double> enumerable, double target)
        {
            return enumerable.Where(n => n < target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<double> LessEqualThan(this IEnumerable<double> enumerable, double target)
        {
            return enumerable.Where(n => n <= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="start"> The target number that start the range.</param>
        /// <param name="end"> The target number that ends the range.</param>
        /// <returns></returns>
        public static IEnumerable<double> InRange(this IEnumerable<double> enumerable, double start, double end)
        {
            return enumerable.Where(n => n <= end && n >= start);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="start"> The target number that start the range.</param>
        /// <param name="end"> The target number that ends the range.</param>
        /// <returns></returns>
        public static IEnumerable<double> InOut(this IEnumerable<double> enumerable, double start, double end)
        {
            return enumerable.Where(n => n > end && n < start);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<decimal> GreatherThan(this IEnumerable<decimal> enumerable, decimal target)
        {
            return enumerable.Where(n => n > target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<decimal> GreatherEqualThan(this IEnumerable<decimal> enumerable, decimal target)
        {
            return enumerable.Where(n => n >= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<decimal> LessThan(this IEnumerable<decimal> enumerable, decimal target)
        {
            return enumerable.Where(n => n < target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<decimal> LessEqualThan(this IEnumerable<decimal> enumerable, decimal target)
        {
            return enumerable.Where(n => n <= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="start"> The target number that start the range.</param>
        /// <param name="end"> The target number that ends the range.</param>
        /// <returns></returns>
        public static IEnumerable<decimal> InRange(this IEnumerable<decimal> enumerable, decimal start, decimal end)
        {
            return enumerable.Where(n => n <= end && n >= start);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="start"> The target number that start the range.</param>
        /// <param name="end"> The target number that ends the range.</param>
        /// <returns></returns>
        public static IEnumerable<decimal> InOut(this IEnumerable<decimal> enumerable, decimal start, decimal end)
        {
            return enumerable.Where(n => n > end && n < start);
        }
    }
}
