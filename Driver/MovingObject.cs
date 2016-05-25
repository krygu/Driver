using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Driver
{
    public abstract class MovingObject
    {
        public Graphics Field { get; set; }
        public Color Color { get; set; }
        public Point Point { get; set; }
        public abstract void paint();
        public abstract void move();
    }
}
