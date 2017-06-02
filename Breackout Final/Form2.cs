using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breackout_Final
{
    public partial class Form2 : Form
    {
        public Form2(string Time, string Record, string Points)
        {
            InitializeComponent();
            txtTiempo.Text = Time;
            txtRecord.Text = Record;
            txtPuntos.Text = Points;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}
