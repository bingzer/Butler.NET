using System;

namespace Bingzer.Butler
{
    public class Rectangle
    {
        public Point LeftTop { get; set; }
        public Point RightBottom { get; set; }

        public Rectangle() : this(new Point(), new Point())
        {
        }

        public Rectangle(float left, float top, float right, float bottom)
            : this(new Point(left, top), new Point(right, bottom))
        {
            
        }

        public Rectangle(Point leftTop, Point rightBottom)
        {
            LeftTop = leftTop;
            RightBottom = rightBottom;
        }

        public bool Contains(float x, float y)
        {
            throw new NotImplementedException();
        }

        protected bool Equals(Rectangle other)
        {
            return Equals(LeftTop, other.LeftTop) && Equals(RightBottom, other.RightBottom);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Rectangle) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((LeftTop != null ? LeftTop.GetHashCode() : 0)*397) ^ (RightBottom != null ? RightBottom.GetHashCode() : 0);
            }
        }

        public override string ToString()
        {
            return "Rectangle { " + LeftTop + ", " + RightBottom + "}";
        }
    }
}
