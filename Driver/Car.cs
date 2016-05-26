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
        private int _fieldHeight = 0;
        private int _fieldWidth = 0;
        private int _carHeight = 40;
        private int _carWidth = 80;
        private int _topBound;
        private int _bottomBound;

        public Car(Graphics canva)
        {
            Point = new Point(50, 300);
            Color = Color.Red;
            Field = canva;
            _fieldHeight = (int)canva.VisibleClipBounds.Height;
            _fieldWidth = (int)canva.VisibleClipBounds.Width;
            _topBound = 0;
            _bottomBound = _fieldHeight - _carHeight;
        }

        public override void paint()
        {
            Size size = new Size(_carWidth, _carHeight);
            Rectangle rectangle = new Rectangle(Point, size);
            Field.FillRectangle(Brushes.Red, rectangle);
        }

        public override void move(int yShift)
        {
            if (Point.Y >= 0 && Point.Y <= _fieldHeight - _carHeight)
                Point = new Point(Point.X, Point.Y + yShift);
            if(Point.Y < _topBound) Point = new Point(Point.X, 0);
            if(Point.Y > _bottomBound) Point = new Point(Point.X, _fieldHeight - _carHeight);
        }
    }
}
