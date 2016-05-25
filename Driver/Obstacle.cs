﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Driver
{
    class Obstacle : MovingObject
    {

        public Obstacle(Point point, Color color)
        {
            Point = point;
            Color = color;
        }

        public override void paint()
        {
            Size size = new Size(50, 50);
            Rectangle rectangle = new Rectangle(Point, size);
            Field.DrawRectangle(new Pen(Color), rectangle);
        }

        public override void move()
        {
            Point = new Point(Point.X - 5, Point.Y);
        }
    }
}
