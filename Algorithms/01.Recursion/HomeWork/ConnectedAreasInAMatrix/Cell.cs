namespace ConnectedAreasInAMatrix
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
            return this.Value.ToString();
        }
    }
}
