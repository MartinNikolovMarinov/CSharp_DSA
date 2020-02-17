namespace _02.AreasInMatrix
{
    public class Cell
    {
        public char Value { get; set; }
        public bool Visited { get; set; }

        public Cell(char value)
        {
            this.Value = value;
            this.Visited = false;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Value, this.Visited ? "visited" : null);
        }
    }
}
