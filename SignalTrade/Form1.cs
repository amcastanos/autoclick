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
    public partial class Inicio : Form
    {        
        public Inicio()
        {            
            InitializeComponent();
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Parent = pictureBox2;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Web_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void TIm_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
