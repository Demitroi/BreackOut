using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Breackout_Final
{
    class Ball : PictureBox
    {
        private int x, y;
        private Rectangle ballRectangle;
        private int xSpeed, ySpeed, tXSpeed, tYSpeed;
        private Random randSpeed;
        private double per;

        public Ball(int X, int Y)
        {
            randSpeed = new Random();
            x = X;
            y = Y;
            Width = 50;
            Height = 50;
            xSpeed = randSpeed.Next(7, 15);
            ySpeed = randSpeed.Next(7, 15);
            tXSpeed = xSpeed;
            tYSpeed = ySpeed;
            Left = X;
            Top = Y;

            BackgroundImage = Breackout_Final.Properties.Resources.Ball;
            BackgroundImageLayout = ImageLayout.Stretch;
            ballRectangle = new Rectangle(x, y, Width, Height);
        }

        public void MoveBall()
        {
            ballRectangle.X += xSpeed;
            ballRectangle.Y -= ySpeed;
            Left += xSpeed;
            Top -= ySpeed;
        }

        public void ColliBall(int width, int height)
        {
            if (ballRectangle.X <= 1)
            {
                xSpeed = Math.Abs(xSpeed);
            }
            else if (ballRectangle.X >= width - Width - 15)
            {
                xSpeed = -1 * (Math.Abs(xSpeed));
            }
            else if (ballRectangle.Y <= height)
            {
                ySpeed = -1 * (Math.Abs(ySpeed));
            }
        }

        public void ColliPad(Pad pad)
        {
            if (ballRectangle.IntersectsWith(pad.PadRectangle))
            {
                ySpeed = (Math.Abs(ySpeed));
                per = (double)((((Left - pad.Left) + (Width / 2)) * 50 / (pad.Width / 2)) - 50) * 2;
                xSpeed = (int)((per / 100) * tXSpeed);
            }
        }

        public void ColliBrick(Brick cube)
        {
            if (cube.Top + cube.Height <= Top + Height)
            {
                YSpeed = -1 * Math.Abs(YSpeed);
            }
            if (cube.Top >= Top)
            {
                YSpeed = Math.Abs(YSpeed);
            }
            if (cube.Left + cube.Width <= Left + Width)
            {
                XSpeed = Math.Abs(XSpeed);
            }
            if (cube.Left >= Left)
            {
                XSpeed = -1 * Math.Abs(XSpeed);
            }
        }

        public void moreSpeed()
        {
            tXSpeed += 3;
            tYSpeed += 3;
            xSpeed = tXSpeed;
            ySpeed = tYSpeed;
        }

        public bool LooseGame(int height)
        {
            if (ballRectangle.Y > height) return true;
            else return false;
        }

        public Rectangle BallRectangle
        {
            get { return ballRectangle; }
        }

        public int XSpeed
        {
            set { xSpeed = value; }
            get { return xSpeed; }
        }

        public int YSpeed
        {
            set { ySpeed = value; }
            get { return ySpeed; }
        }
    }
}
