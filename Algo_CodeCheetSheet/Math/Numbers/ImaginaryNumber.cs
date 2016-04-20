namespace Math 
{
    public class ImaginaryNumber
    {
        public double Value { get; set; }
        public int Power { get; set; }

        public ImaginaryNumber(double value, int power = 1)
        {
            this.Value = value;
            this.Power = power;
        }
    }
}