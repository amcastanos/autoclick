using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SignalTrade
{
    public partial class Usuarios : Form
    {
        BDS BD;
        BindingSource BS;
        bool Vp;
        string Mailto, Tit, Tex;
        XmlElementoSer Xl;  
        public Usuarios(BDS B,bool VVIP,XmlElementoSer X)
        {
            try
            {
                InitializeComponent();
                toolStrip1.BackColor = Color.Transparent;
                groupBox2.BackColor = Color.Transparent;
                groupBox1.BackColor = Color.Transparent;
                groupBox2.Location = new Point(13,155);

                toolStrip1.Parent = pictureBox1;
                groupBox2.Parent = pictureBox1;
                groupBox1.Parent = pictureBox1;
                

                Xl = X;
                Vp = VVIP;
                BD = B;
                BS = new BindingSource();
                BS.DataSource = BD.Tabla("Usuarios");
                BS.Filter = "VIP='" + VVIP + "'";
                DG.DataSource = BS;
                DG.Columns[0].Visible = DG.Columns[2].Visible = DG.Columns[4].Visible = DG.Columns[5].Visible = DG.Columns[7].Visible = false;

                TUsuario.DataBindings.Add(new Binding("Text", BS, "Usuario"));
                TUsuario.DataBindings[0].DataSourceUpdateMode = DataSourceUpdateMode.Never;

                TMail.DataBindings.Add(new Binding("Text", BS, "Correo"));
                TMail.DataBindings[0].DataSourceUpdateMode = DataSourceUpdateMode.Never;

                CHAdmin.DataBindings.Add(new Binding("Checked", BS, "Administrador"));
                CHAdmin.DataBindings[0].DataSourceUpdateMode = DataSourceUpdateMode.Never;
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void TCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void DG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void BLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                TUsuario.Text = TMail.Text = TDias.Text = "";
                CHAdmin.Checked = false;
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void Usuarios_Shown(object sender, EventArgs e)
        {
            try
            {
                BLimpiar_Click(null, null);
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {            
            DataRow[] DRC;
            DataRow DR;
            string Clave,espira;
            System.Threading.Thread TR = new System.Threading.Thread(Enviar);

            Clave = Funciones.Contra(6);

            if (TUsuario.TextLength <= 0)
            {
                MessageBox.Show("Escriba Usuario!!!");
                return;
            }
            if (TMail.TextLength <= 0)
            {
                MessageBox.Show("Escriba el correo!!!");
                return;
            }

            if (Convert.ToInt32(TDias.Text) <= 0)
            {
                MessageBox.Show("Escriba los días!!!");
                return;
            }

            if (!Funciones.validarEmail(TMail.Text))
            {
                MessageBox.Show("Escriba un correo válido!!!");
                return;
            }


            Tex = "Hola,\n\r¡¡FELICITACIONES!! el acceso a AutoclickNews está listo.\n\rUsuario: " + TUsuario.Text + "\n\rContraseña: " + Clave + "\n\rBienvenido a bordo y que generes miles de dólares!\n\rLender & Jorge\n\rPD. No responder este correo ya que no lo revisamos.\n\r*****************************\n\r";
            Tex += "Hello,\n\r¡¡CONGRATULATIONS!! access to AutoClickNews is ready.\n\rUser: " + TUsuario.Text + "\n\rPassword: " + Clave + "\n\rWelcome and generate thousands of dollars!\n\rLender & Jorge\n\rPD. Não responda este e-mail porque não revisado.\n\r*****************************\n\r";
            Tex += "Olá,\n\r¡¡PARABÉNS! acesso a AutoClickNews está pronto..\n\rUsuário: " + TUsuario.Text + "\n\rSenha: " + Clave + "\n\rBem-vindo e gerar milhares de dólares!\n\rLender & Jorge\n\rPD. Do not reply this email because will not review.\n\r*****************************\n\r";

            espira = DTFecha.Value.AddDays(Convert.ToInt32(TDias.Text)).ToString("yyyy/MM/dd"); 

            try
            {
                DRC = BD.Tabla("Usuarios").Select("Usuario='" + TUsuario.Text + "' AND VIP='" + Vp + "'");
                if (DRC.Length > 0)
                {
                    if (MessageBox.Show("Usuario ya existe, ¿Desea Modificarlo?", "¡ADVERTENCIA!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (!(BD.BD("UPDATE Usuarios SET Correo='" + TMail.Text + "', Clave='" + Funciones.Encriptar(Clave) + "', Administrador=" + CHAdmin.Checked + ", VIP=" + Vp + ", Expira='" + espira + "' WHERE Usuario='" + TUsuario.Text + "'")))
                        {
                            MessageBox.Show("Revise los datos, el registro no puede ser guardado");
                            return;
                        }
                        DR = BD.NuevoR("Usuarios");
                        DR["Usuario"] = TUsuario.Text;
                        DR["Clave"] = Funciones.Encriptar(Clave);
                        DR["Correo"] = TMail.Text;
                        DR["Administrador"] = CHAdmin.Checked;
                        DR["Expira"] = espira;
                        DR["VIP"] = Vp;
                        BD.Eliminar("Usuarios", DRC[0]);
                        BD.Agregar("Usuarios", DR);
                        Mailto = DR["Correo"].ToString();
                        Tit = "AutoClickNews Access / Acceso AutoclickNews / Acesso AutoClickNews";                        
                        TR.Start();
                    }
                    return;
                }
                if (!(BD.BD(string.Format("INSERT INTO Usuarios (Usuario,Clave,Administrador,VIP,Correo,Expira) values ('{0}','{1}',{2},{3},'{4}','{5}')", TUsuario.Text, Funciones.Encriptar(Clave), CHAdmin.Checked, Vp, TMail.Text,espira))))
                {
                    MessageBox.Show("Revise los datos, el registro no puede ser guardado");
                    return;
                }
                DR = BD.NuevoR("Usuarios");
                DR["Usuario"] = TUsuario.Text;
                DR["Clave"] = Funciones.Encriptar(Clave);
                DR["Administrador"] = CHAdmin.Checked;
                DR["Correo"] = TMail.Text;
                DR["Expira"] = espira;
                DR["VIP"] = Vp;
                BD.Agregar("Usuarios", DR);
                Mailto = DR["Correo"].ToString();
                Tit = "AutoClickNews Access / Acceso AutoclickNews / Acesso AutoClickNews";                
                TR.Start();
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }
        private void Enviar()
        {
            try
            {
                Funciones.Mail(Xl.VEmail, Mailto, Tit, Tex, Xl.VClave, Xl.VHost, Xl.VPort);
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void TUsuario_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TimeSpan TS = DateTime.Parse(DG.CurrentRow.Cells[8].Value.ToString()) - DateTime.Now.Date;
                if (TS.Days > 0)
                {
                    TDias.Text = TS.Days.ToString();
                }
                else
                {
                    TDias.Text = "0";
                }
            }
            catch (Exception ex)
            {
                TDias.Text = "0";            
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));            
            }
        }

        private void BEliminar_Click(object sender, EventArgs e)
        {
            DataRow[] DRC;
            DataRow DR;
            
            if (TUsuario.TextLength <= 0)
            {
                MessageBox.Show("Escriba Usuario!!!");
                return;
            }        

            
            try
            {
                DRC = BD.Tabla("Usuarios").Select("Usuario='" + TUsuario.Text + "' AND VIP='" + Vp + "'");
                if (DRC.Length > 0)
                {
                    if (MessageBox.Show("Desea eliminar a " + TUsuario.Text, "¡ADVERTENCIA!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (!(BD.BD("DELETE FROM Usuarios WHERE Usuario='" + TUsuario.Text + "'")))
                        {
                            MessageBox.Show("Revise los datos, el registro no puede ser borrado");
                            return;
                        }                        
                        BD.Eliminar("Usuarios", DRC[0]);                        
                    }
                    return;
                }                
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }
    }
}
