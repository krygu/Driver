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
        public Graphics canva { get; set; }
        private List<Obstacle> _obstacles = new List<Obstacle> { };

        public Form1()
        {
            InitializeComponent();
            canva = splitContainer1.Panel2.CreateGraphics();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Point point = new Point(400, 50);
            Color color = Color.Black;
            Obstacle obstacle = new Obstacle(point,color);
            _obstacles.Add(obstacle);
            _obstacles.Last().Field = canva;
            paintObstacles();
            timer.Enabled = true;
        }

        private void paintObstacles()
        {
            foreach (Obstacle obs in _obstacles)
            {
                obs.paint();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Invalidate();
            foreach (Obstacle obs in _obstacles)
            {
                obs.move();
                obs.paint();
            }
            Invalidate();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            paintObstacles();
        }
    }
}
