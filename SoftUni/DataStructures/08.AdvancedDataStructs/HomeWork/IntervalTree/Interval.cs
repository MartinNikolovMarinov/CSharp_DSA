namespace IntervalTree
{
    using System;

    public class Interval : IComparable<Interval>
    {
        public int Low { get; set; }
        public int High { get; set; }

        public Interval(int low, int high)
        {
            this.Low = low;
            this.High = high;
        }

        public bool Intersect(Interval other, IntersectType option = IntersectType.Inclusive) 
        {
            if (this.Low > other.Low)
            {
                // This interval is on the left.
                return Intersect(other, this, option);
            }
            else 
            {
                // Other interval is on the left.
                return Intersect(this, other, option);
            }
        }

        public int CompareTo(Interval other)
        {
            int delta = this.Low.CompareTo(other.Low);
            if (delta == 0)
            {
                return this.High.CompareTo(other.High);
            }
            else 
            {
                return delta;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Interval)
            {
                var asInterval = (obj as Interval);
                return asInterval.Low.Equals(this.Low) &&
                    asInterval.High.Equals(this.High);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("[{0}-{1}]", this.Low, this.High);
        }

        private static bool Intersect(Interval leftInterval, Interval rightInterval, IntersectType option = IntersectType.Inclusive)
        {
            if (option == IntersectType.Exclusive)
            {
                return leftInterval.Low < rightInterval.Low && rightInterval.Low < leftInterval.High;
            }
            else
            {
                return leftInterval.Low <= rightInterval.Low && rightInterval.Low <= leftInterval.High;
            }
        }
    }
}
