namespace ConnectedAreasInAMatrix
{
    using System;
    
    public class Move : IComparable<Move>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Move(int x = 0, int y = 0) 
        {
            this.X = x;
            this.Y = y;
        }

        public int CompareTo(Move other)
        {
            int deltaX = this.X.CompareTo(other.X);
            int deltaY = this.Y.CompareTo(other.Y);

            if (deltaX != 0)
                return -deltaX;
            else
                return -deltaY;
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", this.X, this.Y);
        }
    }
}
