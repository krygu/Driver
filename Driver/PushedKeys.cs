using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver
{
    public class PushedKeys
    {
        public bool KeyUp { get; set; }
        public bool KeyDown { get; set; }
        public bool KeyRight { get; set; }
        public bool KeyLeft { get; set; }

        public PushedKeys()
        {
            KeyUp = false;
            KeyDown = false;
            KeyRight = false;
            KeyLeft = false;
        }
    }
}
