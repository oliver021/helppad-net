using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Helppad
{
    /// <summary>
    /// The review is a set of methods to test some conditions
    /// </summary>
    public static class Review
    {
        /// <summary>
        /// Throw the null reference exception <see cref="NullReferenceException"/> if passed
        /// argument is null and put the message
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="NullReferenceException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NotNull(object value, string text)
        {
            if (value is null)
            {
                throw new NullReferenceException(text);
            }
        }

        /// <summary>
        /// Throw the null reference exception <see cref="ArgumentException"/> if passed
        /// argument is null and put the message.
        /// This is like <see cref="NotNull(object, string)"/> but throw the <see cref="ArgumentNullException"/>
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="ArgumentNullException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NotNullArgument(object value, string text = "")
        {
            if (value is null)
            {
                throw new ArgumentNullException(text);
            }
        }

        /// <summary>
        /// Throw the null reference exception <see cref="NullReferenceException"/> if passed
        /// argument is null and put the message.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NotNull<T>(object value, string text)
        where T : Exception
        {
            if (value is null)
            {
                // create instance
                throw (Exception) typeof(T).GetConstructor(new []{ typeof(string) }).Invoke(new[] { text });
            }
        }

        /// <summary>
        /// Throw the n exception <see cref="Exception"/> if passed
        /// argument is Nan and put the message.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NotNan(double value, string text)
        {
            if (value is double.NaN)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw the n exception <see cref="Exception"/> if passed
        /// argument is Nan and put the message
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NotNan<T>(double value, string text)
        where T : Exception
        {
            if (value is double.NaN)
            {
                // create instance
                throw (Exception)typeof(T).GetConstructor(new[] { typeof(string) }).Invoke(new[] { text });
            }
        }

        /// <summary>
        /// Throw the n exception <see cref="Exception"/> if passed
        /// argument is Nan and put the message
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NotNan(float value, string text)
        {
            if (value is float.NaN)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw the n exception <see cref="Exception"/> if passed
        /// argument is Nan and put the message
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NotNan<T>(float value, string text)
        where T : Exception
        {
            if (value is float.NaN)
            {
                // create instance
                throw (Exception)typeof(T).GetConstructor(new[] { typeof(string) }).Invoke(new[] { text });
            }
        }

        /// <summary>
        /// Throw the null reference exception <see cref="NullReferenceException"/> if passed
        /// argument is null and put the message
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="set">The basic set.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="NullReferenceException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NotIn(object value, IEnumerable<object> set, string text)
        {
            if (set.Where(x => x.Equals(value)).Any())
            {
                throw new NullReferenceException(text);
            }
        }

        /// <summary>
        /// Throw the null reference exception <see cref="NullReferenceException"/> if passed
        /// argument is null and put the message
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="set">The basic set.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NotIn<T>(object value, IEnumerable<object> set, string text)
        where T : Exception
        {
            if (set.Where(x => x.Equals(value)).Any())
            {
                // create instance
                throw (Exception)typeof(T).GetConstructor(new[] { typeof(string) }).Invoke(new[] { text });
            }
        }

        /// <summary>
        /// Throw the exception <see cref="Exception"/> if passed
        /// action return false
        /// </summary>
        /// <param name="action"></param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Success(Func<bool> action, string text)
        {
            if (action.Invoke())
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw the exception <see cref="InvalidOperationException"/> if passed
        /// action return false
        /// </summary>
        /// <param name="action"></param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SuccessOrInvalidOperation(Func<bool> action, string text)
        {
            if (action.Invoke())
            {
                throw new InvalidOperationException(text);
            }
        }

        /// <summary>
        /// Throw the exception <see cref="InvalidProgramException"/> if passed
        /// action return false
        /// </summary>
        /// <param name="action"></param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SuccessOrInvalidProgram(Func<bool> action, string text)
        {
            if (action.Invoke())
            {
                throw new InvalidProgramException(text);
            }
        }

        /// <summary>
        /// Throw the exception <see cref="FormatException"/> if passed
        /// action return false
        /// </summary>
        /// <param name="action"></param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SuccessOrBadFormat(Func<bool> action, string text)
        {
            if (action.Invoke())
            {
                throw new FormatException(text);
            }
        }

        /// <summary>
        /// Throw the exception <see cref="ApplicationException"/> if passed
        /// action return false
        /// </summary>
        /// <param name="action"></param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SuccessOrApplicationException(Func<bool> action, string text)
        {
            if (action.Invoke())
            {
                throw new ApplicationException(text);
            }
        }

        /// <summary>
        /// Throw the null reference exception <see cref="NullReferenceException"/> if passed
        /// argument is null and put the message
        /// </summary>
        /// <param name="action"></param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Success<T>(Func<bool> action, string text)
        where T : Exception
        {
            if (action.Invoke())
            {
                // create instance
                throw (Exception)typeof(T).GetConstructor(new[] { typeof(string) }).Invoke(new[] { text });
            }
        }

        /// <summary>
        /// Throw the exception <see cref="Exception"/> if passed
        /// argument is false
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ThrowIf(bool value, string text)
        {
            if (value)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw the null reference exception passed as argument type if passed
        /// argument is false
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ThrowIf<T>(bool value, string text)
        where T : Exception
        {
            if (value)
            {
                // create instance
                throw (Exception)typeof(T).GetConstructor(new[] { typeof(string) }).Invoke(new[] { text });
            }
        }

        /// <summary>
        /// Throw an argument exception if passed
        /// argument that equal to compare and put the message
        /// </summary>
        /// <param name="condition">Condition that should be true.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="ArgumentException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void CheckArgument(bool condition, string text = "")
        {
            if (condition)
            {
                throw new ArgumentException(text);
            }
        }

        /// <summary>
        /// Throw an exception if passed
        /// argument that equal to compare and put the message
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="compare">The target value to compare.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NotBe(object value, object compare, string text)
        {
            if (value.Equals(compare))
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if passed
        /// argument that equal to compare and put the message
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="compare">The target value to compare.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NotBe<T>(object value, object compare, string text)
        where T : Exception
        {
            if (value.Equals(compare))
            {
                // create instance
                throw (Exception)typeof(T).GetConstructor(new[] { typeof(string) }).Invoke(new[] { text });
            }
        }

        /// <summary>
        /// Throw an exception if passed
        /// enumerable argument not pass the test
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="test">The target test to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Are<T>(T[] value, Predicate<T> test, string text)
        {
            if (value.All(x => test.Invoke(x)) is false)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less then zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NonNegative(int value, string text)
        {
            if (value < 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less then zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NonNegative(decimal value, string text)
        {
            if (value < 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less then zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NonNegative(sbyte value, string text)
        {
            if (value < 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less then zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NonNegative(short value, string text)
        {
            if (value < 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less then zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NonNegative(long value, string text)
        {
            if (value < 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less then zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NonNegative(float value, string text)
        {
            if (value < 0)
            {
                throw new Exception(text);
            }
        }


        /// <summary>
        /// Throw an exception if the number is less then zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NonNegative(double value, string text)
        {
            if (value < 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less then zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NonZero(int value, string text)
        {
            if (value != 0)
            {
                throw new Exception(text);
            }
        }


        /// <summary>
        /// Throw an exception if the number is less then zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NonZero(uint value, string text)
        {
            if (value != 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less then zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NonZero(decimal value, string text)
        {
            if (value != 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less then zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NonZero(sbyte value, string text)
        {
            if (value != 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less then zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NonZero(short value, string text)
        {
            if (value != 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less then zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NonZero(byte value, string text)
        {
            if (value != 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less then zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NonZero(ushort value, string text)
        {
            if (value != 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less then zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NonZero(ulong value, string text)
        {
            if (value != 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less then zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NonZero(long value, string text)
        {
            if (value != 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less then zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NonZero(float value, string text)
        {
            if (value != 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less then zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void NonZero(double value, string text)
        {
            if (value != 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less than or equal to zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ShouldBePositive(int value, string text)
        {
            if (value > 0)
            {
                throw new Exception(text);
            }
        }


        /// <summary>
        /// Throw an exception if the number is less than or equal to zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ShouldBePositive(uint value, string text)
        {
            if (value != 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less than or equal to zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ShouldBePositive(decimal value, string text)
        {
            if (value != 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less than or equal to zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ShouldBePositive(sbyte value, string text)
        {
            if (value != 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less than or equal to zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ShouldBePositive(short value, string text)
        {
            if (value != 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less than or equal to zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ShouldBePositive(byte value, string text)
        {
            if (value != 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less than or equal to zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ShouldBePositive(ushort value, string text)
        {
            if (value != 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less than or equal to zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ShouldBePositive(ulong value, string text)
        {
            if (value != 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less than or equal to zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ShouldBePositive(long value, string text)
        {
            if (value != 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less than or equal to zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ShouldBePositive(float value, string text)
        {
            if (value != 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw an exception if the number is less than or equal to zero.
        /// </summary>
        /// <param name="value">The target value to evaluate base on condition.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ShouldBePositive(double value, string text)
        {
            if (value != 0)
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// If the target is null, empty or white space only then the throw Exception.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RequireText(string target, string text)
        {
            if (string.IsNullOrEmpty(target) || target.All(c => char.IsWhiteSpace(c)))
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// If the target is null, empty or white space only then the throw 
        /// the <see cref="FormatException"/>
        /// </summary>
        /// <param name="target"></param>
        /// <param name="regex"></param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="FormatException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RequireFormat(string target, string regex, string text)
        {
            if (Regex.IsMatch(target, regex) is false)
            {
                throw new FormatException(text);
            }
        }

        /// <summary>
        /// If the target is null, empty or white space only then the throw 
        /// the <see cref="FormatException"/>
        /// </summary>
        /// <param name="target"></param>
        /// <param name="regex"></param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="FormatException"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RequireFormat(string target, Regex regex, string text)
        {
            if (regex.IsMatch(target) is false)
            {
                throw new FormatException(text);
            }
        }

        /// <summary>
        /// Throw a exception if the datetime is zero or equivalent <see cref="DateTime.MinValue"/>
        /// </summary>
        /// <param name="date"></param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void DatetimeNonZero(DateTime date, string text)
        {
            if (date.Equals(DateTime.MinValue))
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw a exception if the datetime is zero or equivalent <see cref="TimeSpan.MinValue"/>
        /// </summary>
        /// <param name="date"></param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TimespanNonZero(TimeSpan date, string text)
        {
            if (date.Equals(TimeSpan.MinValue))
            {
                throw new Exception(text);
            }
        }

        /// <summary>
        /// Throw a exception of <see cref="ArgumentOutOfRangeException"/> when
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="length"></param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RequireLength(Array arr, int length, string text)
        {
            if (arr.Length >= length)
            {
                throw new ArgumentOutOfRangeException(text);
            }
        }

        /// <summary>
        /// Throw a exception of <see cref="ArgumentOutOfRangeException"/> when the enuemrable is empty.
        /// </summary>
        /// <param name="enumerable">The target enuemrable to check.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.The message to put in the exception.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void CheckEmpty(IEnumerable enumerable, string text)
        {
            if (enumerable.GetEnumerator().MoveNext() is false)
            {
                throw new ArgumentException(text);
            }
        }

        /// <summary>
        /// Throw a exception of <see cref="ArgumentOutOfRangeException"/> when the enuemrable is empty.
        /// </summary>
        /// <param name="enumerable">The target enuemrable to check.</param>
        /// <param name="text">The text to put in the exception in case it should be thrown.The message to put in the exception.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void CheckEmpty<TException>(IEnumerable enumerable, string text)
            where TException: Exception
        {
            if (enumerable.GetEnumerator().MoveNext() is false)
            {
                throw (Exception)typeof(TException).GetConstructor(new[] { typeof(string) }).Invoke(new[] { text });
            }
        }

        /// <summary>
        /// Throw a exception if the datetime is zero or equivalent <see cref="DateTime.MinValue"/>
        /// </summary>
        /// <param name="date"></param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        /// <exception cref="Exception">The exception to be thrown if the condition fails.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void DatetimeNonZero<T>(DateTime date, string text)
            where T : Exception
        {
            if (date.Equals(DateTime.MinValue))
            {
                // create instance
                throw (Exception)typeof(T).GetConstructor(new[] { typeof(string) }).Invoke(new[] { text });
            }
        }

        /// <summary>
        /// Throw a exception if the datetime is zero or equivalent <see cref="DateTime.MinValue"/>
        /// </summary>
        /// <param name="time"></param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TimespanNonZero<T>(TimeSpan time, string text)
            where T : Exception
        {
            if (time.Equals(TimeSpan.MinValue))
            {
                // create instance
                throw (Exception)typeof(T).GetConstructor(new[] { typeof(string) }).Invoke(new[] { text });
            }
        }

        /// <summary>
        /// Throw a exception if the datetime is zero or equivalent <see cref="DateTime.MinValue"/>
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="length"></param>
        /// <param name="text">The text to put in the exception in case it should be thrown.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RequireLength<T>(Array arr, int length, string text)
            where T : Exception
        {
            if (arr.Length >= length)
            {
                // create instance
                throw (Exception)typeof(T).GetConstructor(new[] { typeof(string) }).Invoke(new[] { text });
            }
        }
    }
}
