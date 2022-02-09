using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace System.Linq
{
    /// <summary>
    /// The related element of two sequence.
    /// </summary>
    /// <typeparam name="TFirst"></typeparam>
    /// <typeparam name="TSecond"></typeparam>
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class Ralated<TFirst, TSecond> : IEquatable<Ralated<TFirst, TSecond>>
    {
        /// <summary>
        /// parameterless
        /// </summary>
        public Ralated()
        {
        }

        /// <summary>
        /// Require elements.
        /// </summary>
        /// <param name="firstElement"></param>
        /// <param name="secondElement"></param>
        internal Ralated(TFirst firstElement, TSecond secondElement)
        {
            FirstElement = firstElement;
            SecondElement = secondElement;
        }

        /// <summary>
        /// The first element.
        /// </summary>
        public TFirst FirstElement { get; set; }

        /// <summary>
        /// The second element.
        /// </summary>
        public TSecond SecondElement { get; set; }

        /// <summary>
        /// The equality implementation for any argument.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Ralated<TFirst, TSecond>);
        }

        /// <summary>
        /// The equality implementation for typed argument.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Ralated<TFirst, TSecond> other)
        {
            return other != null &&
                   EqualityComparer<TFirst>.Default.Equals(FirstElement, other.FirstElement) &&
                   EqualityComparer<TSecond>.Default.Equals(SecondElement, other.SecondElement);
        }

        /// <summary>
        /// Generate hashcode base on element.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hashCode = 1764396362;
            hashCode = hashCode * -1521134295 + EqualityComparer<TFirst>.Default.GetHashCode(FirstElement);
            hashCode = hashCode * -1521134295 + EqualityComparer<TSecond>.Default.GetHashCode(SecondElement);
            return hashCode;
        }

        /// <summary>
        /// Operator implemetation for equality.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Ralated<TFirst, TSecond> left, Ralated<TFirst, TSecond> right)
        {
            return EqualityComparer<Ralated<TFirst, TSecond>>.Default.Equals(left, right);
        }

        /// <summary>
        /// Operator implemetation for diff.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Ralated<TFirst, TSecond> left, Ralated<TFirst, TSecond> right)
        {
            return !(left == right);
        }

        /// <summary>
        /// For debugger feature.
        /// </summary>
        /// <returns></returns>
        private string GetDebuggerDisplay()
        {
            return ToString();
        }

        /// <summary>
        /// Make a string from internal elements.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{FirstElement},{SecondElement}";
        }
    }

    /// <summary>
    /// The related element of two sequence with join value.
    /// </summary>
    /// <typeparam name="TFirst"></typeparam>
    /// <typeparam name="TSecond"></typeparam>
    /// <typeparam name="TJoinValue"></typeparam>
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class Ralated<TFirst, TSecond, TJoinValue> : IEquatable<Ralated<TFirst, TSecond, TJoinValue>>
    {
        /// <summary>
        /// parameterless
        /// </summary>
        public Ralated()
        {
        }

        /// <summary>
        /// Require internal elements.
        /// </summary>
        /// <param name="firstElement"></param>
        /// <param name="secondElement"></param>
        /// <param name="joinValue"></param>
        public Ralated(TFirst firstElement, TSecond secondElement, TJoinValue joinValue)
        {
            FirstElement = firstElement;
            SecondElement = secondElement;
            JoinValue = joinValue;
        }

        /// <summary>
        /// The first element.
        /// </summary>
        public TFirst FirstElement { get; set; }

        /// <summary>
        /// The second element.
        /// </summary>
        public TSecond SecondElement { get; set; }

        /// <summary>
        /// The join value.
        /// </summary>
        public TJoinValue JoinValue { get; set; }

        /// <summary>
        /// The equality implementation for any argument.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Ralated<TFirst, TSecond, TJoinValue>);
        }

        /// <summary>
        /// The equality implementation for typed argument.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Ralated<TFirst, TSecond, TJoinValue> other)
        {
            return other != null &&
                   EqualityComparer<TFirst>.Default.Equals(FirstElement, other.FirstElement) &&
                   EqualityComparer<TSecond>.Default.Equals(SecondElement, other.SecondElement) &&
                   EqualityComparer<TJoinValue>.Default.Equals(JoinValue, other.JoinValue);
        }

        /// <summary>
        /// Generate hashcode from internal elements
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hashCode = -643682528;
            hashCode = hashCode * -1521134295 + EqualityComparer<TFirst>.Default.GetHashCode(FirstElement);
            hashCode = hashCode * -1521134295 + EqualityComparer<TSecond>.Default.GetHashCode(SecondElement);
            hashCode = hashCode * -1521134295 + EqualityComparer<TJoinValue>.Default.GetHashCode(JoinValue);
            return hashCode;
        }

        /// <summary>
        /// Make a string from internal elements.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }

        /// <summary>
        /// Operator implemetation for equality.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Ralated<TFirst, TSecond, TJoinValue> left, Ralated<TFirst, TSecond, TJoinValue> right)
        {
            return EqualityComparer<Ralated<TFirst, TSecond, TJoinValue>>.Default.Equals(left, right);
        }

        /// <summary>
        /// Operator implemetation for diff.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Ralated<TFirst, TSecond, TJoinValue> left, Ralated<TFirst, TSecond, TJoinValue> right)
        {
            return !(left == right);
        }

        /// <summary>
        /// For debugger feature.
        /// </summary>
        /// <returns></returns>
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }

    /// <summary>
    /// The related enumerable from two sequences and join value.
    /// </summary>
    /// <typeparam name="TFirst"></typeparam>
    /// <typeparam name="TSecond"></typeparam>
    /// <typeparam name="TJoinValue"></typeparam>
    public class RalatedEnumerable<TFirst, TSecond, TJoinValue> : IEnumerable<Ralated<TFirst, TSecond, TJoinValue>>
    {
        private readonly IEnumerable<Tuple<TFirst, TSecond, TJoinValue>> tupleSource;

        /// <summary>
        /// Require the internal source sequence.
        /// </summary>
        /// <param name="tupleSource"></param>
        internal RalatedEnumerable(IEnumerable<Tuple<TFirst, TSecond, TJoinValue>> tupleSource)
        {
            if (tupleSource is null)
            {
                throw new ArgumentNullException(nameof(tupleSource));
            }

            this.tupleSource = tupleSource;
        }

        /// <summary>
        /// The enumerator implementation.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Ralated<TFirst, TSecond, TJoinValue>> GetEnumerator()
        {
            return tupleSource.Select(t => new Ralated<TFirst, TSecond, TJoinValue>(t.Item1,t.Item2,t.Item3)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    /// <summary>
    /// The related enumerable from two sequences.
    /// </summary>
    /// <typeparam name="TFirst"></typeparam>
    /// <typeparam name="TSecond"></typeparam>
    public class RalatedEnumerable<TFirst, TSecond> : IEnumerable<Ralated<TFirst, TSecond>>
    {
        private readonly IEnumerable<Tuple<TFirst, TSecond>> tupleSource;

        /// <summary>
        /// Require the internal source sequence.
        /// </summary>
        /// <param name="tupleSource"></param>
        internal RalatedEnumerable(IEnumerable<Tuple<TFirst, TSecond>> tupleSource)
        {
            if (tupleSource is null)
            {
                throw new ArgumentNullException(nameof(tupleSource));
            }

            this.tupleSource = tupleSource;
        }

        /// <summary>
        /// The enumerator implementation.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Ralated<TFirst, TSecond>> GetEnumerator()
        {
            return tupleSource.Select(t => new Ralated<TFirst, TSecond>(t.Item1, t.Item2)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}