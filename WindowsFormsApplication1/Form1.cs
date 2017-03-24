using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;




namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        private XmlDocument configXml = new XmlDocument();
        private XmlDocument TextosXml = new XmlDocument();
        private string ficConfig;

        string Nom, Cl;
        XmlElementoSer XmlConfig;
        Globales Var;
        XmlNode n;

        
        public Login(XmlElementoSer x,Globales V)
        {
            
            try
            {                
                InitializeComponent();
                pictureBox1.BackColor = Color.Transparent;
                pictureBox2.BackColor = Color.Transparent;
                pictureBox3.BackColor = Color.Transparent;
                CKClave.BackColor = Color.Transparent;
                groupBox1.BackColor = Color.Transparent;
                pictureBox1.Parent = pictureBox4;
                pictureBox2.Parent = pictureBox4;
                pictureBox3.Parent = pictureBox4;
                CKClave.Parent = pictureBox4;
                groupBox1.Parent = pictureBox4;

                XmlConfig = x;
                Var = V;
                if (!System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Eventos"))
                {
                    System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Eventos");
                }
                if(!System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Eventos\\Signal.xml"))
                {
                    System.IO.File.Copy("Signal.xml", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Eventos\\Signal.xml", true);
                }
                ficConfig = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Eventos\\Signal.xml";
                configXml.Load(ficConfig);
                
                TextosXml.Load("Textos.xml");
                
                n = configXml.SelectSingleNode("Login");
                if (n != null)
                {
                    TUsuario.Text = n.ChildNodes.Item(0).InnerText;
                    TClave.Text = Funciones.DEncript(n.ChildNodes.Item(1).InnerText);
                }

                n = TextosXml.SelectSingleNode("Textos");
                if (n != null)
                {
                    CKClave.Text = n.ChildNodes.Item(0).InnerText;
                }
                
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
                    Var.VCerrar = true;
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
            try
            {
                if (TUsuario.TextLength <= 0)
                {
                    MessageBox.Show("Ingrese un Usuario");
                    return;
                }
                if (TClave.TextLength <= 0)
                {
                    MessageBox.Show("Ingrese clave");
                    return;
                }

                Var.VNombre = TUsuario.Text;
                Var.Clave = TClave.Text;
                Var.VCerrar = false;
                Close();
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
           try
            {                
                n = configXml.SelectSingleNode("Login");
                if (n != null)
                {
                    n.ChildNodes.Item(0).InnerText = TUsuario.Text;
                    if (CKClave.Checked)
                    {
                        n.ChildNodes.Item(1).InnerText = Funciones.Encript(TClave.Text);
                    }
                    else
                    {
                        n.ChildNodes.Item(1).InnerText = "";
                    }
                }
                configXml.Save(ficConfig);
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

       


    }
}
