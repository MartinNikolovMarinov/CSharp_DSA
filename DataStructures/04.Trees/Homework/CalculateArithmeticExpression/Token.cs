namespace CalculateArithmeticExpression
{

    public class Token
    {
        public string Descriptor { get; set; }
        public object Value { get; set; }

        public Token(string descriptor, object value)
        {
            this.Descriptor = descriptor;
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Descriptor + ' ' + this.Value.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is Token)
            {
                var objAsToken = obj as Token;
                return this.Descriptor == objAsToken.Descriptor && this.Value.Equals(objAsToken.Value);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
