using System.Collections.Generic;

namespace Osmosys.Data.ValueRepresentations
{
    public class Range<T>
    {
        public bool IsRange => !Min.Equals(Max);

        public T Min { get; }
        public T Max { get; }
        
        public Range(T value) : this(value, value)
        {
        }

        public Range(T minValue, T maxValue)
        {
            Min = minValue;
            Max = maxValue;
        }
        
        protected bool Equals(Range<T> other)
        {
            return EqualityComparer<T>.Default.Equals(Min, other.Min) && EqualityComparer<T>.Default.Equals(Max, other.Max);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Range<T>) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<T>.Default.GetHashCode(Min) * 397) ^ EqualityComparer<T>.Default.GetHashCode(Max);
            }
        }

        public static bool operator ==(Range<T> left, Range<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Range<T> left, Range<T> right)
        {
            return !Equals(left, right);
        }
    }
}