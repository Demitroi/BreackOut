using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Breackout_Final
{
    class Pad : PictureBox
    {
        private Rectangle padRectangle;

        public Pad(int X, int Y)
        {

            Width = 150;
            Height = 20;
            Left = X;
            Top = Y;

            BackgroundImage = Breackout_Final.Properties.Resources.PadStar;
            BackgroundImageLayout = ImageLayout.Stretch;
            padRectangle = new Rectangle(X, Y, Width, Height);
        }

        public void MovePad(int MouseX)
        {
            MouseX = MouseX - (Width / 2);
            padRectangle.X = MouseX;
            Left = MouseX;
        }

        public Rectangle PadRectangle
        {
            get { return padRectangle; }
        }
    }
}
