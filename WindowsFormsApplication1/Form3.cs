using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public delegate void Pn(string text); 
    public partial class Plan : Form
    {
        public Plan()
        {
           
            InitializeComponent();
            this.Size = new Size(100, this.Size.Height);           
        }
        private void Pnn(string v)
        {
            if (TR.InvokeRequired)
            {
                Pn C = new Pn(Pnn);
                this.Invoke(C, new object[] { v });
            }
            else
            {
                if (v == "")
                {
                    TR.Text = "";
                }
                else
                {
                    TR.Text = v;                    
                }
                TR.Refresh();
            }
        }
        private void Plan_Shown(object sender, EventArgs e)
        {
            int i = 100;
            while (this.Size.Width < 338)
            {
                this.Size = new Size(i, this.Size.Height);
                i += 10;
                System.Threading.Thread.Sleep(20);
            }
            this.Size = new Size(338,this.Size.Height);
            
        }

        public string InTR
        {
            get { return (TR.Text); }
            set { Pnn(value); }
        }

        private void Plan_LocationChanged(object sender, EventArgs e)
        {
        }

        private void Plan_VisibleChanged(object sender, EventArgs e)
        {               
                
                if (this.Size.Width == 338)
                {
                    this.Size = new Size(1, this.Size.Height);              
                }                
           
        }        
    }
}
