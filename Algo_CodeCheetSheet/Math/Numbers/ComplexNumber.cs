namespace Math
{
    public class ComplexNumber
    {
        public double RealPart { get; set; }
        public double ImaginaryPart { get; set; }

        public ComplexNumber(double realPart = 0, ImaginaryNumber imPart = null)
        {
            this.RealPart = realPart;
            this.ImaginaryPart = 0d;
            CalcImaginaryPart(imPart);
        }
        public ComplexNumber(ComplexNumber other)
        {
            this.RealPart = other.RealPart;
            this.ImaginaryPart = other.ImaginaryPart;
        }

        /// <summary>
        /// This function decides if the power of the given i number makes it
        /// a part of the real number.
        /// For example :
        /// i^2 = -1 in this case the value of the imPart is added to the real number
        /// </summary>
        private void CalcImaginaryPart(ImaginaryNumber imPart)
        {
            int modFour = imPart.Power % 4;

            switch (modFour)
            {
                case 0: this.RealPart += imPart.Value; break;
                case 1: this.ImaginaryPart = imPart.Value; break;
                case 2: this.RealPart += -imPart.Value; break;
                case 3: this.ImaginaryPart = -imPart.Value; break;
            }
        }

        public ComplexNumber Add(ComplexNumber other) 
        {
            double real = this.RealPart + other.RealPart;
            double im = this.ImaginaryPart + other.ImaginaryPart;
            return new ComplexNumber(real, new ImaginaryNumber(im));
        }

        public ComplexNumber Sub(ComplexNumber other) 
        {
            double real = this.RealPart - other.RealPart;
            double im = this.ImaginaryPart - other.ImaginaryPart;
            return new ComplexNumber(real, new ImaginaryNumber(im));
        }

        /// <summary>
        /// (a + bi)*(c + di) = a*c + a*d*i + b*c*i + d*b*i^2
        /// real part = a*c - d*b
        /// imaginary part = (a*d + b*c)*i
        /// </summary>
        public ComplexNumber Mult(ComplexNumber other) 
        {
            double a = this.RealPart;
            double b = this.ImaginaryPart;
            double c = other.RealPart;
            double d = other.ImaginaryPart;

            double real = (a * c - d * b);
            double im = (a * d + b * c);

            return new ComplexNumber(real, new ImaginaryNumber(im));
        }

        /// <summary>
        /// (a + bi)   (c - di)    (a + bi)*(c - di)
        /// ________ * ________ =  _________________
        /// (c + di)   (c - di)     c * c + d * d
        /// 
        /// real part = (a*c + b*d) / (c*c + d*d)
        /// imaginary part = (b*c - a*d)*i / (c*c + d*d)
        /// </summary>
        public ComplexNumber Dev(ComplexNumber other) 
        {
            double a = this.RealPart;
            double b = this.ImaginaryPart;
            double c = other.RealPart;
            double d = other.ImaginaryPart;

            double real = (a * c + b * d) / (c * c + d * d);
            double im = (b * c - a * d) / (c * c + d * d);

            return new ComplexNumber(real, new ImaginaryNumber(im));
        }

        /// <summary>
        /// The absolute value is the distance to the zero or the
        /// Pythagorean theorem where the real part = a and the imaginary = b
        /// |(a + bi)| = sqrt(a * a + b * b)
        /// </summary>
        public double Abs() 
        {
            double a = this.RealPart;
            double b = this.ImaginaryPart;
            return System.Math.Sqrt(a * a + b * b);
        }

        /// <summary>
        /// (a + bi) has a conjugate == (a - bi)
        /// </summary>
        public ComplexNumber Conjugate() 
        {
            return new ComplexNumber(this.RealPart, new ImaginaryNumber(-this.ImaginaryPart));
        }

        public override bool Equals(object obj)
        {
            if (obj is ComplexNumber)
            {
                var other = obj as ComplexNumber;

                if (other.RealPart == this.RealPart &&
                    other.ImaginaryPart == this.ImaginaryPart)
                {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.RealPart.GetHashCode() ^ this.ImaginaryPart.GetHashCode();
        }

        public static bool operator ==(ComplexNumber lhs, ComplexNumber rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ComplexNumber lhs, ComplexNumber rhs)
        {
            return !lhs.Equals(rhs);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}i", this.RealPart, this.ImaginaryPart);
        }
    }
}
