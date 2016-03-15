namespace Escape_from_Labyrinth
{
    public class Point
    {
        public Point() 
        {
            this.X = 0;
            this.Y = 0;
            this.Direction = null;
            this.PreviousPoint = null;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public string Direction { get; set; }

        public Point PreviousPoint { get; set; }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.X, this.Y);
        } 
    }
}
