using System;
using System.Collections.Generic;

namespace Helppad.Linq
{
    /// <summary>
    /// Rank features container.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TTarget"></typeparam>
    public class RankElement<TSource, TTarget> : IEquatable<RankElement<TSource, TTarget>>
    {
        /// <summary>
        /// Require rank specifications.
        /// </summary>
        /// <param name="rank"></param>
        /// <param name="target"></param>
        /// <param name="source"></param>
        public RankElement(int rank, TTarget target, TSource source)
        {
            Rank = rank;
            Target = target;
            Source = source;
        }

        /// <summary>
        /// Position in rank.
        /// </summary>
        public int Rank { get; }

        /// <summary>
        /// Value that placed the rank.
        /// </summary>
        public TTarget Target { get; }

        /// <summary>
        /// The instance of the element positioned.
        /// </summary>
        public TSource Source { get; }

        /// <summary>
        /// Determine if the rank instance is equal.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Boolean value to represent result.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as RankElement<TSource, TTarget>);
        }

        /// <summary>
        /// Determine if the rank instance is equal.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Boolean value to represent result.</returns>
        public bool Equals(RankElement<TSource, TTarget> other)
        {
            return other != null &&
                   Rank == other.Rank &&
                   EqualityComparer<TTarget>.Default.Equals(Target, other.Target) &&
                   EqualityComparer<TSource>.Default.Equals(Source, other.Source);
        }

        /// <summary>
        /// Resolve the hascode to rank instance.
        /// </summary>
        /// <returns>An integer as hashcode.</returns>
        public override int GetHashCode()
        {
            int hashCode = -133461289;
            hashCode = hashCode * -1521134295 + Rank.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<TTarget>.Default.GetHashCode(Target);
            hashCode = hashCode * -1521134295 + EqualityComparer<TSource>.Default.GetHashCode(Source);
            return hashCode;
        }

        public static bool operator ==(RankElement<TSource, TTarget> left, RankElement<TSource, TTarget> right)
        {
            return EqualityComparer<RankElement<TSource, TTarget>>.Default.Equals(left, right);
        }

        public static bool operator !=(RankElement<TSource, TTarget> left, RankElement<TSource, TTarget> right)
        {
            return !(left == right);
        }
    }
}