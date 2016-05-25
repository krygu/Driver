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
        private int _carShift = 0;
        private int _obstacleShift = 0;
        private Random _random = new Random();
        public Graphics canva { get; set; }
        private List<Obstacle> _obstacles = new List<Obstacle> { };
        private Car _car { get; set; }

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
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Point point = new Point(400, 50);
            Color color = Color.Black;
            Obstacle obstacle = new Obstacle(point, color, canva);
            _obstacles.Add(obstacle);
            paintObstaclesAndCar();
            timer.Enabled = true;
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
            _obstacleShift = _random.Next(-3, 4);
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

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            paintObstaclesAndCar();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                _obstacleShift = -1;
            }
            else if (e.KeyCode == Keys.A)
            {
                _obstacleShift = 1;
            }
            else if (e.KeyCode == Keys.S)
            {
                _carShift = 1;
            }
            else if (e.KeyCode == Keys.W)
            {
                _carShift = -1;
            }
        }
    }
}
