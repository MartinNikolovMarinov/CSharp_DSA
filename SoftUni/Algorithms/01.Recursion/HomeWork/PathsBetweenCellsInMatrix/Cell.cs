namespace PathsBetweenCellsInMatrix
{
    public class Cell
    {
        public char Value { get; set; }
        public bool InTheCurrentPath { get; set; }

        public Cell(char value) 
        {
            this.Value = value;
            this.InTheCurrentPath = false;
        }

        public override string ToString()
        {
            return string.Format("{0}", this.Value);
        }
    }
}
