using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driver
{
    public partial class Form1 : Form
    {
        enum Direction
        {
            n, s, e, w,
        }
        private Direction _currentDirection;

        //private bool KeyUp = false;
        //private bool _keyDown = false;
        //private bool _keyRight = false;
        //private bool _keyLeft = false;

        private int _step = 25;


        private int _carShift = 0;
        private int _obstacleShift = 0;
        private Random _random = new Random();
        public Graphics canva { get; set; }
        private List<Obstacle> _obstacles = new List<Obstacle> { };
        private Car _car;
        PushedKeys pushedKeys;

        protected override CreateParams CreateParams // nie miga
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public Form1()
        {
            InitializeComponent();
            canva = splitContainer1.Panel2.CreateGraphics();
            _car = new Car(canva);
            pushedKeys = new PushedKeys();
        }

        private void paintObstaclesAndCar()
        {
            foreach (Obstacle obs in _obstacles)
            {
                obs.paint();
            }
            _car.paint();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (pushedKeys.KeyUp == true)
            {
                _carShift--;
            }
            if (pushedKeys.KeyDown == true)
            {
                _carShift++;
            }
            if (pushedKeys.KeyLeft == true)
            {
                if (_obstacleShift < 10)
                    _obstacleShift++;
            }
            if (pushedKeys.KeyRight == true)
            {
                if(_obstacleShift>-20)
                    _obstacleShift--;
            }

            slowDown();





            //_obstacleShift = _random.Next(-3, 4);
            splitContainer1.Panel2.Invalidate();
            foreach (Obstacle obs in _obstacles)
            {
                obs.move(_obstacleShift);
                obs.paint();
            }
            _car.paint();
            _car.move(_carShift);
            Invalidate();
        }

        private void slowDown()
        {
            if (_obstacleShift > 0 && pushedKeys.KeyLeft == false)
                _obstacleShift--;
            if (_obstacleShift < 0 && pushedKeys.KeyRight == false)
                _obstacleShift++;
            if (_carShift > 0 && pushedKeys.KeyDown == false)
                _carShift--;
            if (_carShift < 0 && pushedKeys.KeyUp == false)
                _carShift++;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            paintObstaclesAndCar();
        }

        private void splitContainer1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                _currentDirection = Direction.e;
                pushedKeys.KeyRight = true;
            }
            else if (e.KeyCode == Keys.A)
            {
                _currentDirection = Direction.w;
                pushedKeys.KeyLeft = true;
            }
            else if (e.KeyCode == Keys.S)
            {
                _currentDirection = Direction.s;
                pushedKeys.KeyDown = true;
            }
            else if (e.KeyCode == Keys.W)
            {
                _currentDirection = Direction.n;
                pushedKeys.KeyUp = true;
            }
            else if (e.KeyCode == Keys.Space)
            {
                Point point = new Point(400, 50);
                Color color = Color.Black;
                Obstacle obstacle = new Obstacle(point, color, canva);
                _obstacles.Add(obstacle);
                paintObstaclesAndCar();
                timer.Enabled = true;
            }
        }

        private void splitContainer1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                rightKeyUp();
            }
            else if (e.KeyCode == Keys.A)
            {
                leftKeyUp();
            }
            else if (e.KeyCode == Keys.S)
            {
                downKeyUp();
            }
            else if (e.KeyCode == Keys.W)
            {
                upKeyUp();
            }
        }

        private void rightKeyUp()
        {
            pushedKeys.KeyRight = false;
            _obstacleShift++;
        }

        private void leftKeyUp()
        {
            pushedKeys.KeyLeft = false;
            _obstacleShift--;
        }

        private void downKeyUp()
        {
            pushedKeys.KeyDown = false;
            _carShift = 0;
        }

        private void upKeyUp()
        {
            pushedKeys.KeyUp = false;
            _carShift = 0;
        }
    }
}
