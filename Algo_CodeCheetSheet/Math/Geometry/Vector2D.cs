using System;

namespace Math
{
    public class Vector2D
    {
        // Constants
        public static readonly Vector2D ZeroVector = new Vector2D(0, 0);
        public static readonly Vector2D UpVector = new Vector2D(0, 1);
        public static readonly Vector2D DownVector = new Vector2D(0, -1);
        public static readonly Vector2D LeftVector = new Vector2D(-1, 0);
        public static readonly Vector2D RightVector = new Vector2D(1, 0);

        // Constructor
        public Vector2D(double x = 0, double y = 0)
        {
            this.X = x;
            this.Y = y;
        }
        public Vector2D(Vector2D vector) 
        {
            this.X = vector.X;
            this.Y = vector.Y;
        }

        // Properties
        public double X { get; set; }
        public double Y { get; set; }

        // Instance methods
        public void Scale(double scalar)
        {
            this.X = this.X * scalar;
            this.Y = this.Y * scalar;
        }

        public void Add(Vector2D other)
        {
            this.X = this.X + other.X;
            this.Y = this.Y + other.Y;
        }

        public void Sub(Vector2D other)
        {
            this.X = this.X - other.X;
            this.Y = this.Y - other.Y;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector2D)
            {
                Vector2D other = (Vector2D)obj;

                if (this.X == other.X && this.Y == other.Y)
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            byte[] data = BitConverter.GetBytes(this.X);
            int fullX = BitConverter.ToInt32(data, 4);
            int afterDotX = BitConverter.ToInt32(data, 0);

            data = BitConverter.GetBytes(this.Y);
            int fullY = BitConverter.ToInt32(data, 4);
            int afterDotY = BitConverter.ToInt32(data, 0);

            return fullX ^ afterDotX ^ fullY ^ afterDotY;
        }


        public override string ToString()
        {
            return String.Format("[X: {0}, Y: {1}]", this.X, this.Y);
        }

        // Static methods
        public static double CalcDistance(Vector2D vector1, Vector2D vector2) 
        {
            double deltaX = vector1.X - vector2.X;
            double deltxY = vector1.Y - vector2.Y;
            return System.Math.Sqrt(deltaX  * deltaX + deltxY * deltxY);
        }

        public static Vector2D CalcMidPoint(Vector2D vector1, Vector2D vector2)
        {
            double halfX = (vector1.X + vector2.X) / 2;
            double halfY = (vector1.Y + vector2.Y) / 2;
            return new Vector2D(halfX, halfY);
        }

        public static Vector2D Scale(Vector2D vector, double scalar) 
        {
            Vector2D result = new Vector2D(vector);
            result.Scale(scalar);
            return result;
        }

        public static Vector2D Add(Vector2D vector, Vector2D other)
        {
            Vector2D result = new Vector2D(vector);
            result.Add(other);
            return result;
        }

        public static Vector2D Sub(Vector2D vector, Vector2D other)
        {
            Vector2D result = new Vector2D(vector);
            result.Sub(other);
            return result;
        }

        public static Vector2D operator *(Vector2D lhs, double rhs) 
        {
            return Vector2D.Scale(lhs, rhs);
        }

        public static Vector2D operator *(double lhs, Vector2D rhs)
        {
            return Vector2D.Scale(rhs, lhs);
        }

        public static Vector2D operator +(Vector2D lhs, Vector2D rhs)
        {
            return Vector2D.Add(lhs, rhs);
        }

        public static Vector2D operator -(Vector2D lhs, Vector2D rhs)
        {
            return Vector2D.Sub(lhs, rhs);
        }
    }
}
