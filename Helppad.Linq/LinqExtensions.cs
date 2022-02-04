using System;
using System.Collections.Generic;
using System.Linq;

namespace Helppad.Linq
{
    /// <summary>
    /// A set thet contains many method to extend the standard linq.
    /// </summary>
    public static class LinqExtensions
    {
        /// <summary>
        /// Create an enuemrable with index at enuemration.
        /// </summary>
        /// <typeparam name="TSource">The target type.</typeparam>
        /// <param name="enumerable">The target enuemrable.</param>
        /// <returns>En enuemrable <see cref="IEnumerable{T}"/> with indexes. </returns>
        public static IEnumerable<(TSource, int)> ToIndexed<TSource>(this IEnumerable<TSource> enumerable)
        {
            using var enumerator = enumerable.GetEnumerator();
            int i = 0;

            // generate the same result with indexes
            while (enumerator.MoveNext())
            {
                // yield the current value and index
                yield return (enumerator.Current, i++);
            }
        }

        /// <summary>
        /// Create an enuemrable with index at enuemration.
        /// </summary>
        /// <typeparam name="TSource">The target type.</typeparam>
        /// <typeparam name="TReturns">The target return.</typeparam>
        /// <param name="enumerable">The target enuemrable.</param>
        /// <param name="func">The function to invoke.</param>
        /// <returns>En enuemrable <see cref="IEnumerable{T}"/> with indexes. </returns>
        public static IEnumerable<(TSource, TReturns)> ToIndexed<TSource, TReturns>(this IEnumerable<TSource> enumerable, Func<TSource, TReturns> func)
        {
            using var enumerator = enumerable.GetEnumerator();

            // generate the same result with indexes
            while (enumerator.MoveNext())
            {
                // yield the current value and index
                yield return (enumerator.Current, func.Invoke(enumerator.Current));
            }
        }

        /// <summary>
        /// Apply an action below each element of an enuemrable.
        /// It like foreach loop but with
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="action">The action to execute.</param>
        public static void ForEach<TSource>(this IEnumerable<TSource> enumerable, Action<TSource> action)
        {
            using var enumerator = enumerable.GetEnumerator();

            while (enumerator.MoveNext())
            {
                // execute action
                action.Invoke(enumerator.Current);
            }
        }

        /// <summary>
        /// Apply an action below each element of an enuemrable.
        /// It like foreach loop but with method.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="action">The action to execute.</param>
        public static void ForEach<TSource>(this IEnumerable<TSource> enumerable, Action<TSource, int> action)
        {
            using var enumerator = enumerable.GetEnumerator();
            int i = 0;
            while (enumerator.MoveNext())
            {
                // execute action
                action.Invoke(enumerator.Current, i);
            }
        }

        /// <summary>
        /// Apply an action below each element of an enuemrable.
        /// It like foreach loop but with method.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="action">The action to execute.</param>
        public static void ForEach<TSource>(this IEnumerable<TSource> enumerable, Action<TSource, TSource, int> action)
        {
            using var enumerator = enumerable.GetEnumerator();
            TSource prev = default;
            int i = 0;

            if (enumerator.MoveNext() is false)
            {
                return;
            }
            do
            {
                action.Invoke(enumerator.Current, prev, i++);
                prev = enumerator.Current;
            } while (enumerator.MoveNext());
        }

        /// <summary>
        /// Apply an action below each element of an enuemrable.
        /// It like foreach loop but with
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="action">The action to execute.</param>
        public static void ForEach<TSource>(this IEnumerable<TSource> enumerable, Func<TSource, bool> action)
        {
            using var enumerator = enumerable.GetEnumerator();

            while (enumerator.MoveNext())
            {
                // execute action
                bool on = action.Invoke(enumerator.Current);

                if (on is false)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Apply an action below each element of an enuemrable.
        /// It like foreach loop but with
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="action">The action to execute.</param>
        public static void ForEach<TSource>(this IEnumerable<TSource> enumerable, Func<TSource, int, bool> action)
        {
            using var enumerator = enumerable.GetEnumerator();
            int i = 0;

            while (enumerator.MoveNext())
            {
                // execute action
                bool on = action.Invoke(enumerator.Current, i++);

                if (on is false)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Execute the passed action at each element in sequence enumerable.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Execute<TSource>(this IEnumerable<TSource> enumerable, Action<TSource> action)
        {
            Review.NotNullArgument(enumerable);
            Review.NotNullArgument(action);

            // for each element
            foreach (var element in enumerable)
            {
                action(element);
                yield return element;
            }
        }

        /// <summary>
        /// Is like a where but invert.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Without<TSource>(this IEnumerable<TSource> enumerable, Predicate<TSource> predicate)
        {
            return enumerable.Where(x => !predicate.Invoke(x));
        }

        /// <summary>
        /// Agrega una clasura where si se pasa un valor true como condicion
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="condition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> enumerable, bool condition, Predicate<TSource> predicate)
        {
            if (condition)
            {
                return enumerable.Where(x => predicate.Invoke(x));
            }
            else
            {
                return enumerable;
            }
        }

        /// <summary>
        /// Is like a where but invert also support the condition like <see cref="WhereIf{TSource}(IEnumerable{TSource}, bool, Predicate{TSource})"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="condition"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> WithoutIf<T>(this IEnumerable<T> enumerable, bool condition, Predicate<T> predicate)
        {
            if (condition)
            {
                return enumerable.Where(x => !predicate.Invoke(x));
            }
            else
            {
                return enumerable;
            }
        }

        /// <summary>
        /// It's similar like <see cref="Enumerable.Select{TSource, TResult}(IEnumerable{TSource}, Func{TSource, TResult})"/> 
        /// but the result is passed to a callback to store in new enumerable.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <typeparam name="TReturns"></typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="action">The action to execute.</param>
        /// <returns></returns>
        public static IEnumerable<TReturns> Build<TSource, TReturns>(this IEnumerable<TSource> enumerable, Action<TSource, Action<TReturns>> action)
        {
            var elements = new List<TReturns>();

            using var enumerator = enumerable.GetEnumerator();

            while (enumerator.MoveNext())
            {
                // execute action
                action.Invoke(enumerator.Current, (newElm) => elements.Add(newElm));
            }

            return elements;
        }

        /// <summary>
        /// Using basic Linq method to paginate a enumrable.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Paginate<TSource>(this IEnumerable<TSource> enumerable, int page, int size = 20)
        {
            var offset = ((page - 1) * size);
            return enumerable.Skip(offset).Take(size);
        }

        /// <summary>
        /// Excludes a contiguous number of elements from a enuemrable by a range like (e.g 0-4).
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enumerable to exlude elements.</param>
        /// <param name="startIndex">The begin index to start exclude.</param>
        /// <param name="count">The count to exclude.</param>
        /// <returns>New enumerable without exluded element by indexes.</returns>
        public static IEnumerable<TSource> Exclude<TSource>(this IEnumerable<TSource> enumerable, int startIndex, int count)
        {
            var i = -1;
            var end = startIndex + count;
            using var enumerator = enumerable.GetEnumerator();

            while (enumerator.MoveNext() && ++i < startIndex)
                yield return enumerator.Current;

            while (++i < end && enumerator.MoveNext())
                continue;

            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }

        /// <summary>
        /// Apply the query configuration if the condition is true.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enuemerable">The target enuemration to apply operand.</param>
        /// <param name="condition">The Condition to evaluate.</param>
        /// <param name="apply">The action taht configure the enumeration query.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> ApplyIf<TSource>(IEnumerable<TSource> enuemerable, bool condition, Func<IEnumerable<TSource>, IEnumerable<TSource>> apply)
        {
            if (condition)
            {
                return apply.Invoke(enuemerable);
            }
            else
            {
                return enuemerable;
            }
        }

        /// <summary>
        /// Create a new enumerable from a count and random elements.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="count"></param>
        /// <param name="random"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Rand<TSource>(this IEnumerable<TSource> enumerable, int count, Random random = null)
        {
            // fetch the array
            var arr = enumerable.ToArray();
            var record = new HashSet<int>();

            // check random object
            if (random is null)
            {
                random = new Random();
            }

            // generate the new enuemrable
            for (int i = 0; i < count; i++)
            {
                int index = random.Next(0, arr.Length);

                if (record.Contains(index))
                {
                    continue;
                }

                yield return arr[index];

                // register index
                record.Add(index);
            }
        }

        /// <summary>
        /// Creates an array from <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <typeparam name="TResult">Thet type of teh result to return.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static TResult[] ToArray<TSource, TResult>(this IEnumerable<TSource> enumerable, Func<TSource, TResult> func)
        {
            return enumerable.Select(func).ToArray();
        }

        /// <summary>
        /// Creates an array from <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static TSource[] ToArray<TSource>(this IEnumerable<TSource> enumerable, Func<TSource, bool> func)
        {
            return enumerable.Where(func).ToArray();
        }

        /// <summary>
        /// Creates an array from <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public static TSource[] ToArray<TSource>(this IEnumerable<TSource> enumerable, int skip, int take)
        {
            return enumerable.Skip(skip)
                .Take(take)
                .ToArray();
        }

        /// <summary>
        /// Creates an list from <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <typeparam name="TResult">Thet type of teh result to return.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static List<TResult> ToList<TSource, TResult>(this IEnumerable<TSource> enumerable, Func<TSource, TResult> func)
        {
            return enumerable.Select(func).ToList();
        }

        /// <summary>
        /// Creates an list from <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static List<TSource> ToList<TSource>(this IEnumerable<TSource> enumerable, Func<TSource, bool> func)
        {
            return enumerable.Where(func).ToList();
        }

        /// <summary>
        /// Creates an list from <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public static List<TSource> ToList<TSource>(this IEnumerable<TSource> enumerable, int skip, int take)
        {
            return enumerable.Skip(skip)
                .Take(take)
                .ToList();
        }

        /// <summary>
        /// Creates an hash set from <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <returns></returns>
        public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> enumerable)
        {
            // from hash set constructs
            return new HashSet<TSource>(enumerable);
        }

        /// <summary>
        ///  Creates an hash set from <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <typeparam name="TResult">Thet type of teh result to return.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static HashSet<TResult> ToHashSet<TSource, TResult>(this IEnumerable<TSource> enumerable, Func<TSource, TResult> func)
        {
            return enumerable.Select(func).ToHashSet();
        }

        /// <summary>
        ///  Creates an hash set from <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> enumerable, Func<TSource, bool> func)
        {
            return enumerable.Where(func).ToHashSet();
        }

        /// <summary>
        ///  Creates an hash set from <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> enumerable, int skip, int take)
        {
            return enumerable.Skip(skip)
                .Take(take)
                .ToHashSet();
        }

        /// <summary>
        /// Creates a <see cref="ILookup{TKey,TValue}" /> from a sequence enumerable.
        /// From key pair value.
        /// </summary>
        /// <typeparam name="TKey">The target type of the key.</typeparam>
        /// <typeparam name="TValue">The target type of the value.</typeparam>
        /// <param name="enumerable">The source sequence of key-value pairs.</param>
        /// <param name="comparer">The comparer for keys. (optional)</param>
        /// <returns></returns>
        public static ILookup<TKey, TValue> ToLookup<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> enumerable,
            IEqualityComparer<TKey> comparer = null)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            return enumerable.ToLookup(x => x.Key, x => x.Value, comparer);
        }

        /// <summary>
        /// Creates a <see cref="ILookup{TKey,TValue}" /> from a sequence enumerable.
        /// From a tuple.
        /// </summary>
        /// <typeparam name="TKey">The target type of the key.</typeparam>
        /// <typeparam name="TValue">The target type of the value.</typeparam>
        /// <param name="enumerable">The source sequence of key-value pairs.</param>
        /// <param name="comparer">The comparer for keys. (optional)</param>
        /// <returns></returns>
        public static ILookup<TKey, TValue> ToLookup<TKey, TValue>(this IEnumerable<Tuple<TKey, TValue>> enumerable,
            IEqualityComparer<TKey> comparer = null)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            return enumerable.ToLookup(x => x.Item1, x => x.Item2, comparer);
        }

        /// <summary>
        /// Returns a sequence with a range of elements in the source sequence
        /// moved to a new offset.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="fromIndex">The started index to begin move.</param>
        /// <param name="count">The number of element to move.</param>
        /// <param name="toIndex">The target index to move.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> Move<TSource>(this IEnumerable<TSource> enumerable, int fromIndex, int count, int toIndex)
        {
            using var enumerator = enumerable.GetEnumerator();
            var movement = new TSource[count];

            // verify case
            if (fromIndex > toIndex)
            {
                // initial batch
                for (int i = 0; i < fromIndex; i++)
                {
                    enumerator.MoveNext();
                    yield return enumerator.Current;
                }

                int k = 0;

                // store the move target
                for (int i = fromIndex; i < count; i++)
                {
                    enumerator.MoveNext();
                    movement[k++] = enumerator.Current;
                }

                int rest = toIndex - count;

                // yield the rest
                for (int i = 0; i < rest; i++)
                {
                    enumerator.MoveNext();
                    yield return enumerator.Current;
                }

                // move the subsequence
                for (int i = 0; i < movement.Length; i++)
                {
                    yield return movement[i];
                }

                // for all rest
                while (enumerator.MoveNext())
                {
                    yield return enumerator.Current;
                }
            }
        }

        /// <summary>
        /// Pads a sequence with a dynamic filler value if it is narrower (shorter
        /// in length) than a given width.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="source"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Pad<TSource>(this IEnumerable<TSource> source, int width)
        {
            return Pad(source, width, default);
        }

        /// <summary>
        /// Pads a sequence with a dynamic filler value if it is narrower (shorter
        /// in length) than a given width.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="count"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Pad<TSource>(this IEnumerable<TSource> enumerable, int count, TSource source)
        {
            using var enumerator = enumerable.GetEnumerator();

            // the same sequence
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }

            // generate more elements
            for (int i = 0; i < count; i++)
            {
                yield return source;
            }
        }

        /// <summary>
        /// Make an IEnumerable from function argument.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action">The action to execute.</param>
        /// <returns></returns>
        public static IEnumerable<T> From<T>(Action<Action<T>> action)
        {
            var src = new List<T>();
            action.Invoke(newElm => src.Add(newElm));
            return src;
        }


        /// <summary>
        /// Make an IEnumerable from function argument.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="func1"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> From<TSource>(Func<TSource> func1)
        {
            yield return func1();
        }

        /// <summary>
        ///  Make an IEnumerable from function argument.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="func1"></param>
        /// <param name="func2"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> From<TSource>(Func<TSource> func1, Func<TSource> func2)
        {
            yield return func1();
            yield return func2();
        }

        /// <summary>
        ///  Make an IEnumerable from function argument.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="func1"></param>
        /// <param name="func2"></param>
        /// <param name="func3"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> From<TSource>(Func<TSource> func1, Func<TSource> func2, Func<TSource> func3)
        {
            yield return func1();
            yield return func2();
            yield return func3();
        }

        /// <summary>
        ///  Make an IEnumerable from function argument.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="func1"></param>
        /// <param name="func2"></param>
        /// <param name="func3"></param>
        /// <param name="func4"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> From<TSource>(Func<TSource> func1, Func<TSource> func2, Func<TSource> func3, Func<TSource> func4)
        {
            yield return func1();
            yield return func2();
            yield return func3();
            yield return func4();
        }

        /// <summary>
        /// This is similar like <see cref="string.Split(char[])"/> but with generic enumerable.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="separatorFunc"></param>
        /// <param name="included"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> enumerable, Func<TSource, bool> separatorFunc, bool included = false)
        {
            using var enumerator = enumerable.GetEnumerator();
            var sequenceBuffer = new List<TSource>();

            while (enumerator.MoveNext())
            {
                if (separatorFunc.Invoke(enumerator.Current))
                {
                    // check included
                    if (included)
                    {
                        sequenceBuffer.Add(enumerator.Current);
                    }

                    // check buffer
                    if (sequenceBuffer.Count > 0)
                    {
                        // push sequence
                        yield return sequenceBuffer;

                        // flush sequence
                        sequenceBuffer.Clear();
                    }
                }
                else
                {
                    sequenceBuffer.Add(enumerator.Current);
                }
            }
        }

        /// <summary>
        /// This is similar like <see cref="string.Split(char[])"/> but with generic enumerable.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="separatorFunc"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> enumerable, Func<TSource, TSource, int, bool> separatorFunc)
        {
            using var enumerator = enumerable.GetEnumerator();
            var sequenceBuffer = new List<TSource>();

            // check sequence contains
            // next movement
            if (enumerator.MoveNext() is false)
            {
                throw new InvalidOperationException();
            }

            TSource prev = default;
            int i = 0;

            // do initial element
            do
            {
                // add for default
                sequenceBuffer.Add(enumerator.Current);

                // check invoke
                if (separatorFunc.Invoke(enumerator.Current, prev, i))
                {
                    // check buffer
                    if (sequenceBuffer.Count > 0)
                    {
                        // push sequence
                        yield return sequenceBuffer;

                        // flush sequence
                        sequenceBuffer.Clear();
                    }
                }
            } while (enumerator.MoveNext());
        }

        /// <summary>
        /// Create a key pair value from given enuemrable.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IEnumerable<KeyValuePair<TKey, TSource>> ToKeyPair<TSource, TKey>(this IEnumerable<TSource> enumerable, Func<TSource, TKey> func)
        {
            return enumerable.Select((item) => new KeyValuePair<TKey, TSource>(func.Invoke(item), item));
        }

        /// <summary>
        /// Create a key pair value from given enuemrable.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="source"></param>
        /// <param name="func"></param>
        /// <param name="toValue"></param>
        /// <returns></returns>
        public static IEnumerable<KeyValuePair<TKey, TValue>> ToKeyPair<TSource, TKey, TValue>(this IEnumerable<TSource> source, Func<TSource, TKey> func, Func<TSource, TValue> toValue)
        {
            return source.Select((item) => new KeyValuePair<TKey, TValue>(func.Invoke(item), toValue.Invoke(item)));
        }

        /// <summary>
        /// Create a key pair value from given enuemrable and key computed by hashcode.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<KeyValuePair<int, TSource>> HashedPair<TSource>(this IEnumerable<TSource> source)
        {
            return source.Select(item => new KeyValuePair<int, TSource>(item.GetHashCode(), item));
        }

        /// <summary>
        /// Evaluate an condition by a predicate and get true or false if the condition is successful.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enuemrable"></param>
        /// <param name="predicate"></param>
        /// <param name="goal"></param>
        /// <returns></returns>
        public static bool Evaluate<TSource>(this IEnumerable<TSource> enuemrable, Predicate<TSource> predicate, int goal)
        {
            int i = 0;
            var enuemrator = enuemrable.GetEnumerator();

            while (enuemrator.MoveNext())
            {
                if (predicate.Invoke(enuemrator.Current))
                {
                    i++;
                }

                if (i >= goal)
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Completely consumes the given enumerable. This method uses immediate execution,
        /// and doesn't store any data during execution.
        /// </summary>
        /// <typeparam name="TSource">Element type of the enumerable.</typeparam>
        /// <param name="enumerable">Enumerable to consume.</param>
        public static void Consume<TSource>(this IEnumerable<TSource> enumerable)
        {
            foreach (var element in enumerable)
            {
            }
        }

        /// <summary>
        /// Create an enumerable rank base in <see cref="Enumerable.OrderBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"/> method.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="keySelector"></param>
        /// <param name="comparer"></param>
        /// <param name="count"></param>
        /// <returns>The RankEnumerable instance that contains a ranking of elements.</returns>
        public static RankEnumerable<TSource, TTarget> Rank<TSource, TTarget>(this IEnumerable<TSource> enumerable,
                                                                              Func<TSource, TTarget> keySelector,
                                                                              IComparer<TTarget> comparer,
                                                                              int count)
        {
            return new RankEnumerable<TSource, TTarget>(enumerable.OrderBy(keySelector, comparer)
                .Take(count)
                .Select((elm, i) => new RankElement<TSource, TTarget>(i, keySelector.Invoke(elm), elm)));
        }

        /// <summary>
        /// Create an enumerable rank base in <see cref="Enumerable.OrderBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey}, IComparer{TKey})"/> method.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="keySelector"></param>
        /// <param name="count"></param>
        /// <returns>The RankEnumerable instance that contains a ranking of elements.</returns>
        public static RankEnumerable<TSource, TTarget> Rank<TSource, TTarget>(this IEnumerable<TSource> enumerable,
                                                                              Func<TSource, TTarget> keySelector,
                                                                              int count)
        {
            return new RankEnumerable<TSource, TTarget>(enumerable.OrderBy(keySelector)
                .Take(count)
                .Select((elm, i) => new RankElement<TSource, TTarget>(i, keySelector.Invoke(elm), elm)));
        }

        /// <summary>
        /// Create an enumerable rank base in <see cref="Enumerable.OrderByDescending{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"/> method.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="keySelector"></param>
        /// <param name="comparer"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static RankEnumerable<TSource, TTarget> RankDescending<TSource, TTarget>(this IEnumerable<TSource> enumerable,
                                                                                        Func<TSource, TTarget> keySelector,
                                                                                        IComparer<TTarget> comparer,
                                                                                        int count)
        {
            return new RankEnumerable<TSource, TTarget>(enumerable.OrderByDescending(keySelector, comparer)
                .Take(count)
                .Select((elm, i) => new RankElement<TSource, TTarget>(i, keySelector.Invoke(elm), elm)));
        }

        /// <summary>
        /// Create an enumerable rank base in <see cref="Enumerable.OrderByDescending{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey}, IComparer{TKey})"/> method.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="keySelector"></param>
        /// <param name="count"></param>
        /// <returns>The RankEnumerable instance that contains a ranking of elements.</returns>
        public static RankEnumerable<TSource, TTarget> RankDescending<TSource, TTarget>(this IEnumerable<TSource> enumerable,
                                                                                        Func<TSource, TTarget> keySelector,
                                                                                        int count)
        {
            return new RankEnumerable<TSource, TTarget>(enumerable.OrderByDescending(keySelector)
                .Take(count)
                .Select((elm, i) => new RankElement<TSource, TTarget>(i, keySelector.Invoke(elm), elm)));
        }

        /// <summary>
        /// Returns the number of elements in a sequence by selection key.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<KeyValuePair<TKey, int>> CountBy<TSource, TKey>(this IEnumerable<TSource> enumerable, Func<TSource, TKey> selector)
        {
            return enumerable.GroupBy(selector)
                .Select(x => new KeyValuePair<TKey, int>(x.Key, x.Count()));
        }

        /// <summary>
        /// Returns the number of elements in a sequence by selection key.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<KeyValuePair<TKey, long>> LongCountBy<TSource, TKey>(this IEnumerable<TSource> enumerable, Func<TSource, TKey> selector)
        {
            return enumerable.GroupBy(selector)
                .Select(x => new KeyValuePair<TKey, long>(x.Key, x.LongCount()));
        }

        /// <summary>
        /// Insert an element in first position in enumerable.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Append<TSource>(this IEnumerable<TSource> enumerable, TSource element)
        {
            return new[] { element }.Concat(enumerable);
        }

        /// <summary>
        /// Insert an element in enumerable.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Insert<TSource>(this IEnumerable<TSource> enumerable, TSource element)
        {
            return enumerable.Concat(new[] { element });
        }

        /// <summary>
        /// Returns the element at a specified index in a sequence but with fallback if not found.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="index"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TSource ElementAt<TSource>(this IEnumerable<TSource> enumerable, int index, TSource key)
        {
            Review.NonNegative(index, nameof(index) + "can be less then zero.");

            using var enumerator = enumerable.GetEnumerator();
            int i = 0;

            // using loop until found the element
            while (enumerator.MoveNext())
            {
                if (index == i)
                {
                    return enumerator.Current;
                }
            }

            return key;
        }

        /// <summary>
        ///  Returns the element at a specified index in a sequence.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="key"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static TSource ElementAt<TSource, TKey>(this IEnumerable<TSource> enumerable, TKey key, Func<TSource, TKey> keySelector)
        {
            using var enumerator = enumerable.GetEnumerator();

            // using loop until found the element
            while (enumerator.MoveNext())
            {
                if (keySelector.Invoke(enumerator.Current).Equals(key))
                {
                    return enumerator.Current;
                }
            }

            throw new Exception();
        }

        /// <summary>
        ///  Returns the element at a specified index in a sequence.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="key"></param>
        /// <param name="keySelector"></param>
        /// <param name="equality"></param>
        /// <returns></returns>
        public static TSource ElementAt<TSource, TKey>(this IEnumerable<TSource> enumerable,
                                                       TKey key,
                                                       Func<TSource, TKey> keySelector,
                                                       IEqualityComparer<TKey> equality)
        {
            using var enumerator = enumerable.GetEnumerator();

            // using loop until found the element
            while (enumerator.MoveNext())
            {
                if (equality.Equals(keySelector.Invoke(enumerator.Current), key))
                {
                    return enumerator.Current;
                }
            }
            throw new Exception();
        }

        /// <summary>
        /// Returns the element at a specified index in a sequence or a default value if
        /// the index not found.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="key"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static TSource ElementAtOrDefault<TSource, TKey>(this IEnumerable<TSource> enumerable,
                                                                TKey key,
                                                                Func<TSource, TKey> keySelector)
        {
            using var enumerator = enumerable.GetEnumerator();

            // using loop until found the element
            while (enumerator.MoveNext())
            {
                if (keySelector.Invoke(enumerator.Current).Equals(key))
                {
                    return enumerator.Current;
                }
            }

            return default;
        }

        /// <summary>
        /// Returns the element at a specified index in a sequence or a default value if
        /// the index not found.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="key"></param>
        /// <param name="keySelector"></param>
        /// <param name="equality"></param>
        /// <returns></returns>
        public static TSource ElementAtOrDefault<TSource, TKey>(this IEnumerable<TSource> enumerable,
                                                                TKey key,
                                                                Func<TSource, TKey> keySelector,
                                                                IEqualityComparer<TKey> equality)
        {
            using var enumerator = enumerable.GetEnumerator();

            // using loop until found the element
            while (enumerator.MoveNext())
            {
                if (keySelector.Invoke(enumerator.Current).Equals(key))
                {
                    return enumerator.Current;
                }
            }

            return default;
        }

        /// <summary>
        /// Return from sequence enumerable take the last count.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> TakeLast<TSource>(this IEnumerable<TSource> enumerable, int count)
        {
            using var enumerator = enumerable.Reverse().GetEnumerator();
            int i = 0;
            
            // for next
            while (enumerator.MoveNext() && i++ < count)
            {
                // put on yield
                yield return enumerator.Current;
            }
        }

        /// <summary>
        /// Determines whether two sequences are equal by comparing their elements by using projection.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="enumerable2"></param>
        /// <param name="keySelection"></param>
        /// <returns></returns>
        public static bool SequenceEqualBy<TSource, TKey>(this IEnumerable<TSource> enumerable, IEnumerable<TSource> enumerable2, Func<TSource, TKey> keySelection)
        {
            return enumerable.Select(keySelection)
                .SequenceEqual(enumerable2.Select(keySelection));
        }

        /// <summary>
        /// Determines whether two sequences are equal by comparing their elements by using projection.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="enumerable2"></param>
        /// <param name="keySelection"></param>
        /// <param name="equality"></param>
        /// <returns></returns>
        public static bool SequenceEqualBy<TSource, TKey>(this IEnumerable<TSource> enumerable, IEnumerable<TSource> enumerable2, Func<TSource, TKey> keySelection, IEqualityComparer<TKey> equality)
        {
            return enumerable.Select(keySelection)
                .SequenceEqual(enumerable2.Select(keySelection), comparer: equality);
        }

        /// <summary>
        /// Insert an element in enumerable.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Combine<TSource>(this IEnumerable<TSource> enumerable, IEnumerable<TSource> second)
        {
            using var enumerator1 = enumerable.GetEnumerator();
            using var enumerator2 = second.GetEnumerator();

            // generate the combined sequence
            // use simulated infinite loop
            while (true)
            {
                bool hasEnumerator1 = enumerator1.MoveNext();
                bool hasEnumerator2 = enumerator2.MoveNext();

                if (hasEnumerator1)
                {
                    yield return enumerator1.Current;
                }

                if (hasEnumerator2)
                {
                    yield return enumerator2.Current;
                }

                // break rule to get out
                if (hasEnumerator2 && !hasEnumerator1)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Simple flatten implementation for multidimensional enumerable.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> Flatten<TSource>(this IEnumerable<IEnumerable<TSource>> enumerable)
        {
            return enumerable.SelectMany(x => x);
        }

        /// <summary>
        /// Filter all element by equiality comparision.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="compare"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Equals<TSource>(this IEnumerable<TSource> enumerable, TSource compare)
        {
            return enumerable.Where(item => EqualityComparer<TSource>.Default.Equals(item, compare));
        }

        /// <summary>
        /// Filter all element by equiality comparision.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="compare"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Equals<TSource>(this IEnumerable<TSource> enumerable, TSource compare, IEqualityComparer<TSource> comparer)
        {
            return enumerable.Where(item => comparer.Equals(item, compare));
        }

        /// <summary>
        /// Filter all element that equal a target.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="compare"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Diff<TSource>(this IEnumerable<TSource> enumerable, TSource compare)
        {
            return enumerable.Where(item => !EqualityComparer<TSource>.Default.Equals(item, compare));
        }

        /// <summary>
        /// Filter all element that equal a target.
        /// </summary>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="compare"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Diff<TSource>(this IEnumerable<TSource> enumerable, TSource compare, IEqualityComparer<TSource> comparer)
        {
            return enumerable.Where(item => !comparer.Equals(item, compare));
        }

        /// <summary>
        /// Returns distinct elements from a sequence by using the target selection and equality comparer
        /// to compare values (option).
        /// </summary>
        /// <remarks>
        /// In valueResolver argument, the function cab used the member value or computed value
        /// to make a distition.
        /// </remarks>
        /// <typeparam name="TSource">The target source type of the enumeration.</typeparam>
        /// <typeparam name="TTarget">The tyoe of value to resolve disctition.</typeparam>
        /// <param name="enumerable">The target enuemration to apply operand.</param>
        /// <param name="valueResolver">The function to determinate the criteria to distict.</param>
        /// <param name="comparer">The equality comparer instance (optional).</param>
        /// <returns></returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TTarget>(this IEnumerable<TSource> enumerable,
            Func<TSource, TTarget> valueResolver, IEqualityComparer<TTarget> comparer = null)
        {
            var record = new HashSet<TTarget>(comparer);

            // generate the result sequence
            foreach (var item in enumerable)
            {
                if (record.Add(valueResolver(item)))
                    yield return item;
            }
        }

        /// <summary>
        /// Make a fold operand in this query and return a result from folder.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="count"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static TResult Fold<TSource, TResult>(this IEnumerable<TSource> enumerable, int count, Func<TSource[], TResult> func)
        {
            return func.Invoke(enumerable.Take(count).ToArray());
        }

        /// <summary>
        /// Use flat hand function to resolve the agreggation operand.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="agreggate"></param>
        /// <param name="initial"></param>
        /// <returns></returns>
        public static TResult AgreggateFor<TSource, TResult>(this IEnumerable<TSource> enumerable, Func<Func<(bool Has, TSource Current)>, TResult> agreggate, TResult initial = default)
        {
            using var enumerator = enumerable.GetEnumerator();
            
            // base on passed function
            return agreggate.Invoke(delegate 
            {
                return (enumerator.MoveNext(), enumerator.Current);
            });
        }

        /// <summary>
        /// Simple fork operation from a single enumerate.
        /// </summary>
        /// <typeparam name="TSource">The target type of the sequence enumerable.</typeparam>
        /// <param name="enumerable">The target sequence enumerable.</param>
        /// <param name="predicate"></param>
        /// <returns>
        /// On the left the elements that give negatives and on the right the positives.
        /// </returns>
        public static (IEnumerable<TSource> Left, IEnumerable<TSource> Right) Fork<TSource>(this IEnumerable<TSource> enumerable, Predicate<TSource> predicate)
        {
            return (
                enumerable.Where(e => !predicate(e)),
                enumerable.Where(e => predicate(e))
            );
        }

        /// <summary>
        /// Make a full join operation.
        /// </summary>
        /// <typeparam name="TFirst"></typeparam>
        /// <typeparam name="TSecond"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="enumerableSource"></param>
        /// <param name="inner"></param>
        /// <param name="sourceKeySelector"></param>
        /// <param name="innerKeySelector"></param>
        /// <param name="firstSelector"></param>
        /// <param name="innerSelector"></param>
        /// <param name="joinSelector"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> NestedJoin<TFirst, TSecond, TKey, TResult>(
            this IEnumerable<TFirst> enumerableSource,
            IEnumerable<TSecond> inner,
            Func<TFirst, TKey> sourceKeySelector,
            Func<TSecond, TKey> innerKeySelector,
            Func<TFirst, TResult> firstSelector,
            Func<TSecond, TResult> innerSelector,
            Func<TFirst, TSecond, TResult> joinSelector,
            IEqualityComparer<TKey> comparer = null)
        {
            // check argument
            Review.NotNullArgument(enumerableSource);
            Review.NotNullArgument(inner);
            Review.NotNullArgument(sourceKeySelector);
            Review.NotNullArgument(innerKeySelector);
            Review.NotNullArgument(firstSelector);
            Review.NotNullArgument(innerSelector);
            Review.NotNullArgument(joinSelector);

            var seconds = inner.Select(BySecond(innerKeySelector)).ToArray();
            var secondLookup = seconds.ToLookup(element => element.Key, item => item.Value, comparer);
            var firstKeys = new HashSet<TKey>(comparer);

            // using loop
            foreach (var item in enumerableSource)
            {
                var key = sourceKeySelector.Invoke(item);
                firstKeys.Add(key);

                using var enumerator = secondLookup[key].GetEnumerator();

                // check
                if (enumerator.MoveNext())
                {
                    do { 
                        yield return joinSelector.Invoke(item, enumerator.Current);
                    } while (enumerator.MoveNext());
                }
                else
                {
                    enumerator.Dispose();
                    yield return firstSelector.Invoke(item);
                }
            }

            foreach (var se in seconds)
            {
                // for second
                if (!firstKeys.Contains(se.Key))
                    yield return 
                        innerSelector.Invoke(se.Value);
            }

            
            static Func<TSecond, KeyValuePair<TKey, TSecond>> BySecond(Func<TSecond, TKey> secondKeySelector)
            {
                return element => new KeyValuePair<TKey, TSecond>(secondKeySelector(element), element);
            }
        }

        /// <summary>
        /// Make a merge with two enuemrable sequences without bind member or relation just by position.
        /// </summary>
        /// <remarks>
        /// If the second or first enumerable sequences than more larger than other then in cross selection
        /// will has default value.
        /// </remarks>
        /// <typeparam name="TSource">The target type of the main enumerable sequence.</typeparam>
        /// <typeparam name="TInner">The target type of the inner enumerable sequence.</typeparam>
        /// <typeparam name="TSourceSelector">The select type of the main enumerable sequence.</typeparam>
        /// <typeparam name="TInnerSelector">he select type of the inner enumerable sequence.</typeparam>
        /// <typeparam name="TResult">The final result from merge selector.</typeparam>
        /// <param name="enuemrableSource">The main enuemrable sequence.</param>
        /// <param name="innerEnumerable">The inner enuemrable sequence</param>
        /// <param name="sourceKeySelector">The source selector.</param>
        /// <param name="innerKeySelector">The inner selector.</param>
        /// <param name="crossSelector">The cross selection to make the merge operation.</param>
        /// <returns></returns>
        public static IEnumerable<TResult> CrossMerge<TSource, TInner, TSourceSelector, TInnerSelector, TResult>(
            this IEnumerable<TSource> enuemrableSource,
            IEnumerable<TInner> innerEnumerable,
            Func<TSource, TSourceSelector> sourceKeySelector,
            Func<TInner, TInnerSelector> innerKeySelector,
            Func<TSourceSelector, TInnerSelector, TResult> crossSelector)
        {
            // check argument
            Review.NotNullArgument(enuemrableSource);
            Review.NotNullArgument(innerEnumerable);
            Review.NotNullArgument(sourceKeySelector);
            Review.NotNullArgument(innerKeySelector);
            Review.NotNullArgument(crossSelector);
             
            using var enumerator1 = enuemrableSource.GetEnumerator(); 
            using var enumerator2 = innerEnumerable.GetEnumerator();

            // the selections
            TSourceSelector selectionOne;
            TInnerSelector selectionTwo;
            
            // for while loop
            while (true)
            {
                bool hasEnumerator1 = enumerator1.MoveNext();
                bool hasEnumerator2 = enumerator2.MoveNext();

                // for main source
                if (hasEnumerator1)
                {
                    selectionOne = sourceKeySelector.Invoke(enumerator1.Current);
                }
                else
                {
                    selectionOne = default;
                }

                // for inner source
                if (hasEnumerator2)
                {
                    selectionTwo = innerKeySelector.Invoke(enumerator2.Current);
                }
                else
                {
                    selectionTwo = default;
                }

                // break rule to get out
                if (hasEnumerator2 && !hasEnumerator1)
                {
                    break;
                }
                else
                {
                    // put on return the cross result from selections
                    yield return crossSelector.Invoke(selectionOne, selectionTwo);
                }
            }
        }

        /// <summary>
        /// Make a join by relation computed base on one predicate that recive two elements.
        /// </summary>
        /// <typeparam name="TOuter">The target type of the main enumerable sequence.</typeparam>
        /// <typeparam name="TInner">The target type of the inner enumerable sequence.</typeparam>
        /// <typeparam name="TResult">The final result from merge selector.</typeparam>
        /// <param name="outer"></param>
        /// <param name="inner"></param>
        /// <param name="evaluate"></param>
        /// <param name="resultSelector"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> JoinBy<TOuter, TInner, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TInner, bool> evaluate, Func<TOuter, TInner, TResult> resultSelector)
        {
            // check argument
            Review.NotNullArgument(outer);
            Review.NotNullArgument(inner);
            Review.NotNullArgument(evaluate);
            Review.NotNullArgument(resultSelector);

            foreach (var @out in outer)
            {
                foreach (var @in in inner)
                {
                    // check pair elements
                    if (evaluate.Invoke(@out, @in))
                    {
                        yield return resultSelector.Invoke(@out, @in);
                    }
                }
            }
        }

        /// <summary>
        /// Make a comparision from two sequence.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="second"></param>
        /// <param name="comparision"></param>
        /// <returns></returns>
        public static int Compare<TSource, TKey>(this IEnumerable<TSource> enumerable, IEnumerable<TSource> second, Func<IEnumerable<TSource>, TKey> comparision)
        where TKey: IComparable<TKey>
        {
            // check argument
            Review.NotNullArgument(enumerable);
            Review.NotNullArgument(second);
            Review.NotNullArgument(comparision);
            
            var compare1 = comparision.Invoke(enumerable);
            var compare2 = comparision.Invoke(second);
            return compare1.CompareTo(compare2);
        }

        /// <summary>
        /// Simple clear method to purge in the sequence enumerable all null values.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
#nullable enable
        public static IEnumerable<TSource> ClearNull<TSource>(this IEnumerable<TSource?> enumerable)
            where TSource : struct
        {
#pragma warning disable CS8629 // Nullable value type may be null.
            return enumerable.Where(x => x.HasValue).Select(x => x.Value);
#pragma warning restore CS8629 // Nullable value type may be null.
        }
#nullable disable

        /// <summary>
        /// The nested loop generate a multidimensional.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static TSource[][] NestedFactory<TSource>(int first, int second, Func<int,int, TSource> func)
        {
            var result = new TSource[first][];
            for (int i = 0; i < first; i++)
            {
                result[i] = new TSource[second];

                for (int j = 0; j < second; j++)
                {
                    result[i][j] = func.Invoke(i, j);
                }
            }

            return result;
        }

        /// <summary>
        /// The nested loop generate a multidimensional.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="third"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static TSource[][][] NestedFactory<TSource>(int first, int second, int third, Func<int, int, int, TSource> func)
        {
            var result = new TSource[first][][];
            for (int i = 0; i < first; i++)
            {
                result[i] = new TSource[second][];

                for (int j = 0; j < second; j++)
                {
                    result[i][j] = new TSource[third];
                    for (int j2 = 0; j2 < third; j2++)
                    {
                        result[i][j][j2] = func.Invoke(i, j, j2);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Evaluate the if the last element of the target enumerable
        /// is equals to the second sequence enumerable.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static bool EndsWith<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer = null)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));

            comparer ??= EqualityComparer<TSource>.Default;
            var arr = second.ToArray();
            return arr.SequenceEqual(first.TakeLast(arr.Length), comparer);
        }

        /// <summary>
        /// Evaluate the if the start of element of the target enumerable
        /// is equals to the second sequence enumerable.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static bool StartWith<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer = null)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));

            comparer ??= EqualityComparer<TSource>.Default;
            var arr = second.ToArray();
            return arr.SequenceEqual(first.Take(arr.Length), comparer);
        }
    }
}