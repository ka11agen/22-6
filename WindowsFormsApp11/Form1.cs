using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Form1 : Form
    {
        private Point _targetPosition;
        private Point _targetPosition1;
        private Point _targetPosition2;
        private Point _Position;
        private Point _Position1;
        private Point _Position2;
        private Point _direction = Point.Empty;
        SolidBrush brush;
        SolidBrush brush1;
        SolidBrush brush2;
        public Form1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint, true);

            UpdateStyles();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Random rnd = new Random();
            if (radioButton2.Checked == true)
            {
                _targetPosition.X += _direction.X;
                _targetPosition.Y += _direction.Y;
            }
            if (radioButton3.Checked == true)
            {
                _targetPosition1.X += _direction.X;
                _targetPosition1.Y += _direction.Y;
            }
            if (radioButton4.Checked == true)
            {
                _targetPosition2.X += _direction.X;
                _targetPosition2.Y += _direction.Y;
            }

            var TargetRect = new Rectangle(_targetPosition.X, _targetPosition.Y, _Position.X, _Position.Y);
            var TargetRect1 = new Rectangle(_targetPosition1.X, _targetPosition1.Y, _Position1.X, _Position1.Y);
            var TargetRect2 = new Rectangle(_targetPosition2.X, _targetPosition2.Y, _Position2.X, _Position2.Y);

            g.FillRectangle(brush, TargetRect);
            g.FillRectangle(brush1, TargetRect1);
            g.FillRectangle(brush2, TargetRect2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            timer2.Interval = r.Next(25, 500);
            _direction.X = r.Next(-1, 2);
            _direction.Y = r.Next(-1, 2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            _Position.X = r.Next(10, 250);
            _Position1.X = r.Next(10, 250);
            _Position2.X = r.Next(10, 250);
            _Position.Y = r.Next(10, 250);
            _Position1.Y = r.Next(10, 250);
            _Position2.Y = r.Next(10, 250);
            _targetPosition.X = r.Next(0, ClientSize.Width - _Position.X);
            _targetPosition.Y = r.Next(0, ClientSize.Height - _Position.Y);
            _targetPosition1.X = r.Next(0, ClientSize.Width - _Position1.X);
            _targetPosition1.Y = r.Next(0, ClientSize.Height - _Position1.Y);
            _targetPosition2.X = r.Next(0, ClientSize.Width - _Position2.X);
            _targetPosition2.Y = r.Next(0, ClientSize.Height - _Position2.Y);
            int numcolor = r.Next(3);
            switch (numcolor)
            {
                case 0:
                    brush = new SolidBrush(Color.Blue); break;
                case 1:
                    brush = new SolidBrush(Color.Yellow); break;
                case 2:
                    brush = new SolidBrush(Color.Red); break;
            }
            numcolor = r.Next(3);
            switch (numcolor)
            {
                case 0:
                    brush1 = new SolidBrush(Color.Blue); break;
                case 1:
                    brush1 = new SolidBrush(Color.Yellow); break;
                case 2:
                    brush1 = new SolidBrush(Color.Red); break;
            }
            numcolor = r.Next(3);
            switch (numcolor)
            {
                case 0:
                    brush2 = new SolidBrush(Color.Blue); break;
                case 1:
                    brush2 = new SolidBrush(Color.Yellow); break;
                case 2:
                    brush2 = new SolidBrush(Color.Red); break;
            }


        }
    }
}
