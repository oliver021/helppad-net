using System;
using System.Collections;
using System.Collections.Generic;

namespace Helppad.Linq
{
    /// <summary>
    /// The rank enumerable contains the rank result.
    /// </summary>
    /// <typeparam name="TSource">The target element type.</typeparam>
    /// <typeparam name="TTarget">The target type that determinate the rank.</typeparam>
    public class RankEnumerable<TSource, TTarget> : IEnumerable<RankElement<TSource, TTarget>>
    {
        private readonly IEnumerable<RankElement<TSource, TTarget>> elements;

        internal RankEnumerable(IEnumerable<RankElement<TSource, TTarget>> elements)
        {
            if (elements is null)
            {
                throw new ArgumentNullException(nameof(elements));
            }

            this.elements = elements;
        }

        public IEnumerator<RankElement<TSource, TTarget>> GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return elements.GetEnumerator();
        }
    }
}