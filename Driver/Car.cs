using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Driver
{
    public class Car : MovingObject
    {
        private int shift = -5;
        public Car()
        {
            Point = new Point(50, 300);
            Color = Color.Red;
        }

        public override void paint()
        {
            Size size = new Size(80, 30);
            Rectangle rectangle = new Rectangle(Point, size);
            Field.DrawRectangle(new Pen(Color), rectangle);
        }

        public override void move()
        {
            if (Point.Y < 5)
                shift = 5;
            else if (Point.Y > 329)
                shift = -5;
            Point = new Point(Point.X, Point.Y + shift);
        }
    }
}
