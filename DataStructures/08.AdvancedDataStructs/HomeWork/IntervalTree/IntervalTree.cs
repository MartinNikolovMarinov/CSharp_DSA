namespace IntervalTree 
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class IntervalTree : IEnumerable<Interval>
    {
        private SortedSet<Interval> intervalSet;

        public IntervalTree()
        {
            this.intervalSet = new SortedSet<Interval>();
        }

        public void Add(Interval interval) 
        {
            this.intervalSet.Add(interval);
        }

        public void Remove(Interval interval) 
        {
            this.intervalSet.Remove(interval);
        }

        public bool IntersectsTheIntervalSet(Interval interval, IntersectType option = IntersectType.Inclusive)
        {
            foreach (var item in this.intervalSet)
            {
                if (interval.Intersect(item, option))
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<Interval> GetIntersects(Interval interval, IntersectType option = IntersectType.Inclusive) 
        {
            foreach (var item in this.intervalSet)
            {
                if (item.Low > interval.High)
                {
                    break;
                }

                if (interval.Intersect(item, option))
                {
                    yield return new Interval(item.Low, item.High);
                }
            }
        }

        public IEnumerator<Interval> GetEnumerator()
        {
            return this.intervalSet.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}