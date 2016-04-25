using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MI
{
    public class Point : IEquatable<Point>
    {
        public Int32 X = 0, Y = 0;
        public Point(Int32 x, Int32 y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Point other)
        {
            if (other == null)
                return false;

            if (this.X == other.X && this.Y == other.Y)
                return true;
            else
                return false;
        }

        public override bool Equals(Object other)
        {
            if (other == null)
                return false;

            Point pointObj = other as Point;
            if (pointObj == null)
                return false;
            else
                return Equals(pointObj);
        }
    }
}
