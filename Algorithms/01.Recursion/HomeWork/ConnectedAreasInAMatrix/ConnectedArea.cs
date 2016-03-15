namespace ConnectedAreasInAMatrix
{
    using System;
    using System.Collections.Generic;

    public class ConnectedArea : IComparable<ConnectedArea>
    {
        public Move Start { get; set; }
        public int Size { get; set; }

        public ConnectedArea() 
        {
            this.Start = new Move();
            this.Size = 1;
        }
        public ConnectedArea(Move start) 
        {
            this.Start = start;
            this.Size = 1;
        }

        public int CompareTo(ConnectedArea other)
        {
            int sizeDelta = this.Size.CompareTo(other.Size);

            if (sizeDelta != 0 )
                return this.Size.CompareTo(other.Size);
            else 
                return this.Start.CompareTo(other.Start);
        }
    }
}
