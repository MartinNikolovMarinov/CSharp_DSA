namespace CalculateArithmeticExpression
{

    public class Tree
    {
        public Token Value { get; set; }
        public double? LeftNumber { get; set; }
        public double? RightNumber { get; set; }

        public Tree(Token value = null) 
        {
            this.Value = value;
            this.LeftNumber = null;
            this.RightNumber = null;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
