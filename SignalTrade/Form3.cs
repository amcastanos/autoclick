using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Xml;



namespace SignalTrade
{
    public struct COPYDATASTRUCT
	{
	    public IntPtr dwData;
	    public int cbData;
	    [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]
	    public string lpData;
	}
    public partial class PPal : Form
    {
        XmlElementoSer xml;
        XmlNode n;
        XmlDocument DocConf = new XmlDocument();
        public const int WM_COPYDATA = 0x4A;
        BDS BD;
        bool Pulsado, notn=false, Tm = true, Um = true, NT = true;
        string txt,PlanTrabajo="";
        Globales Variables;
        CUsuarios Clientes;
        System.Threading.Thread THR;
        IPEndPoint ipEnd;
        BindingSource BS; 
        Socket sock, Sc;
        int Global,Boton,version;
        Thread OICR;
        static ManualResetEvent allDone;
        public delegate void LIST(string[] text);
        public delegate void DTR(string text);
        public delegate void InL(string text);
        bool aux, compvent = false;
        Usuario Uex;
        System.Media.SoundPlayer SP;
        DataTable DTN;
        DateTime HN = DateTime.Now;

        public PPal()
        {
            try
            {
                aux = false;
                Pulsado = false;
                InitializeComponent();
                Botones.BackColor = Color.Transparent;
                pictureBox1.BackColor = Color.Transparent;
                pictureBox2.BackColor = Color.Transparent;
                pictureBox3.BackColor = Color.Transparent;
                pictureBox4.BackColor = Color.Transparent;
                Botones.Parent = pictureBox5;
                pictureBox1.Parent = pictureBox5;
                pictureBox2.Parent = pictureBox5;
                pictureBox3.Parent = pictureBox5;
                pictureBox4.Parent = pictureBox5;

                xml = new XmlElementoSer();
                BD = new BDS();
                Variables = new Globales();                                
                xml.Open(true, ref aux);
                Variables.VVIP = aux;
                BD.Open(xml.VConex, true, xml.VTablas);
                BD.BD("DELETE FROM Noticias WHERE Fecha<'" + string.Format("{0:yyyy/MM/dd HH:mm}", FechNY2()) + "'");
                System.Threading.Thread.Sleep(200);
                BD.Open(xml.VConex, true, xml.VTablas);
                BS = new BindingSource();
                BS.DataSource = BD.Tabla("Usuarios");
                BS.Filter = "VIP='" + Variables.VVIP + "'";
                Clientes = new CUsuarios();
                SP = new System.Media.SoundPlayer("Sonido.wav");
                pictureBox2.Visible = false;
                DGNot.DataSource = BD.Tabla("Noticias");
                DGNot.Columns[0].Visible = false;
                DGNot.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                DGNot.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                DocConf.Load("Config.xml");
                n = DocConf.SelectSingleNode("Config");
                if (n != null)
                {
                    version = Convert.ToInt16(n.ChildNodes.Item(3).InnerText);
                }
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Calendario AcD = new Calendario();
                AcD.ShowDialog();
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        

        private void Tim_Tick(object sender, EventArgs e)
        {
            TimeSpan ts;
            try
            {
                Hora.Text = HoraNY();

                Global++;
                if (Global >= 150)
                {
                    Global = 0;
                    Send(Sc, "$" + (char)25 + "\r", true);
                    BD.BD("SELECT * FROM Noticias ORDER BY fecha ASC");
                    DTN = BD.Tabla("Noticias");
                    //DTN = BD.Tabla("Noticias","SELECT * FROM Noticias ORDER BY ");
                    if (DTN.Rows.Count > 0)
                    {
                        if(TNotP.Text != DTN.Rows[0].ItemArray[1].ToString())
                        {
                            notn = true;
                            Tm = false;
                            Um = false;
                            NT = false;
                            compvent = false;
                        }
                        TNotP.Text = DTN.Rows[0].ItemArray[1].ToString();                        
                        HN = Convert.ToDateTime(DTN.Rows[0].ItemArray[2].ToString());
                        ts = HN - FechNY2(); 
                        if (ts.TotalSeconds < 0)
                        {
                            BD.BD("DELETE FROM Noticias WHERE Fecha<'" + string.Format("{0:yyyy/MM/dd HH:mm}",FechNY2()) + "'");
                            System.Threading.Thread.Sleep(200);
                            BD.Open(xml.VConex, true, xml.VTablas);
                            DGNot.DataSource = BD.Tabla("Noticias");                            
                        }
                    }
                    else
                    {
                        TNotP.Text = "No Hay noticia";
                    }

                    
                }
                if (notn)
                {                   
                   ts = HN - FechNY2();
                    if (ts.Hours == 0 && ts.Minutes == 3 && ts.Seconds == 0 && !Tm)
                    {
                        B3Min_Click(null, null);
                        Tm = true;
                    }
                    if (ts.Hours == 0 && ts.Minutes == 1 && ts.Seconds == 0 && !Um)
                    {
                        B1Min_Click(null, null);
                        Um = true;
                    }
                    if(ts.Hours == 0 && ts.Minutes == 0 && ts.Seconds == -15 && !NT)
                    {
                        notn = false;
                        NT = true;
                        if (!compvent)
                        {
                            BNoTrade_Click(null, null);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private string HoraNY()
        {
            string ret = string.Empty;
            DateTime.Now.ToLocalTime().ToLongTimeString();
            DateTime easternTime = new DateTime(2007, 01, 02, 12, 16, 00);
            string easternZoneId = "Eastern Standard Time";
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById(easternZoneId);
            ret = TimeZoneInfo.ConvertTime(DateTime.Now, easternZone).ToString("HH:mm:ss");    
            return (ret);
        }

        private string FechNY1()
        {
            string ret = string.Empty;
            DateTime.Now.ToLocalTime().ToLongTimeString();
            DateTime easternTime = new DateTime(2007, 01, 02, 12, 16, 00);
            string easternZoneId = "Eastern Standard Time";
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById(easternZoneId);
            ret = TimeZoneInfo.ConvertTime(DateTime.Now, easternZone).ToString("yyyy/MM/dd HH:mm:ss");
            return (ret);
        }

        private DateTime FechNY2()
        {
            DateTime ret;
            DateTime.Now.ToLocalTime().ToLongTimeString();
            DateTime easternTime = new DateTime(2007, 01, 02, 12, 16, 00);
            string easternZoneId = "Eastern Standard Time";
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById(easternZoneId);
            ret = TimeZoneInfo.ConvertTime(DateTime.Now, easternZone);
            return (ret);
        }

        private void InLC(string tx)
        {
            try
            {
                if(LCantidad.InvokeRequired)
                {
                    InL LC = new InL(InLC);
                    this.Invoke(LC,new object[] { tx });
                }
                else
                {
                    LCantidad.Text = tx;
                }
            }

            catch(Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }
        private void AList(string[] txt)
        {
            try
            {
                if (LUsuarios.InvokeRequired)
                {
                    LIST MR = new LIST(AList);
                    this.Invoke(MR, new object[] { txt });
                }
                else
                {
                    LUsuarios.Items.Clear();
                    LUsuarios.Items.AddRange(Clientes.VNombres);
                    LUsuarios.Refresh();
                }
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }
        private void InTR(string txt)
        {
            int tam = 0;
            try
            {
                if (LUsuarios.InvokeRequired)
                {
                    DTR MR = new DTR(InTR);
                    this.Invoke(MR, new object[] { txt });
                }
                else
                {
                    if (pictureBox1.Visible)
                    {
                        SP.Play();
                    }
                    tam = TR.TextLength; 
                    TR.AppendText(txt + "\n");
                    if (txt.IndexOf("dice:" + (char)31) > -1)
                    {
                        TR.Select(TR.GetFirstCharIndexFromLine(TR.GetLineFromCharIndex(TR.Find("dice:" + (char)31, tam, RichTextBoxFinds.MatchCase))), TR.GetFirstCharIndexFromLine(TR.GetLineFromCharIndex(TR.Find("dice:" + (char)31, tam, RichTextBoxFinds.MatchCase)) + 1) - TR.GetFirstCharIndexFromLine(TR.GetLineFromCharIndex(TR.Find("dice:" + (char)31, tam, RichTextBoxFinds.MatchCase))));
                        TR.SelectionColor = Color.Green;
                    }
                   
                    TR.Refresh();
                }
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void Compra_Click(object sender, EventArgs e)
        {
            compvent = true;
            try
            {
                Send(null, "$" + (char)22 + "\r", true);
                System.Media.SystemSounds.Beep.Play();

                //Clipboard.Clear();
                Pulsado = true;
                OICR = new Thread(LanzaOICR);
                OICR.Start();

                // Clipboard.SetText("&Dato&%");
                
               // Thread.Sleep(2000);
               // IDataObject iData = Clipboard.GetDataObject();

                // Determines whether the data is in a format you can use.
               
                //Send(null, txt + "$" + (char)30 + "\r", true);
                //MessageBox.Show(Nodo.ChildNodes.Item(0).InnerText);
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void PPal_Shown(object sender, EventArgs e)
        {
            try
            {
                Visible = false;

                Variables.VCerrar = false;
                Login Lg = new Login(BD, xml, Variables);
                Lg.ShowDialog();

                if (Variables.VCerrar)
                {
                    Close();
                    return;
                }
                Visible = true;
                Clientes.Agregar(Variables.VNombre, null);
                LUsuarios.Items.Clear();
                LUsuarios.Items.AddRange(Clientes.VNombres);
                FTServerCode();
                THR = new System.Threading.Thread(IniciarSer);
                THR.IsBackground = true;
                THR.Start();
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }
        private void FTServerCode()
        {
            try
            {
                ipEnd = new IPEndPoint(IPAddress.Any, xml.VPorts);
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                sock.Bind(ipEnd);
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }
        private void IniciarSer()
        {

            allDone = new ManualResetEvent(false);
            try
            {
                sock.Listen(200);
                while (true)
                {
                    allDone.Reset();
                    sock.BeginAccept(new AsyncCallback(acceptCallback), sock);
                    allDone.WaitOne();
                }
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }
        void acceptCallback(IAsyncResult ar)
        {
            try
            {
                allDone.Set();

                Socket listener = (Socket)ar.AsyncState;
                Socket handler = listener.EndAccept(ar);

                Usuario Us = new Usuario();
                Us.VSc.workSocket = handler;
                try
                {
                    handler.BeginReceive(Us.VSc.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReadCallback), Us);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        public void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;
            string Name = string.Empty;
            string pasw = string.Empty;

            // Retrieve the state object and the handler socket
            // from the asynchronous state object.
            Usuario Usu = (Usuario)ar.AsyncState; 
            StateObject state = Usu.VSc;
            Socket handler = state.workSocket;

            state.sb.Clear();
            // Read data from the client socket. 
            try
            {
                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There  might be more data, so store the data received so far.
                    state.sb.Append(Encoding.GetEncoding(437).GetString(
                        state.buffer, 0, bytesRead));

                    // Check for end-of-file tag. If it is not there, read 
                    // more data.
                    content = state.sb.ToString();

                    if (content.IndexOf(/*(char)22 + "$\r"*/"#\r") > -1)
                    {
                        // All the data has been read from the 
                        // client. Display it on the console.
                        switch (Funciones.Login(Clientes, BD, content, ref Name, ref pasw))
                        {
                            case 0:
                                {
                                    Send(handler, ("/*0*/#\r"), false);
                                } break;
                            case 1:
                                {
                                    Send(handler, ("/*1*/#\r"), false);
                                } break;
                            case 2:
                                {
                                    Clientes.Agregar(Name, state);
                                    AList(Clientes.VNombres);
                                    Send(handler, ("/*2" + version + "*/#\r"), true);
                                    InTR(Name + " se ha unido a la charla");
                                    InLC((LUsuarios.Items.Count - 1).ToString());                                    
                                    if (BDesactiva.Text == "Activa Chat")
                                    {
                                        Send(handler, ("$" + (char)18 + "\r"), false);
                                        Thread.Sleep(50);
                                    }
                                    if (PlanTrabajo.Length > 5 || DGNot.Rows.Count > 0)
                                    {
                                        Send(handler, (PlanTrabajo + (char)7 + Noticias() + (char)11 + "&\r"), false);                                       
                                    }
                                    state.sb.Clear();
                                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                    new AsyncCallback(ReadCallback), Clientes.ItemArray(Clientes.Length - 1));
                                } break;
                            case 4:
                                {
                                    Send(handler, ("/*4*/#\r"), false);
                                } break;
                        }
                        return;
                    }
                    else
                    {
                        if (content.IndexOf(/*(char)22 + "$\r"*/"&\r") > -1)
                        {
                            if (BDesactiva.Text == "Desactiva Chat")
                            {
                                InTR(Usu.VNombre + " dice:" + (char)31 + "\n" + content.Substring(0, content.Length - 2));
                                Send(handler, (Usu.VNombre + " dice:" + (char)31 + "\n" + content.Substring(0, content.Length - 2) + "&\r"), true);
                            }
                            else
                            {
                                Send(handler, ("$" + (char)18 + "\r"), false);
                            }
                            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                            new AsyncCallback(ReadCallback), Usu);
                           
                        }
                        else
                        {
                            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                            new AsyncCallback(ReadCallback), Usu);                            
                        }
                    }
                }
                else
                {
                    Usu.VSc.workSocket.Shutdown(SocketShutdown.Both);
                    Usu.VSc.workSocket.Disconnect(true);
                    if (Usu.VNombre != "")
                    {
                        InTR("");
                        Clientes.Eliminar(Usu);
                        AList(Clientes.VNombres);
                        Send(handler, (" &\r"), true);
                        Send(handler, ("/*2" + Clientes.VPNombres + "*/#\r"), true);
                        LCantidad.Text = (LUsuarios.Items.Count - 1).ToString();
                    }
                }
            }
            catch (Exception es)
            {
                try
                {
                    Send(handler, ("/*3*/\r"), false);
                }
                catch (Exception ex)
                {                
                    Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));            
                }
            }
        }        

        private string Noticias()
        {
            string Not=string.Empty;
            foreach (DataGridViewRow DRR in DGNot.Rows)
            {
                Not += DRR.Cells[1].Value.ToString() + "\t" + DRR.Cells[2].Value.ToString() + "\n";
            }
            return (Not);
        }
        private void Send(Socket handler, String data, bool difusion)
        {
            // Convert the string data to byte data using ASCII encoding.
            try
            {
                byte[] byteData = Encoding.GetEncoding(437).GetBytes(data);
                if (difusion)
                {
                    for (int f = 1; f < Clientes.Length; f++)
                    {
                        // Begin sending the data to the remote device.
                        try
                        {
                            Clientes.ItemArray(f).VSc.workSocket.BeginSend(byteData, 0, byteData.Length, 0,
                                new AsyncCallback(SendCallback), Clientes.ItemArray(f).VSc.workSocket);
                        }
                        catch(Exception exe)
                        {
                            Clientes.ItemArray(f).VSc.workSocket.Shutdown(SocketShutdown.Both);
                            Clientes.ItemArray(f).VSc.workSocket.Disconnect(false);
                            Clientes.Eliminar(Clientes.ItemArray(f));
                            AList(Clientes.VNombres);
                        }

                    }
                }
                else
                {
                    handler.BeginSend(byteData, 0, byteData.Length, 0,
                            new AsyncCallback(SendCallback), handler);
                }
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);
                //MessageBox.Show(string.Format("Sent {0} bytes to client.", bytesSent));

                // handler.Shutdown(SocketShutdown.Both);
                // handler.Close();            
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox2.Visible = true;
                pictureBox1.Visible = false;
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void BEnviar_Click(object sender, EventArgs e)
        {            
            if (TW.TextLength == 0)
            {
                return;
            }
            SP.Play();
            try
            {
                Send(sock, Clientes.ItemArray(0).VNombre + " dice:" + (char)32 + "\n" + TW.Text + "&\r", true);
                InTR(Clientes.ItemArray(0).VNombre + " dice:" + (char)32 + "\n" + TW.Text);
                TW.Text = "";         
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void TW_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Usuarios UsA = new Usuarios(BD, Variables.VVIP, xml);
                UsA.ShowDialog();
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void Venta_Click(object sender, EventArgs e)
        {
            compvent = true;
            try
            {
                Send(null, "$" + (char)23 + "\r", true);
                System.Media.SystemSounds.Beep.Play();
                //Clipboard.Clear();
                Pulsado = true;
                OICR = new Thread(LanzaOICR);
                OICR.Start();

                // Clipboard.SetText("&Dato&%");
                //Thread.Sleep(2000);
               // IDataObject iData = Clipboard.GetDataObject();

                // Determines whether the data is in a format you can use.
            
            //    Send(null, txt + "$" + (char)30 + "\r", true);                
                //MessageBox.Show(Nodo.ChildNodes.Item(0).InnerText);
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void BNoTrade_Click(object sender, EventArgs e)
        {
         
            
            try
            {
                Send(null, "$" + (char)24 + "\r", true);
                System.Media.SystemSounds.Beep.Play();
                //Clipboard.Clear();
                Pulsado = true;
                OICR = new Thread(LanzaOICR);
                OICR.Start();
      
               // Clipboard.SetText("&Dato&%");
                //Thread.Sleep(2000);
           
                //Send(null,txt + "$" + (char)30 + "\r", true);
                //MessageBox.Show(Nodo.ChildNodes.Item(0).InnerText);
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void PPal_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                for (int h = 1; h < Clientes.Length; h++)
                {
                    Clientes.ItemArray(h).VSc.workSocket.Shutdown(SocketShutdown.Both);
                    Clientes.ItemArray(h).VSc.workSocket.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void TR_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TR.SelectionStart = TR.Text.Length;
                TR.ScrollToCaret();
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

       
        

        private void TMensaje_TextChanged(object sender, EventArgs e)
        {

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
          
        }

        private void B1_Click(object sender, EventArgs e)
        {
            try
            {
                Send(null, "$" + (char)26 + "\r", true);
                System.Media.SystemSounds.Beep.Play();
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void B2_Click(object sender, EventArgs e)
        {
            try
            {
                Send(null, "$" + (char)27 + "\r", true);
                System.Media.SystemSounds.Beep.Play();
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void B3_Click(object sender, EventArgs e)
        {
            try
            {
                Send(null, "$" + (char)28 + "\r", true);
                System.Media.SystemSounds.Beep.Play();
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void B4_Click(object sender, EventArgs e)
        {
            try
            {
                Send(null, "$" + (char)29 + "\r", true);
                System.Media.SystemSounds.Beep.Play();
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void LUsuarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'B' || e.KeyChar == 'b')
            {
               
                Thread Hilo;
                if (LUsuarios.SelectedIndex > 0)
                {
                    if (MessageBox.Show("Desea desconectar a " + LUsuarios.Items[LUsuarios.SelectedIndex].ToString(), "¡ADVERTENCIA!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        InTR(LUsuarios.Items[LUsuarios.SelectedIndex].ToString() + " se ha expulsado de la charla");
                        Uex = Clientes.ExistN(LUsuarios.Items[LUsuarios.SelectedIndex].ToString());
                        Clientes.Eliminar(Clientes.ExistN(LUsuarios.Items[LUsuarios.SelectedIndex].ToString()));
                        AList(Clientes.VNombres);
                        Send(Uex.VSc.workSocket, (" &\r"), true);
                        Send(Uex.VSc.workSocket, ("/*2" + Clientes.VPNombres + "*/#\r"), true);
                        Hilo = new Thread(Desc);
                        Hilo.Start();                        
                    }
                }
            }
        }

        private void LanzaOICR()
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WorkingDirectory = Application.StartupPath + "\\OICR";
                p.StartInfo.FileName = "OICR.exe";
                p.Start();
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void Desc()
        {
            Uex.VSc.workSocket.Disconnect(true);     
        }
        protected override void WndProc(ref Message m)
       {
           
               switch (m.Msg)
               {
                   case WM_COPYDATA:
                       {
                           if (Pulsado)
                           {
                               COPYDATASTRUCT mystr = new COPYDATASTRUCT();
                               Type mytype = mystr.GetType();
                               mystr = (COPYDATASTRUCT)m.GetLParam(mytype);
                               txt = mystr.lpData;
                              // MessageBox.Show(mystr.lpData);
                               Pulsado = false;
                               Send(null, txt + "$" + (char)30 + "\r", true);
                           }
                       } break;
               }
           
            base.WndProc(ref m);
           
      }

        private void Botones_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void BDesactiva_Click(object sender, EventArgs e)
        {
            try
            {
                if (BDesactiva.Text == "Desactiva Chat")
                {                    
                    BDesactiva.Text = "Activa Chat";
                    Send(Sc, "$" + (char)18 + "\r", true);
                }
                else
                {                    
                    BDesactiva.Text = "Desactiva Chat";
                    Send(Sc, "$" + (char)19 + "\r", true);
                }
               
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void LUsuarios_ValueMemberChanged(object sender, EventArgs e)
        {
            
        }

        private void BPlan_Click(object sender, EventArgs e)
        {
            try
            {

                if (TW.TextLength == 0)
                {
                    PlanTrabajo = "";
                }
                else
                {
                    PlanTrabajo += TW.Text + "\n\r";
                    InTR(Clientes.ItemArray(0).VNombre + " dice:\n" + TW.Text);
                    TW.Text = "";
                }               
                SP.Play();               
                //Send(sock, PlanTrabajo + (char)11 + "&\r", true);
                Send(sock, (PlanTrabajo + (char)7 + Noticias() + (char)11 + "&\r"), true);
            }            
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void TW_KeyDown(object sender, KeyEventArgs e)
        {
           
          
        }

        private void PPal_Load(object sender, EventArgs e)
        {

        }

        private void B3Min_Click(object sender, EventArgs e)
        {
            try
            {
                Send(null, "$" + (char)5 + "\r", true);
                System.Media.SystemSounds.Beep.Play();
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void B1Min_Click(object sender, EventArgs e)
        {
            try
            {
                Send(null, "$" + (char)6 + "\r", true);
                System.Media.SystemSounds.Beep.Play();
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            BD.BD(string.Format("INSERT INTO Noticias (Nombre,Fecha) values ('{0}','{1}')", TNoticia.Text, string.Format("{0:yyyy/MM/dd}", DTFecha.Value) + " " + string.Format("{0:HH:mm}",THora.Text+":"+TMin.Text)));
            System.Threading.Thread.Sleep(800);
            BD.Open(xml.VConex, true, xml.VTablas);
            DGNot.DataSource = BD.Tabla("Noticias");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BD.BD("DELETE FROM Noticias WHERE Nombre='" + DGNot.Rows[DGNot.SelectedRows[0].Index].Cells[1].Value.ToString() + "'" );
            System.Threading.Thread.Sleep(800);
            BD.Open(xml.VConex, true, xml.VTablas);
            DGNot.DataSource = BD.Tabla("Noticias");
        }

        private void BCalendar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(850,492);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Size = new Size(505, 492);
        }

        private void BDespedida_Click(object sender, EventArgs e)
        {
            try
            {
                Send(null, "$" + (char)8 + "\r", true);
                System.Media.SystemSounds.Beep.Play();
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }
        }
        
       

    
}
