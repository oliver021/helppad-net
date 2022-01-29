using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Helppad
{
    /// <summary>
    /// Simple delegate for method <see cref="SimpleToolkit.Catch"/>
    /// </summary>
    /// <typeparam name="TCatch"></typeparam>
    /// <param name="catchedAction"></param>
    /// <param name="catch"></param>
    public delegate void CatchedAction<TCatch>(CatchedAction<TCatch> catchedAction, TCatch @catch);

    /// <summary>
    /// The basic toolkit that provide some helpers.
    /// </summary>
    public static class SimpleToolkit
    {
        /// <summary>
        /// Random shared insatnce.
        /// </summary>
        static public Random SharedRandom { get; } = new Random();

        /// <summary>
        /// The hexdecimal char set.
        /// </summary>
        static public char[] HexChars { get; } = new char[] { 
            'a', 'b', 'c', 'd', 'e', 'f',
            '0', '1', '2', '3', '4', '5',
            '6', '7', '8', '9'
        };

        /// <summary>
        /// Create instance from passed type and arguments.
        /// Using the reflection method to build a instance of any type.
        /// </summary>
        /// <typeparam name="T">The target type to use.</typeparam>
        /// <param name="entries"></param>
        /// <returns></returns>
        public static T Instance<T>(params object[] entries)
        {
            ConstructorInfo construct = typeof(T).GetConstructor(entries.Select(x => x.GetType()).ToArray());
            if (construct is null)
            {
                throw new NotSupportedException();
            }
            return (T)construct.Invoke(entries);
        }

        /// <summary>
        ///  Try create instance from passed type and arguments.
        ///  Using the reflection method to build a instance of any type.
        /// </summary>
        /// <typeparam name="T">The target type to use.</typeparam>
        /// <param name="result"></param>
        /// <param name="entries"></param>
        /// <returns></returns>
        public static bool TryIntance<T>(out T result, object[] entries)
            where T: class
        {
            ConstructorInfo construct = typeof(T).GetConstructor(entries.Select(x => x.GetType()).ToArray());
            if (construct is null)
            {
                result = null;
                return false;
            }
            else
            {
                result = (T)construct.Invoke(entries);
                return true;
            }
        }

        /// <summary>
        /// Create an alternative or default value for an entry value using the lambda function.
        /// </summary>
        /// <typeparam name="T">The target type to use.</typeparam>
        /// <param name="value"></param>
        /// <param name="fallback"></param>
        /// <returns>The same value if not null or the value offer for fallback.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#nullable enable
        public static T FallbackValue<T>(T? value, Func<T> fallback)
#nullable disable
        {
            if (value is null)
            {
                return fallback.Invoke();
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Create and fill an array with passed arr values.
        /// Use the same array values to expand it.
        /// </summary>
        /// <typeparam name="T">The target type to use.</typeparam>
        /// <param name="arr">The array to expand.</param>
        /// <param name="count">The count to fill new aray positions.</param>
        /// <returns>A new array with new size and values.</returns>
        public static T[] FillArray<T>(T[] arr, int count)
        {
            var elms = new T[count];

            // fill
            for (int i = 0; i < count; i++)
            {
                elms[i] = arr[i % arr.Length];
            }

            return elms;
        }

        /// <summary>
        /// Create a new array with specific argument type and fill an array with passed arr values.
        /// </summary>
        /// <typeparam name="T">The target type to use.</typeparam>
        /// <param name="arr">The array values to fill.</param>
        /// <param name="count">The size to expand and fill new array.</param>
        /// <returns></returns>
        public static T[] FillArray<T>(T[][] arr, int count)
        {
            var elms = new T[count];

            // fill
            foreach (var item in arr)
            {
                for (int i = 0; i < count; i++)
                {
                    elms[i] = item[i % item.Length];
                }
            }

            return elms;
        }

        /// <summary>
        /// Make a random string from range '0' to 'z'
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string RandomString(int count)
        {
            return RandomString(count, '0', 'z');
        }

        /// <summary>
        /// Make a random string from char range passed and the specific size by argument count.
        /// The range chars is used to set a possibles char to include.
        /// The method use the Random .Net clas to generate string sequence.
        /// <param name="count">The size of the string.</param>
        /// <param name="rangeStart">Begin char range.</param>
        /// <param name="rangeEnd">Begin char range.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string RandomString(int count, char rangeStart, char rangeEnd)
        {
            return new string(Enumerable.Range(0, count).Select(x => GetRandomChar(rangeStart, rangeEnd)).ToArray());
        }

        /// <summary>
        /// Generate random from ranges
        /// </summary>
        /// <param name="rangeStart"></param>
        /// <param name="rangeEnd"></param>
        /// <returns></returns>
        private static char GetRandomChar(char rangeStart, char rangeEnd)
        {
            int start = Convert.ToInt32(rangeStart);
            int end = Convert.ToInt32(rangeEnd);
            return Convert.ToChar(SharedRandom.Next(start, end));
        }

        /// <summary>
        /// Make a random string from a array of chars
        /// </summary>
        /// <param name="count"></param>
        /// <param name="chars"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string RandomString(int count, char[] chars)
        {
            // from chars collection
            return new string(
                value: Enumerable.Range(0, count)
                .Select(x => chars[SharedRandom.Next(0, chars.Length - 1)])
                .ToArray()
            );
        }

        /// <summary>
        ///  Catch an exception and retry execute the fallback.
        /// </summary>
        /// <typeparam name="T">The target type to use.</typeparam>
        /// <param name="action"></param>
        /// <param name="fallback"></param>
        public static void Catch<T>(Action action, Action<T> fallback)
            where T: Exception
        {
            try
            {
                action.Invoke();
            }
            catch (Exception err) when(err is T catched)
            {
                fallback.Invoke(catched);
            }
        }

        /// <summary>
        /// Catch an exception and return the fallback.
        /// </summary>
        /// <typeparam name="T">The target type to use.</typeparam>
        /// <param name="action"></param>
        /// <param name="fallback"></param>
        public static T Catch<T>(Action action)
            where T : Exception
        {
            try
            {
                action.Invoke();
                return null;
            }
            catch (Exception err) when (err is T catched)
            {
                return (catched);
            }
        }

        /// <summary>
        /// Catch an exception and retry execute the same action but with exception instance included.
        /// Using this method to create resilent way to work
        /// </summary>
        /// <typeparam name="T">The target type to use.</typeparam>
        /// <param name="action"></param>
        public static void Catch<T>(CatchedAction<T> action)
            where T : Exception
        {
            try
            {
                action.Invoke(action,null);
            }
            catch (Exception err) when (err is T catched)
            {
                action.Invoke(action, catched);
            }
        }

        /// <summary>
        ///  Catch an exception and retry execute the fallback.
        ///  sing this method to create resilent way to work.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="fallback"></param>
        public static void Catch(Action action, Action<Exception> fallback)
        {
            Catch<Exception>(action, fallback);
        }

        /// <summary>
        /// Catch an exception and return the fallback.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="fallback"></param>
        public static Exception Catch(Action action)
        {
            try
            {
                action.Invoke();
                return null;
            }
            catch (Exception err)
            {
                return err;
            }
        }

        /// <summary>
        /// Catch an exception and retry execute the same action but with exception instance included.
        /// Using this method to create resilent way to work.
        /// </summary>
        /// <param name="action"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Catch(CatchedAction<Exception> action)
        {
            Catch<Exception>(action);
        }

        /// <summary>
        /// Iterate for an enumerable and catch if is throwed some error.
        /// Using this method to create resilent way to work.
        /// </summary>
        /// <typeparam name="T">The target type to use.</typeparam>
        /// <param name="sequence"></param>
        /// <param name="action"></param>
        /// <param name="fallback"></param>
        public static void CatchAndContinue<T>(IEnumerable<T> sequence, Action<T> action, Action<T, Exception> fallback)
        {
            foreach (var item in sequence)
            {
                try
                {
                    action.Invoke(item);
                }
                catch (Exception err)
                {

                    fallback.Invoke(item, err);
                }
            }
        }

        /// <summary>
        /// Iterate for an enumerable and catch if is throwed some error.
        /// Using this method to create resilent way to work.
        /// </summary>
        /// <typeparam name="T">The target type to use.</typeparam>
        /// <typeparam name="TExp"></typeparam>
        /// <param name="sequence"></param>
        /// <param name="action"></param>
        /// <param name="fallback"></param>
        public static void CatchAndContinue<T, TExp>(IEnumerable<T> sequence, Action<T> action, Action<T, TExp> fallback)
        {
            foreach (var item in sequence)
            {
                try
                {
                    action.Invoke(item);
                }
                catch (Exception err) when(err is TExp catched)
                {

                    fallback.Invoke(item, catched);
                }
            }
        } 

        /// <summary>
        /// Simple expand helper array.
        /// </summary>
        /// <typeparam name="T">The target type to use.</typeparam>
        /// <param name="arr"></param>
        /// <param name="arr2"></param>
        public static void Expand<T>(ref T[] arr, ref T[] arr2)
        {
            int initLen = arr.Length;
            Array.Resize(ref arr, arr2.Length);
            for (int i = 0; i < arr2.Length; i++)
            {
                arr[i + initLen] = arr2[0];
            }
        }

        /// <summary>
        /// Simple helper to define a condition for a cllection realationed with a value.
        /// </summary>
        /// <typeparam name="T">The target type to use.</typeparam>
        /// <param name="value"></param>
        /// <param name="set"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        public static bool Exists<T>(T value, IEnumerable<T> set, Func<T,T,bool> rule)
        {
            return set.Where(x => rule.Invoke(value,x)).Any();
        }

        #region ValueHandler

        /// <summary>
        /// Rotates a 4-bytes unsigned integer left by the specified number of bits.
        /// </summary>
        /// <param name="value">The <see cref="System.UInt32"/> to rotate.</param>
        /// <param name="rotation">The number of bits to rotate.</param>
        /// <returns>An <see cref="System.UInt32"/> value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint RotateLeft(uint value, int rotation)
        {
            rotation &= 0x1F;
            return (value << rotation) | (value >> (32 - rotation));
        }

        /// <summary>
        /// Rotates a 8-bytes unsigned integer left by the specified number of bits.
        /// </summary>
        /// <param name="value">The <see cref="System.UInt64"/> to rotate.</param>
        /// <param name="rotation">The number of bits to rotate.</param>
        /// <returns>An <see cref="System.UInt64"/> value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong RotateLeft(ulong value, int rotation)
        {
            rotation &= 0x3F;
            return (value << rotation) | (value >> (64 - rotation));
        }

        /// <summary>
        /// Rotates a 4-bytes unsigned integer right by the specified number of bits.
        /// </summary>
        /// <param name="value">The <see cref="System.UInt32"/> to rotate.</param>
        /// <param name="rotation">The number of bits to rotate.</param>
        /// <returns>An <see cref="System.UInt32"/> value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint RotateRight(uint value, int rotation)
        {
            rotation &= 0x1F;
            return (value >> rotation) | (value << (32 - rotation));
        }

        /// <summary>
        /// Rotates a 8-bytes unsigned integer right by the specified number of bits.
        /// </summary>
        /// <param name="value">The <see cref="System.UInt64"/> to rotate.</param>
        /// <param name="rotation">The number of bits to rotate.</param>
        /// <returns>An <see cref="System.UInt64"/> value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong RotateRight(ulong value, int rotation)
        {
            rotation &= 0x3F;
            return (value >> rotation) | (value << (64 - rotation));
        }

        /// <summary>
        /// Swaps the value of two 2-bytes unsigned integers.
        /// </summary>
        /// <param name="leftValue">The first <see cref="System.UInt16"/> is pass to right</param>
        /// <param name="rightValue">The second <see cref="System.UInt16"/> is pass to left</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(ref ushort leftValue, ref ushort rightValue)
        {
            ushort tmp = leftValue;
            leftValue = rightValue;
            rightValue = tmp;
        }

        /// <summary>
        /// Swaps the value of two 4-bytes unsigned integers.
        /// </summary>
        /// <param name="leftValue">The first <see cref="System.UInt32"/> is pass to right</param>
        /// <param name="rightValue">The second <see cref="System.UInt32"/> is pass to left</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(ref uint leftValue, ref uint rightValue)
        {
            uint tmp = leftValue;
            leftValue = rightValue;
            rightValue = tmp;
        }

        /// <summary>
        /// Swaps the value of two 8-bytes unsigned integers.
        /// </summary>
        /// <param name="leftValue">The first <see cref="System.UInt64"/> is pass to right</param>
        /// <param name="rightValue">The second <see cref="System.UInt64"/> is pass to left</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(ref ulong leftValue, ref ulong rightValue)
        {
            ulong tmp = leftValue;
            leftValue = rightValue;
            rightValue = tmp;
        }

        /// <summary>
        /// Swaps the value of two 2-bytes integers.
        /// </summary>
        /// <param name="leftValue">The first <see cref="System.Int16"/> is pass to right</param>
        /// <param name="rightValue">The second <see cref="System.Int16"/> is pass to left</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(ref short leftValue, ref short rightValue)
        {
            short tmp = leftValue;
            leftValue = rightValue;
            rightValue = tmp;
        }

        /// <summary>
        /// Swaps the value of two 4-bytes integers.
        /// </summary>
        /// <param name="leftValue">The first <see cref="System.Int32"/> is pass to right</param>
        /// <param name="rightValue">The second <see cref="System.Int32"/> is pass to left</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(ref int leftValue, ref int rightValue)
        {
            int tmp = leftValue;
            leftValue = rightValue;
            rightValue = tmp;
        }

        /// <summary>
        /// Swaps the value of two 8-bytes integers.
        /// </summary>
        /// <param name="leftValue">The first <see cref="System.Int64"/> is pass to right</param>
        /// <param name="rightValue">The second <see cref="System.Int64"/> is pass to left</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(ref long leftValue, ref long rightValue)
        {
            long tmp = leftValue;
            leftValue = rightValue;
            rightValue = tmp;
        }

        /// <summary>
        /// Swaps the value of single byte.
        /// </summary>
        /// <param name="leftValue">The first <see cref="System.Byte"/> is pass to right</param>
        /// <param name="rightValue">The second <see cref="System.Byte"/> is pass to left</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(ref byte leftValue, ref byte rightValue)
        {
            byte tmp = leftValue;
            leftValue = rightValue;
            rightValue = tmp;
        }

        /// <summary>
        /// Swaps the value of float numbers.
        /// </summary>
        /// <param name="leftValue">The first <see cref="System.Int64"/> is pass to right</param>
        /// <param name="rightValue">The second <see cref="System.Int64"/> is pass to left</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(ref float leftValue, ref float rightValue)
        {
            float tmp = leftValue;
            leftValue = rightValue;
            rightValue = tmp;
        }

        /// <summary>
        /// Swaps the value of double numbers.
        /// </summary>
        /// <param name="leftValue">The first <see cref="System.Int64"/> is pass to right</param>
        /// <param name="rightValue">The second <see cref="System.Int64"/> is pass to left</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(ref double leftValue, ref double rightValue)
        {
            double tmp = leftValue;
            leftValue = rightValue;
            rightValue = tmp;
        }

        /// <summary>
        /// Swaps the value of decimal numbers.
        /// </summary>
        /// <param name="leftValue">The first <see cref="System.Int64"/> is pass to right</param>
        /// <param name="rightValue">The second <see cref="System.Int64"/> is pass to left</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Swap(ref decimal leftValue, ref decimal rightValue)
        {
            decimal tmp = leftValue;
            leftValue = rightValue;
            rightValue = tmp;
        }

        /// <summary>
        /// Swap position on passed array.
        /// </summary>
        /// <typeparam name="T">The target type to use.</typeparam>
        /// <param name="arr">The target array.</param>
        /// <param name="fromPosition">The first position.</param>
        /// <param name="endPosition">The second postion.</param>
        public static void Swap<T>(ref T[] arr, int fromPosition, int endPosition)
        {
            Review.NotNull(arr, "The \"arr\" is null");

            // check array size
            if (fromPosition < endPosition)
            {
                Review.RequireLength(arr, endPosition + 1, "The target array is out length");
            }
            else
            {
                Review.RequireLength(arr, fromPosition + 1, "The target array is out length");
            }

            T tmp = arr[fromPosition];
            arr[fromPosition] = arr[endPosition];
            arr[endPosition] = tmp;
        }

        /// <summary>
        /// Simple parse for generic method base type argument.
        /// </summary>
        /// <typeparam name="T">The target type to use.</typeparam>
        /// <param name="text">The text source to recovery value</param>
        /// <returns>The result value.</returns>
        public static T Parse<T>(string text)
        {
            return (T)Convert.ChangeType(text, typeof(T));
        }

        /// <summary>
        /// Create a string with serie format from object fields and properties.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="members"></param>
        /// <param name="selection"></param>
        /// <param name="equalChar"></param>
        /// <param name="separatorChar"></param>
        /// <returns> A string with member sand value.</returns>
        public static string ToString(object value,
                                      string[] members = null,
                                      MemberSelection selection = MemberSelection.Both,
                                      char equalChar = '=',
                                      char separatorChar = ';')
        {
            var builder = new StringBuilder();

            // for properties
            if (selection is MemberSelection.Both || selection is MemberSelection.Properties)
            {
                foreach (var item in value.GetType()
                    .GetProperties()
                    .Where(f => members is null || members.Contains(f.Name)))
                {
                    builder.Append($"{item.Name}{equalChar}{item.GetValue(value)}{separatorChar}");
                }
            }

            // for fields
            if (selection is MemberSelection.Both || selection is MemberSelection.Field)
            {
                foreach (var item in value.GetType()
                    .GetFields()
                    .Where(f => members is null || members.Contains(f.Name)))
                {
                    builder.Append($"{item.Name}{equalChar}{item.GetValue(value)}{separatorChar}");
                }
            }

            // fetch final result
            return builder.ToString();
        }

        #endregion

        /// <summary>
        /// Dispose all element through an action.
        /// </summary>
        /// <param name="disposables">Array of types must be implement <see cref="IDisposable"/></param>
        /// <returns></returns>
        /// <example>
        /// var dispose = DisposeAll(httpClient, strema, etcDisposable);
        /// 
        /// // do stuff
        /// 
        /// dispose.Invoke();
        /// </example>
        public static Action DisposeAll(params IDisposable[] disposables)
        {
            return delegate
            {
                foreach (var item in disposables)
                {
                    item.Dispose();
                }
            };
        }

        /// <summary>
        /// Dispose all element through an action.
        /// </summary>
        /// <param name="disposables">Enumerable of types must be implement <see cref="IDisposable"/></param>
        /// <returns></returns>
        /// <example>
        /// var dispose = DisposeAll(httpClient, strema, etcDisposable);
        /// 
        /// // do stuff
        /// 
        /// dispose.Invoke();
        /// </example>
        public static Action DisposeAll(IEnumerable<IDisposable> disposables)
        {
            return delegate
            {
                foreach (var item in disposables)
                {
                    item.Dispose();
                }
            };
        }


        /// <summary>
        /// Dispose all element through an action.
        /// </summary>
        /// <param name="disposables">Enumerable of types must be implement <see cref="IDisposable"/></param>
        /// <returns></returns>
        public static void DisposeAll(IEnumerable<IDisposable> disposables, Action action)
        {
            action.Invoke();
            foreach (var item in disposables)
            {
                item.Dispose();
            }
        }
    }

    #region Enums

    /// <summary>
    /// Indicate the member seelctions
    /// </summary>
    public enum MemberSelection
    {
        Properties,
        Field,
        Both
    }

    #endregion
}
