﻿using System;
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
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<short> GreatherThan(this IEnumerable<short> enumerable, short target)
        {
            return enumerable.Where(n => n > target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<short> GreatherEqualThan(this IEnumerable<short> enumerable, short target)
        {
            return enumerable.Where(n => n >= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<short> LessThan(this IEnumerable<short> enumerable, short target)
        {
            return enumerable.Where(n => n < target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<short> LessEqualThan(this IEnumerable<short> enumerable, short target)
        {
            return enumerable.Where(n => n <= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
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
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
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
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<ushort> GreatherThan(this IEnumerable<ushort> enumerable, ushort target)
        {
            return enumerable.Where(n => n > target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<ushort> GreatherEqualThan(this IEnumerable<ushort> enumerable, ushort target)
        {
            return enumerable.Where(n => n >= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<ushort> LessThan(this IEnumerable<ushort> enumerable, ushort target)
        {
            return enumerable.Where(n => n < target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<ushort> LessEqualThan(this IEnumerable<ushort> enumerable, ushort target)
        {
            return enumerable.Where(n => n <= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
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
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
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
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<int> GreatherThan(this IEnumerable<int> enumerable, int target)
        {
            return enumerable.Where(n => n > target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<int> GreatherEqualThan(this IEnumerable<int> enumerable, int target)
        {
            return enumerable.Where(n => n >= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<int> LessThan(this IEnumerable<int> enumerable, int target)
        {
            return enumerable.Where(n => n < target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<int> LessEqualThan(this IEnumerable<int> enumerable, int target)
        {
            return enumerable.Where(n => n <= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
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
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
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
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<uint> GreatherThan(this IEnumerable<uint> enumerable, uint target)
        {
            return enumerable.Where(n => n > target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<uint> GreatherEqualThan(this IEnumerable<uint> enumerable, uint target)
        {
            return enumerable.Where(n => n >= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<uint> LessThan(this IEnumerable<uint> enumerable, uint target)
        {
            return enumerable.Where(n => n < target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<uint> LessEqualThan(this IEnumerable<uint> enumerable, uint target)
        {
            return enumerable.Where(n => n <= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
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
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
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
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<long> GreatherThan(this IEnumerable<long> enumerable, long target)
        {
            return enumerable.Where(n => n > target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<long> GreatherEqualThan(this IEnumerable<long> enumerable, long target)
        {
            return enumerable.Where(n => n >= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<long> LessThan(this IEnumerable<long> enumerable, long target)
        {
            return enumerable.Where(n => n < target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<long> LessEqualThan(this IEnumerable<long> enumerable, long target)
        {
            return enumerable.Where(n => n <= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
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
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
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
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<ulong> GreatherThan(this IEnumerable<ulong> enumerable, ulong target)
        {
            return enumerable.Where(n => n > target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<ulong> GreatherEqualThan(this IEnumerable<ulong> enumerable, ulong target)
        {
            return enumerable.Where(n => n >= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<ulong> LessThan(this IEnumerable<ulong> enumerable, ulong target)
        {
            return enumerable.Where(n => n < target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<ulong> LessEqualThan(this IEnumerable<ulong> enumerable, ulong target)
        {
            return enumerable.Where(n => n <= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
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
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
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
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<float> GreatherThan(this IEnumerable<float> enumerable, float target)
        {
            return enumerable.Where(n => n > target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<float> GreatherEqualThan(this IEnumerable<float> enumerable, float target)
        {
            return enumerable.Where(n => n >= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<float> LessThan(this IEnumerable<float> enumerable, float target)
        {
            return enumerable.Where(n => n < target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<float> LessEqualThan(this IEnumerable<float> enumerable, float target)
        {
            return enumerable.Where(n => n <= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
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
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
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
        /// Filter the float value if is Nan value.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<float> WhereIsNan(this IEnumerable<float> enumerable)
        {
            return enumerable.Where(n => float.IsNaN(n));
        }

        /// <summary>
        /// Filter the float value if is Infinite number.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<float> WhereIsInfinite(this IEnumerable<float> enumerable)
        {
            return enumerable.Where(n => float.IsInfinity(n));
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<double> GreatherThan(this IEnumerable<double> enumerable, double target)
        {
            return enumerable.Where(n => n > target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<double> GreatherEqualThan(this IEnumerable<double> enumerable, double target)
        {
            return enumerable.Where(n => n >= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<double> LessThan(this IEnumerable<double> enumerable, double target)
        {
            return enumerable.Where(n => n < target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<double> LessEqualThan(this IEnumerable<double> enumerable, double target)
        {
            return enumerable.Where(n => n <= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
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
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
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
        /// Filter the double value if is Nan value.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<double> WhereIsNan(this IEnumerable<double> enumerable)
        {
            return enumerable.Where(n => double.IsNaN(n));
        }

        /// <summary>
        /// Filter the double value if is Infinite number.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<double> WhereIsInfinite(this IEnumerable<double> enumerable)
        {
            return enumerable.Where(n => double.IsInfinity(n));
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<decimal> GreatherThan(this IEnumerable<decimal> enumerable, decimal target)
        {
            return enumerable.Where(n => n > target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<decimal> GreatherEqualThan(this IEnumerable<decimal> enumerable, decimal target)
        {
            return enumerable.Where(n => n >= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<decimal> LessThan(this IEnumerable<decimal> enumerable, decimal target)
        {
            return enumerable.Where(n => n < target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="target"> The target number that uses the operand.</param>
        /// <returns></returns>
        public static IEnumerable<decimal> LessEqualThan(this IEnumerable<decimal> enumerable, decimal target)
        {
            return enumerable.Where(n => n <= target);
        }

        /// <summary>
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
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
        /// Filter the numeric sequence enumerable enumerable by comparer operand. 
        /// </summary>
        /// <param name="enumerable"> The target numeric that recive the operand filter.</param>
        /// <param name="start"> The target number that start the range.</param>
        /// <param name="end"> The target number that ends the range.</param>
        /// <returns></returns>
        public static IEnumerable<decimal> InOut(this IEnumerable<decimal> enumerable, decimal start, decimal end)
        {
            return enumerable.Where(n => n > end && n < start);
        }

        /// <summary>
        /// Computes the median of a sequence enumerable of int values.
        /// </summary>
        /// <param name="source">A sequence enumerable of int values to calculate the median of.</param>
        /// <returns>The median of the sequence enumerable of values.</returns>
        public static double Median(this IEnumerable<int> source)
        {
            Review.NotNullArgument(source);

            var sortedList = (from number in source
                              orderby number
                              select (double)number).ToList();

            var count = sortedList.Count;
            int itemIndex = count / 2;

            if (count % 2 == 0)
            {
                // Even number of items.
                return (sortedList[itemIndex] + sortedList[itemIndex - 1]) / (double)2;
            }

            // Odd number of items.
            return sortedList[itemIndex];
        }

        /// <summary>
        /// Computes the median of a sequence enumerable of int values that are obtained
        /// by invoking a transform function on each element of the input sequence enumerable.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence enumerable of values to calculate the median of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The median of the sequence enumerable of values.</returns>
        public static double Median<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            Review.NotNullArgument(source);
            Review.NotNullArgument(selector);

            return source.Select(selector).Median();
        }

        /// <summary>
        /// Computes the median of a sequence enumerable of long values.
        /// </summary>
        /// <param name="source">A sequence enumerable of long values to calculate the median of.</param>
        /// <returns>The median of the sequence enumerable of values.</returns>
        public static double Median(this IEnumerable<long> source)
        {
            Review.NotNullArgument(source);

            var sortedList = (from number in source
                              orderby number
                              select (double)number).ToList();

            var count = sortedList.Count;
            int itemIndex = count / 2;

            if (count % 2 == 0)
            {
                // Even number of items.
                return (sortedList[itemIndex] + sortedList[itemIndex - 1]) / 2;
            }

            // Odd number of items.
            return sortedList[itemIndex];
        }

        /// <summary>
        /// Computes the median of a sequence enumerable of long values that are obtained
        /// by invoking a transform function on each element of the input sequence enumerable.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence enumerable of values to calculate the median of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The median of the sequence enumerable of values.</returns>
        public static double Median<TSource>(this IEnumerable<TSource> source, Func<TSource, long> selector)
        {
            Review.NotNullArgument(source);
            Review.NotNullArgument(selector);

            return source.Select(selector).Median();
        }

        /// <summary>
        /// Computes the median of a sequence enumerable of decimal values.
        /// </summary>
        /// <param name="source">A sequence enumerable of decimal values to calculate the median of.</param>
        /// <returns>The median of the sequence enumerable of values.</returns>
        public static decimal Median(this IEnumerable<decimal> source)
        {
            Review.NotNullArgument(source);

            var sortedList = (from number in source
                              orderby number
                              select (decimal)number).ToList();

            var count = sortedList.Count;
            int itemIndex = count / 2;

            if (count % 2 == 0)
            {
                // Even number of items.
                return (sortedList[itemIndex] + sortedList[itemIndex - 1]) / (decimal)2;
            }

            // Odd number of items.
            return sortedList[itemIndex];
        }

        /// <summary>
        /// Computes the median of a sequence enumerable of decimal values that are obtained
        /// by invoking a transform function on each element of the input sequence enumerable.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence enumerable of values to calculate the median of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The median of the sequence enumerable of values.</returns>
        public static decimal Median<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            Review.NotNullArgument(source);
            Review.NotNullArgument(selector);

            return source.Select(selector).Median();
        }

        /// <summary>
        /// Computes the median of a sequence enumerable of float values.
        /// </summary>
        /// <param name="source">A sequence enumerable of float values to calculate the median of.</param>
        /// <returns>The median of the sequence enumerable of values.</returns>
        public static float Median(this IEnumerable<float> source)
        {
            Review.NotNullArgument(source);

            var sortedList = (from number in source
                              orderby number
                              select (float)number).ToList();

            var count = sortedList.Count;
            int itemIndex = count / 2;

            if (count % 2 == 0)
            {
                // Even number of items.
                return (sortedList[itemIndex] + sortedList[itemIndex - 1]) / (float)2;
            }

            // Odd number of items.
            return sortedList[itemIndex];
        }

        /// <summary>
        /// Computes the median of a sequence enumerable of nullable float values that are obtained
        /// by invoking a transform function on each element of the input sequence enumerable.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence enumerable of values to calculate the median of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The median of the sequence enumerable of values.</returns>
        public static float? Median<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
        {
            Review.NotNullArgument(source);
            Review.NotNullArgument(selector);

            return source.Select(selector).Median();
        }

        /// <summary>
        /// Computes the median of a sequence enumerable of double values.
        /// </summary>
        /// <param name="source">A sequence enumerable of double values to calculate the median of.</param>
        /// <returns>The median of the sequence enumerable of values.</returns>
        public static double Median(this IEnumerable<double> source)
        {
            Review.NotNullArgument(source);

            var sortedList = (from number in source
                              orderby number
                              select (double)number).ToList();

            var count = sortedList.Count;
            int itemIndex = count / 2;

            if (count % 2 == 0)
            {
                // Even number of items.
                return (sortedList[itemIndex] + sortedList[itemIndex - 1]) / (double)2;
            }

            // Odd number of items.
            return sortedList[itemIndex];
        }

        /// <summary>
        /// Computes the median of a sequence enumerable of nullable double values that are obtained
        /// by invoking a transform function on each element of the input sequence enumerable.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence enumerable of values to calculate the median of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The median of the sequence enumerable of values.</returns>
        public static double Median<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            Review.NotNullArgument(source);
            Review.NotNullArgument(selector);

            return source.Select(selector).Median();
        }
    }
}