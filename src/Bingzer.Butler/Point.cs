using System;

namespace Bingzer.Butler
{
    public class Point
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point()
            : this(0, 0)
        {
        }

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Point) obj);
        }

        protected bool Equals(Point other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode()*397) ^ Y.GetHashCode();
            }
        }

        public override string ToString()
        {
            return X + "," + Y;
        }

        public void Parse(string str)
        {
            var split = str.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            X = float.Parse(split[0]);
            Y = float.Parse(split[1]);
        }
    }
}
