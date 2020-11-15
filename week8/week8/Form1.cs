using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week8.Abstractions;
using week8.Entities;


namespace week8
{
    
    public partial class Form1 : Form
    {
        private List<Ball> _toys = new List<Ball>();

        private BallFactory _factory;

        public BallFactory GetFactory()
        { return _factory; }
        public void SetFactory(BallFactory value)
        { _factory = value; }

        public Form1()
        {
            InitializeComponent();
            SetFactory(new BallFactory());
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var ball in _toys)
            {
                ball.MoveToy();
                if (ball.Left > maxPosition)
                    maxPosition = ball.Left;
            }

            if (maxPosition > 1000)
            {
                var oldestBall = _toys[0];
                mainPanel.Controls.Remove(oldestBall);
                _toys.Remove(oldestBall);
            }
        }

        private Toy _nextToy;

        private IToyFactory _factory;
        public IToyFactory Factory
        {
            get { return _factory; }
            set
            {
                _factory = value;
                DisplayNext();
            }
        }


        private void createTimer_Tick(object sender, EventArgs e)
        {
            var ball = GetFactory().CreateNew();
            _toys.Add(ball);
            ball.Left = -ball.Width;
            mainPanel.Controls.Add(ball);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetFactory(new CarFactory());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetFactory(new BallFactory());
        }
    }
}
