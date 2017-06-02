using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Breackout_Final
{
    class Brick : PictureBox
    {
        public Rectangle rectangle;

        public Brick(int X, int Y, Color color)
        {
            BackColor = color;

            Left = X;
            Top = Y;
            Width = 70;
            Height = 30;

            rectangle = new Rectangle(Left, Top, Width, Height);
        }

        public Rectangle Rectangles
        {
            get { return rectangle; }
            set { rectangle = value; }
        }
    }
}
