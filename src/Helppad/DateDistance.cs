namespace Helppad
{
    using System;

    /// <summary>
    /// Represent a date distance of time.
    /// </summary>
    public readonly struct DateDistance : IEquatable<DateDistance>
    {
        /// <summary>
        /// Construct the basic date distance
        /// </summary>
        /// <param name="ago"></param>
        /// <param name="units"></param>
        public DateDistance(int ago, DateUnits units)
        {
            Ago = ago;
            Units = units;
        }

        /// <summary>
        /// The count on units.
        /// </summary>
        public int Ago { get; }

        /// <summary>
        /// Unit type of distance.
        /// </summary>
        public DateUnits Units { get; }

        /// <summary>
        /// The equality implementation.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is DateDistance disstance && Equals(disstance);
        }

        /// <summary>
        /// The equality implementation for unboxing invokation.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(DateDistance other)
        {
            return Ago == other.Ago &&
                   Units == other.Units;
        }

        /// <summary>
        /// Computed the hashcode.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hashCode = -1014845370;
            hashCode = hashCode * -1521134295 + Ago.GetHashCode();
            hashCode = hashCode * -1521134295 + Units.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// The equals operator, uses <see cref="Equals(DateDistance)"/>
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(DateDistance left, DateDistance right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Diff operator; uses the negative result of equals
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(DateDistance left, DateDistance right)
        {
            return !(left == right);
        }
    }

    /// <summary>
    /// Date unit kind for ago disstance
    /// </summary>
    public enum DateUnits
    {
        /// <summary>
        /// Represent the day of week.
        /// </summary>
        RightNow,

        /// <summary>
        /// Represent the day of week.
        /// </summary>
        LessMinute,

        /// <summary>
        /// Represent the day of week.
        /// </summary>
        Minute,

        /// <summary>
        /// Represent the day of week.
        /// </summary>
        Hour,

        /// <summary>
        /// Represent the day of week.
        /// </summary>
        Day,

        /// <summary>
        /// Represent the day of week.
        /// </summary>
        Week,

        /// <summary>
        /// Represent the day of week.
        /// </summary>
        Month,

        /// <summary>
        /// Represent the day of week.
        /// </summary>
        Year
    }
}