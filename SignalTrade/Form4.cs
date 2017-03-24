using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SignalTrade
{
    public partial class Calendario : Form
    {
        public Calendario()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            label1.Parent = pictureBox3;
            pictureBox1.Parent = pictureBox3;
            pictureBox2.Parent = pictureBox3;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
