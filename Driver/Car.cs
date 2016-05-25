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
        private int _shift = -5; // oznacza o ile ma przesuwac sie auto
        private int _fieldHeight;
        private int _fieldWidth;
        private int _carHeight = 40;
        private int _carWidth = 80;

        public Car(Graphics canva)
        {
            Point = new Point(50, 300);
            Color = Color.Red;
            Field = canva;
            _fieldHeight = (int)canva.VisibleClipBounds.Height;
            _fieldWidth = (int)canva.VisibleClipBounds.Width;
        }

        public override void paint()
        {
            Size size = new Size(_carWidth, _carHeight);
            Rectangle rectangle = new Rectangle(Point, size);
            Field.FillRectangle(Brushes.Red, rectangle);
        }

        public override void move(int xShift)
        {
            if (Point.Y < 0)
                _shift = 5;
            else if (Point.Y > _fieldHeight - _carHeight)
                _shift = -5;
            Point = new Point(Point.X, Point.Y + _shift);
        }
    }
}
