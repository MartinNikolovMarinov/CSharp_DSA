namespace _03.RideTheHorse
{
    public class Cell
    {
        public Cell()
        {
            this.X = 0;
            this.Y = 0;
            this.Value = 0;
            this.Visited = false;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Value { get; set; }

        public bool Visited { get; set; }

        public override string ToString()
        {
            return string.Format("(Y={0}, X={1})", this.Y, this.X);
        }
    }
}
