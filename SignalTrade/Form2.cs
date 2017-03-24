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
    public partial class Login : Form
    {
        XmlElementoSer XmlConfig;
        BDS BD;
        BindingSource BS;
        Globales Cr;
        public Login(BDS B, XmlElementoSer C,Globales V)
        {
            try
            {
                InitializeComponent();
                label1.BackColor = Color.Transparent;
                label2.BackColor = Color.Transparent;
                pictureBox1.BackColor = Color.Transparent;
                label1.Parent = pictureBox2;
                label2.Parent = pictureBox2;
                pictureBox1.Parent = pictureBox2;

                BD = B;
                XmlConfig = C;
                Cr = V;
                BS = new BindingSource();

                BS.DataSource = BD.Tabla("Usuarios");
                BS.Filter = "Administrador=true AND VIP='" + V.VVIP + "'";

                CUsuarios.DataSource = BS;
                CUsuarios.ValueMember = "Usuario";
                CUsuarios.DisplayMember = "Usuario";
                
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void Web_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(XmlConfig.VURL);
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void BCancela_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Esta seguro que desea Salir?", "ADVERTENCIA!!!", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    Cr.VCerrar = true;
                    Close();
                }
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            DataRow[] DRC;
            string c1, c2;

            try
            {
                DRC = BD.Tabla("Usuarios").Select("Usuario='" + CUsuarios.Text + "'");

                TimeSpan duracion = DateTime.Parse(DRC[0].ItemArray[8].ToString()) - DateTime.Today;
                if (duracion.Days < 0)
                {
                    MessageBox.Show("Su licencia a Expirado");
                    Cr.VCerrar = true;
                    Close();
                    return;
                }

                c1 = DRC[0].ItemArray[2].ToString();
                c2 = Funciones.Encriptar(TClave.Text);

                if (c1 != c2)
                {
                    MessageBox.Show("Clave Incorrecta!!!");
                    return;
                }
                Cr.VNombre = CUsuarios.Text;               

                Cr.VCerrar = false;
                Close();
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void TClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    BAceptar_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


    }
}
