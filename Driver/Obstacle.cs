using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Driver
{
    class Obstacle : MovingObject
    {

        public Obstacle(Point point, Color color, Graphics canva)
        {
            Point = point;
            Color = color;
            Field = canva;
        }

        public override void paint()
        {
            Size size = new Size(50, 50);
            Rectangle rectangle = new Rectangle(Point, size);
            Field.FillRectangle(Brushes.Black, rectangle);
        }

        public override void move(int xShift)
        {
            Point = new Point(Point.X + xShift, Point.Y);
        }
    }
}
