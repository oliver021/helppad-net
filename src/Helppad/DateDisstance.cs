namespace Helppad
{
    using System;

    public readonly struct DateDisstance : IEquatable<DateDisstance>
    {
        public DateDisstance(int ago, DateUnits units)
        {
            Ago = ago;
            Units = units;
        }

        public int Ago { get; }

        public DateUnits Units { get; }

        public override bool Equals(object obj)
        {
            return obj is DateDisstance disstance && Equals(disstance);
        }

        public bool Equals(DateDisstance other)
        {
            return Ago == other.Ago &&
                   Units == other.Units;
        }

        public override int GetHashCode()
        {
            int hashCode = -1014845370;
            hashCode = hashCode * -1521134295 + Ago.GetHashCode();
            hashCode = hashCode * -1521134295 + Units.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(DateDisstance left, DateDisstance right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DateDisstance left, DateDisstance right)
        {
            return !(left == right);
        }
    }

    /// <summary>
    /// Date unit kind for ago disstance
    /// </summary>
    public enum DateUnits
    {
        RightNow,
        LessMinute,
        Minute,
        Hour,
        Day,
        Week,
        Month,
        Year
    }
}