using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
 

namespace Breackout_Final
{
    public partial class Form1 : Form
    {
        private Pad pad;
        private Ball ball;
        private System.Media.SoundPlayer soundPlayer;
        private List<Brick> listBricks = new List<Brick>();
        private int mouseX;
        private Color color;
        private int puntos, record, min, sec;
        private Form2 resultados;
        private Point cursorPosition = new Point(590, 580);

        public Form1()
        {
            InitializeComponent();
            sec = 0; min = 0; puntos = 0;
            ball = new Ball(565, 580);
            pad = new Pad(565, 630);
            for (int i = 1; i < 6; i++)
            {
                switch (i)
                {
                    case 1:
                        color = Color.Black;
                        break;
                    case 2:
                        color = Color.Red;
                        break;
                    case 3:
                        color = Color.Green;
                        break;
                    case 4:
                        color = Color.Blue;
                        break;
                    case 5:
                        color = Color.Yellow;
                        break;
                }
                for (int j = 0; j < 12; j++)
                {
                    listBricks.Add(new Brick(j * 100 + 40, i * 50 + 10, color));
                }
            }
            this.Controls.Add(pad);
            this.Controls.Add(ball);
            foreach (Brick cube in listBricks)
            {
                this.Controls.Add(cube);
            }
        }

        private void Comprobations()
        {
            ball.ColliBall(this.Size.Width, 50);
            ball.ColliPad(pad);
            for (int i = 0; i < listBricks.Count; i++)
            {
                if (listBricks[i].Rectangles.IntersectsWith(ball.BallRectangle))
                {
                    ball.ColliBrick(listBricks[i]);
                    this.Controls.Remove(listBricks[i]);
                    listBricks.RemoveAt(i);
                    puntos += 10;
                    txtPuntos.Text = puntos.ToString();
                    if (puntos > record)
                    {
                        record = puntos;
                        txtRecord.Text = record.ToString();
                    }
                    if (listBricks.Count == 0)
                    {
                        newLevel();
                    }
                }
            }
            if (ball.LooseGame(this.Size.Height))
            {
                timerBall.Enabled = false;
                timerTime.Enabled = false;
                resultados = new Form2(txtMin.Text + ":" + txtSec.Text, txtRecord.Text, txtPuntos.Text);
                resultados.ShowDialog();
                resetGame();
            }
        }

        private void timerTime_Tick_1(object sender, EventArgs e)
        {
            sec++;
            if (sec >= 60)
            {
                sec = 0;
                min++;
                txtMin.Text = min.ToString("00");
            }
            txtSec.Text = sec.ToString("00");
        }

        private void timerBall_Tick_1(object sender, EventArgs e)
        {
            ball.MoveBall();
            pad.MovePad(mouseX);
            this.Comprobations();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            try
            {
                XmlReader r = XmlReader.Create("Record.xml");
                r.ReadStartElement("Rec");
                txtRecord.Text = r.ReadElementContentAsString();
                record = Convert.ToInt16(txtRecord.Text);
                r.Close();
            }
            catch (Exception)
            {

            }

            soundPlayer = new System.Media.SoundPlayer(Breackout_Final.Properties.Resources.Sound);
            soundPlayer.Play();
        }

        private void Form1_MouseMove_1(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
        }

        private void txtRecord_TextChanged(object sender, EventArgs e)
        {
            try
            {
                XmlWriter w = XmlWriter.Create("Record.xml");
                w.WriteStartElement("Rec");
                w.WriteElementString("TextBox", txtRecord.Text);
                w.WriteEndElement();
                w.Close();
            }
            catch (Exception)
            {

            }
        }

        private void newLevel()
        {
            for (int i = 1; i < 6; i++)
            {
                switch (i)
                {
                    case 1:
                        color = Color.Black;
                        break;
                    case 2:
                        color = Color.Red;
                        break;
                    case 3:
                        color = Color.Green;
                        break;
                    case 4:
                        color = Color.Blue;
                        break;
                    case 5:
                        color = Color.Yellow;
                        break;
                }
                for (int j = 0; j < 12; j++)
                {
                    listBricks.Add(new Brick(j * 100 + 40, i * 50 + 10, color));
                }
            }
            foreach (Brick cube in listBricks)
            {
                this.Controls.Add(cube);
            }
            ball.moreSpeed();
        }

        private void resetGame()
        {
            this.Controls.Remove(pad);
            this.Controls.Remove(ball);
            foreach (Brick cube in listBricks)
            {
                this.Controls.Remove(cube);
            }
            listBricks.Clear();
            ball = null;
            pad = null;
            soundPlayer = null;
            txtPuntos.Text = "0";
            txtSec.Text = "00";
            txtMin.Text = "00";


            sec = 0; min = 0; puntos = 0;
            ball = new Ball(565, 580);
            pad = new Pad(565, 630);
            for (int i = 1; i < 6; i++)
            {
                switch (i)
                {
                    case 1:
                        color = Color.Black;
                        break;
                    case 2:
                        color = Color.Red;
                        break;
                    case 3:
                        color = Color.Green;
                        break;
                    case 4:
                        color = Color.Blue;
                        break;
                    case 5:
                        color = Color.Yellow;
                        break;
                }
                for (int j = 0; j < 12; j++)
                {
                    listBricks.Add(new Brick(j * 100 + 40, i * 50 + 10, color));
                }
            }
            this.Controls.Add(pad);
            this.Controls.Add(ball);
            foreach (Brick cube in listBricks)
            {
                this.Controls.Add(cube);
            }
            try
            {
                XmlReader r = XmlReader.Create("Record.xml");
                r.ReadStartElement("Rec");
                txtRecord.Text = r.ReadElementContentAsString();
                record = Convert.ToInt16(txtRecord.Text);
                r.Close();
            }
            catch (Exception)
            {

            }

            soundPlayer = new System.Media.SoundPlayer(Breackout_Final.Properties.Resources.Sound);
            soundPlayer.Play();
            timerBall.Enabled = true;
            timerTime.Enabled = true;
        }
    }
}
