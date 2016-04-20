namespace Helpers_v2
{
    using System;

    public struct Fraction
    {
        private long numerator;
        private long denominator;
        private decimal result;

        public Fraction(long numerator, long denominator)
            : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
            this.result = (decimal)this.Numerator / (decimal)this.Denominator;
        }
        public Fraction(Fraction otherFraction)
            : this()
        {
            this.Numerator = otherFraction.Numerator;
            this.Denominator = otherFraction.Denominator;
            this.result = (decimal)this.Numerator / (decimal)this.Denominator;
        }

        #region Properties

        public long Numerator
        {
            get { return this.numerator; }
            private set
            {
                this.numerator = value;
            }
        }

        public long Denominator
        {
            get { return this.denominator; }
            private set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Denominator can't be zero. Devision by zero is illegal.");
                }

                this.denominator = value;
            }
        }

        #endregion

        public Fraction Add(Fraction other)
        {
            long newDenominator = OperationsOnNumbers.CalcGCD(this.Denominator, other.Denominator);
            newDenominator = newDenominator == 1 ? this.Denominator * other.Denominator : newDenominator;

            long newNumerator = this.Numerator * (newDenominator / this.Denominator)
                + other.Numerator * (newDenominator / other.Denominator);

            Fraction additionResult = new Fraction(newNumerator, newDenominator);
            return additionResult;
        }

        public Fraction Subtract(Fraction other)
        {
            long newDenominator = OperationsOnNumbers.CalcGCD(this.Denominator, other.Denominator);
            newDenominator = newDenominator == 1 ? this.Denominator * other.Denominator : newDenominator;

            long newNumerator = this.Numerator * (newDenominator / this.Denominator)
                - other.Numerator * (newDenominator / other.Denominator);

            Fraction additionResult = new Fraction(newNumerator, newDenominator);
            return additionResult;
        }

        public static Fraction operator +(Fraction lhs, Fraction rhs)
        {
            return lhs.Add(rhs);
        }

        public static Fraction operator -(Fraction lhs, Fraction rhs)
        {
            return lhs.Subtract(rhs);
        }

        public override string ToString()
        {
            return this.result.ToString();
        }
    }
}
