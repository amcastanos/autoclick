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
using System.Runtime.InteropServices;
using System.Xml;



namespace WindowsFormsApplication1
{
    public partial class PPal : Form
    {
        XmlElementoSer xml;
        string PlanTrabajo = "";
        Socket Sc;
        int Global,Versact,Verserv;
        Globales Variables;
        bool Abre,shift;
        StateObject estado;
        System.Media.SoundPlayer SP;
        System.Media.SoundPlayer S1, S2, S3, S4, Com, Ven, NT, Min1, Min3;
        public delegate void LIST(string[] text);
        public delegate void DTR(string text);
        public delegate void DL(string text);
        public delegate void Pl(string text);
        public delegate void Num(string text);
        public delegate void ImC(bool pv);
        public delegate void ImD(bool pv);
        public delegate void EnT(bool val);
        public delegate void Pn(string text);
        public delegate void LNot(string text);
        public delegate void Cerrar();
        
        Point[] Comprar,Vender;
        DateTime Tiempo;
        private XmlDocument TextosXml = new XmlDocument();
        private XmlDocument DocConf = new XmlDocument();
        XmlNode n,m;

        List<Button> BCompra = new List<Button>();
        List<Button> BVenta = new List<Button>();
        List<PictureBox> ImCompra = new List<PictureBox>();
        List<PictureBox> ImVenta = new List<PictureBox>();

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        private const int MouseEventLeftDown = 0x0002;
        private const int MouseEventLeftUp = 0x0004;
        public System.Diagnostics.Process p = new System.Diagnostics.Process();
        Plan P;

        public PPal()
        {
            try
            {

                bool aux;
                Button B;
                PictureBox Im;
                CheckBox CK;
                aux = false;
                Abre = false;
                InitializeComponent();
                
                this.Size = new Size(711, 379);
                BDesplega.Text = "<<";
                Tabs.TabPages[0].BackColor = Color.Transparent;
                Tabs.TabPages[1].BackColor = Color.Transparent;
                Botones.BackColor = Color.Transparent;
                Tabs.Parent = pictureBox1;
                Botones.Parent = pictureBox1;
                label12.BackColor = Color.Transparent;
                label12.Parent = pictureBox2;
                groupBox2.Parent = pictureBox3;
                groupBox1.Parent = pictureBox3;
                panel1.BackColor = Color.Transparent;
                panel1.Parent = groupBox1;
                LCon.BackColor = Color.AliceBlue;
                PDes.BackColor = Color.Transparent;
                PCon.BackColor = Color.Transparent;
                PDes.Parent = pictureBox1;
                PCon.Parent = pictureBox1;
                LPlant.BackColor = Color.Transparent;
                LPlant.Parent = pictureBox1;

                LCalen.BackColor = Color.Transparent;
                LCalen.Parent = pictureBox1;

                PCon.BringToFront();
                PDes.BringToFront();
                
                Variables = new Globales();
                RBDC.Checked = true;
                xml = new XmlElementoSer();
                xml.Open(ref aux);
          
               // this.Size = new System.Drawing.Size(pictureBox1.Size.Width + (pictureBox1.Size.Width)/46,(Tabs.Size.Height + 2 * Botones.Size.Height));
                //this.Size = new System.Drawing.Size(Convert.ToInt16(Screen.PrimaryScreen.WorkingArea.Width / 1.92), Convert.ToInt16(Screen.PrimaryScreen.WorkingArea.Height / 1.8));
                SP = new System.Media.SoundPlayer("Sonido.wav");
                Com = new System.Media.SoundPlayer("Compra.wav");
                Ven = new System.Media.SoundPlayer("Venta.wav");
                NT = new System.Media.SoundPlayer("Notrade.wav");
                S1 = new System.Media.SoundPlayer("Sonido1.wav");
                S2 = new System.Media.SoundPlayer("Sonido2.wav");
                S3 = new System.Media.SoundPlayer("Sonido3.wav");
                S4 = new System.Media.SoundPlayer("Sonido4.wav");
                Min1 = new System.Media.SoundPlayer("1min.wav");
                Min3 = new System.Media.SoundPlayer("3min.wav");                
                Sonido.Visible = false;
                Maxi.Visible = false;
                Comprar = new Point[10];
                Vender = new Point[10];
               
                TextosXml.Load("Textos.xml");
                DocConf.Load("Config.xml");

                m = DocConf.SelectSingleNode("Config");

                if (m != null)
                {
                    Versact = Convert.ToInt16(m.ChildNodes.Item(2).InnerText);
                }

                n = TextosXml.SelectSingleNode("Textos");
                if (n != null)
                {
                    Tabs.TabPages[0].Text = n.ChildNodes.Item(1).InnerText;
                    Tabs.TabPages[1].Text = "Clicker";
                    Lb.Text = n.ChildNodes.Item(2).InnerText;
                    label12.Text = n.ChildNodes.Item(12).InnerText;
                    Hor.Text = n.ChildNodes.Item(13).InnerText;
                    LPlant.Text = n.ChildNodes.Item(15).InnerText;
                    LCalen.Text = n.ChildNodes.Item(16).InnerText;
                }

                foreach(Panel P in groupBox1.Controls)
                {
                    foreach (Control Bu in P.Controls)
                    {
                        if (Bu is Button)
                        {
                            B = (Button)Bu;
                            if (B.Name.IndexOf("BCompra") > -1)
                            {
                                BCompra.Add(B);
                                B.MouseUp += new MouseEventHandler(Compra_MousUp);
                            }
                            else
                            {
                                if (B.Name.IndexOf("BVenta") > -1)
                                {
                                    BVenta.Add(B);
                                    B.MouseUp += new MouseEventHandler(Venta_MousUp);
                                }
                            }
                            B.Enabled = false;
                        }
                        else
                        {
                            if (Bu is PictureBox)
                            {
                                Im = (PictureBox)Bu; 
                                if (Im.Name.IndexOf("CompraIm") > -1)
                                {
                                    ImCompra.Add(Im);
                                }
                                else
                                {
                                    if (Im.Name.IndexOf("VentaIm") > -1)
                                    {
                                        ImVenta.Add(Im);
                                    }
                                }
                            }
                            if (Bu is CheckBox)
                            {
                                CK = (CheckBox)Bu;
                                CK.CheckedChanged += new EventHandler(CK_Enable);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
                MessageBox.Show(ex.Message);
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
                    LUsuarios.Items.AddRange(txt);
                    LUsuarios.Refresh();
                }
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }
        private void CCerrar()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    Cerrar MR = new Cerrar(CCerrar);
                    this.Invoke(MR, new object[] { });
                }
                else
                {
                    Close();
                }
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }
        private void ImaC(bool v)
        {
            if (PCon.InvokeRequired)
            {
                ImC C = new ImC(ImaC);
                this.Invoke(C, new object[] { v });
            }
            else
            {
                PCon.Visible = v;
                PCon.Refresh();
            }
        }
        private void LNo(string v)
        {
            if (LNoticias.InvokeRequired)
            {
                LNot C = new LNot(LNo);
                this.Invoke(C, new object[] { v });
            }
            else
            {
                LNoticias.Items.Clear();
                while (v.IndexOf("\n") > -1)
                {
                    LNoticias.Items.Add(v.Substring(0, v.IndexOf("\n")) + " New York");
                    v = v.Substring(v.IndexOf("\n") + 1);
                }
                
            }
        }
        private void Plt(string v)
        {
                if (RTPlan.InvokeRequired)
                {
                    Pl C = new Pl(Plt);
                    this.Invoke(C, new object[] { v });
                }
                else
                {
                    if (v == "")
                    {
                        RTPlan.Text = "";
                    }
                    else
                    {
                        RTPlan.AppendText(v + "\n"); ;
                    }
                    RTPlan.Refresh();
                }
            
        }
        private void ImaD(bool v)
        {
            if (PDes.InvokeRequired)
            {
                ImC C = new ImC(ImaD);
                this.Invoke(C, new object[] { v });
            }
            else
            {
                PDes.Visible = v;
                PDes.Refresh();
            }
        }
        private void EnableT(bool val)
        {
            if (TW.InvokeRequired)
            {
                EnT C = new EnT(EnableT);
                this.Invoke(C, new object[] { val });
            }
            else
            {
                TW.Enabled = val;
                BEnviar.Enabled = val;
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
                    if (Mute.Visible)
                    {
                        SP.Play();
                    }
                    tam = TR.TextLength; 
                    TR.AppendText(txt + "\n");

                    
                    if (txt.IndexOf("--" + (char)32) > -1)
                    {
                        TR.Select((TR.TextLength - txt.Length)-1, txt.Length);                        
                        TR.SelectionColor = Color.Red;
                    }
                    TR.Refresh();
                }
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }
        private void InNumero(string txt)
        {
            try
            {
                if (Numero.InvokeRequired)
                {
                    Num MR = new Num(InNumero);
                    this.Invoke(MR, new object[] { txt });
                }
                else
                {
                    Numero.Text = txt;
                    Numero.Refresh();
                }
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }
        private void InL(string txt)
        {
            try
            {
                if (LCon.InvokeRequired)
                {
                    DL MR = new DL(InL);
                    this.Invoke(MR, new object[] { txt });
                }
                else
                {
                    LCon.Text = txt;
                    LCon.Refresh();
                }
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
                Sc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                Sc.Connect(new IPEndPoint(IPAddress.Parse(xml.VIP), xml.VPort));                
            }
            catch (Exception ex)
            {               
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
                MessageBox.Show("No se pudo conectar con el servidor");
                Close();
            }
        }
        public void ReadCallback(IAsyncResult ar)
        {
            string[] Clientes=null;
            String content = String.Empty;
            string Name = string.Empty;
            string pasw = string.Empty;

            int valor,longitud = 0;
            valor = 0;
            // Retrieve the state object and the handler socket
            // from the asynchronous state object.            
            StateObject state = (StateObject) ar.AsyncState;
            Socket handler = state.workSocket;

            state.sb.Clear();
            //state.sb.Remove(0, state.sb.Length);
            // Read data from the client socket. 
            try
            {
                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There  might be more data, so store the data received so far.
                    state.sb.Append( Encoding.GetEncoding(437).GetString(
                        state.buffer, 0, bytesRead));

                    // Check for end-of-file tag. If it is not there, read 
                    // more data.

                    content = state.sb.ToString();

                    if (content.IndexOf(/*(char)22 + "$\r"*/"#\r") > -1)
                    {
                        // All the data has been read from the 
                        // client. Display it on the console.
                       // longitud = LUsuarios.Items.Count;
                       // Clientes = Funciones.Captura(content,ref valor); 
                        valor = Convert.ToInt16(content.Substring(2,1));
                        
                        switch (valor)
                        {
                            case 0:
                                {                                    
                                    MessageBox.Show("Clave Errada o Usuario no existe!!");
                                    fin();
                                } break;
                            case 1:
                                {
                                    MessageBox.Show("Licencia vencida!!");
                                    fin();
                                } break;
                            case 2:
                                {
                                    Verserv = Convert.ToInt16(content.Substring(3, content.IndexOf("*/#")-3));
                                    if (Verserv > Versact)
                                    {
                                        MessageBox.Show("Existe una versión más reciente, se comenzará a descargar");
                                        System.Diagnostics.Process.Start("Updater.exe");
                                        Sc.Shutdown(SocketShutdown.Both);
                                        Sc.Close();
                                        Application.Exit();
                                    }
                                    Tiempo = DateTime.Now;
                                    ImaC(true);
                                    ImaD(false);                                    
                                    InL("Conectado");
                                   /* if (longitud < Clientes.Length)
                                    {
                                        InTR(Clientes[Clientes.Length - 1] + " se ha unido a la charla");
                                    }
                                    AList(Clientes);                                   */
                                    Loin(true);
                                } break;
                            case 4:
                                {
                                    MessageBox.Show("Usuario ya inicio sesión desde otro equipo!!");
                                    fin();
                                } break;
                        }
                        return;
                    }
                    else
                    {
                        if (content.IndexOf(/*(char)22 + "$\r"*/"&\r") > -1)
                        {
                            if (TW.Enabled == true)
                            {
                                SP.Play();
                            }
                            Tiempo = DateTime.Now;
                            if (content.IndexOf((char)11 + "&\r") > -1)
                            {
                                if (content.IndexOf((char)7) >= 0)
                                {
                                    if (content.IndexOf((char)7) == 0)
                                    {
                                        PlanTrabajo = "";
                                    }
                                    else
                                    {
                                        PlanTrabajo = content.Substring(0, content.IndexOf((char)7) - 1);
                                    }
                                    Plt(PlanTrabajo);
                                }
                                LNo(content.Substring(content.IndexOf((char)7) + 1, content.Length - 3 - (content.IndexOf((char)7) + 1)));
                            }
                            else
                                InTR(content.Substring(0, content.Length - 2));
                            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                            new AsyncCallback(ReadCallback), state);                            
                        }
                        else
                        {
                            if (content.IndexOf("$" + (char)24 + "\r") > -1)
                            {
                                NT.Play();
                                if (n != null)
                                {                                    
                                    Lb.Text = n.ChildNodes.Item(5).InnerText;
                                }                                
                                Tiempo = DateTime.Now;
                                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                new AsyncCallback(ReadCallback), state);  
                            }
                            else
                            {
                                if (content.IndexOf("$" + (char)22 + "\r") > -1)
                                {
                                    SendClick(Comprar);
                                    Com.Play();
                                    if (n != null)
                                    {
                                        Lb.Text = n.ChildNodes.Item(3).InnerText;
                                    }     
                                    Tiempo = DateTime.Now;
                                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                    new AsyncCallback(ReadCallback), state);  
                                }
                                else
                                {
                                    if (content.IndexOf("$" + (char)23 + "\r") > -1)
                                    {
                                        SendClick(Vender);
                                        Ven.Play();
                                        if (n != null)
                                        {
                                            Lb.Text = n.ChildNodes.Item(4).InnerText;
                                        }     
                                        Tiempo = DateTime.Now;
                                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                        new AsyncCallback(ReadCallback), state);                                       
                                    }
                                    else
                                    {
                                        if (content.IndexOf("$" + (char)25 + "\r") > -1)
                                        {
                                            Tiempo = DateTime.Now;
                                            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                            new AsyncCallback(ReadCallback), state);                                            
                                        }
                                        else
                                        {
                                            if (content.IndexOf("$" + (char)26 + "\r") > -1)
                                            {                                                
                                                S1.Play();
                                                if (n != null)
                                                {
                                                    InTR("--" + (char)32 + n.ChildNodes.Item(6).InnerText);
                                                }    
                                                
                                                Tiempo = DateTime.Now;
                                                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                                new AsyncCallback(ReadCallback), state);
                                            }
                                            else
                                            {
                                                if (content.IndexOf("$" + (char)27 + "\r") > -1)
                                                {
                                                    S2.Play();
                                                    if (n != null)
                                                    {
                                                        InTR("--" + (char)32 + n.ChildNodes.Item(7).InnerText);
                                                    }                                                    
                                                    Tiempo = DateTime.Now;
                                                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                                    new AsyncCallback(ReadCallback), state);
                                                }
                                                else
                                                {
                                                    if (content.IndexOf("$" + (char)28 + "\r") > -1)
                                                    {
                                                        S3.Play();
                                                        if (n != null)
                                                        {
                                                            InTR("--" + (char)32 + n.ChildNodes.Item(8).InnerText);
                                                        }                                                    
                                                        Tiempo = DateTime.Now;
                                                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                                        new AsyncCallback(ReadCallback), state);
                                                    }
                                                    else
                                                    {
                                                        if (content.IndexOf("$" + (char)29 + "\r") > -1)
                                                        {
                                                            S4.Play();
                                                            if (n != null)
                                                            {
                                                                InTR("--" + (char)32 + n.ChildNodes.Item(9).InnerText);
                                                            }                                                    
                                                            Tiempo = DateTime.Now;
                                                            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                                            new AsyncCallback(ReadCallback), state);
                                                        }
                                                        else
                                                        {
                                                            if (content.IndexOf("$" + (char)30 + "\r") > -1)
                                                            {
                                                                InNumero(content.Substring(0, content.Length - 3));
                                                                Tiempo = DateTime.Now;
                                                                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                                                new AsyncCallback(ReadCallback), state);
                                                            }
                                                            else
                                                            {
                                                                if (content.IndexOf("$" + (char)18 + "\r") > -1)
                                                                {                                                                    
                                                                    EnableT(false);
                                                                    InTR("Se desactiva el chat, concentrados en la noticia");                                                                   
                                                                    Tiempo = DateTime.Now;
                                                                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                                                    new AsyncCallback(ReadCallback), state);
                                                                }
                                                                else
                                                                {
                                                                    if (content.IndexOf("$" + (char)19 + "\r") > -1)
                                                                    {
                                                                        EnableT(true);
                                                                        InTR("Activado de nuevo el chat");
                                                                        Tiempo = DateTime.Now;
                                                                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                                                        new AsyncCallback(ReadCallback), state);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (content.IndexOf("$" + (char)5 + "\r") > -1)
                                                                        {
                                                                            Min3.Play();
                                                                            if (n != null)
                                                                            {
                                                                                InTR("--" + (char)32 + n.ChildNodes.Item(10).InnerText);
                                                                            }     
                                                                            Tiempo = DateTime.Now;
                                                                            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                                                            new AsyncCallback(ReadCallback), state);
                                                                        }
                                                                        else
                                                                        {
                                                                            if (content.IndexOf("$" + (char)6 + "\r") > -1)
                                                                            {
                                                                                Min1.Play();
                                                                                if (n != null)
                                                                                {
                                                                                    InTR("--" + (char)32 + n.ChildNodes.Item(11).InnerText);
                                                                                }
                                                                                Tiempo = DateTime.Now;
                                                                                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                                                                new AsyncCallback(ReadCallback), state);
                                                                            }
                                                                            else
                                                                            {
                                                                                if (content.IndexOf("$" + (char)8 + "\r") > -1)
                                                                                {
                                                                                    if (n != null)
                                                                                    {
                                                                                        InTR("--" + (char)32 + n.ChildNodes.Item(14).InnerText);
                                                                                    }
                                                                                    Tiempo = DateTime.Now;
                                                                                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                                                                    new AsyncCallback(ReadCallback), state);
                                                                                }
                                                                                else
                                                                                {
                                                                                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                                                                    new AsyncCallback(ReadCallback), state);
                                                                                }        
                                                                            }        
                                                                        }        
                                                                    }                                                                  
                                                                }
                                                            }
                                                        }

                                                    }
                                                }
                                            }                                           
                                        }                                      
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El servidor se ha desconectado");
                    System.Threading.Thread.Sleep(2000);
                    Application.Restart();
                }
            }
            catch (Exception ex)
            {                
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                   new AsyncCallback(ReadCallback), state);
            }
        }
        private void PPal_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Size = new System.Drawing.Size(pictureBox1.Size.Width + (pictureBox1.Size.Width) / 46, (Tabs.Size.Height + 2 * Botones.Size.Height)); 
                FTServerCode();
                Loin(false);
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void Loin(bool h)
        {
            try
            {
                if (h)
                {
                    //      Enabled = true;
                    estado.workSocket.BeginReceive(estado.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReadCallback), estado);
                    return;
                }
                Variables.VCerrar = false;
                Login Lg = new Login(xml, Variables);
                Lg.ShowDialog();
                if (Variables.VCerrar)
                {
                    Close();
                    return;
                }
                Send(Sc, "/*" + Variables.Nombre + "$" + Variables.Clave + "*/#\r");
               estado = new StateObject();
                estado.workSocket = Sc;
                estado.workSocket.BeginReceive(estado.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReadCallback), estado);
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }
        private void Send(Socket handler, String data)
        {
            // Convert the string data to byte data using ASCII encoding.
            try
            {
                byte[] byteData = Encoding.GetEncoding(437).GetBytes(data);
                handler.BeginSend(byteData, 0, byteData.Length, 0,
                    new AsyncCallback(SendCallback), handler);
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

        private void BEnviar_Click(object sender, EventArgs e)
        {
            if (TW.TextLength == 0)
            {
                return;
            }
            try
            {
                Send(Sc, TW.Text + "&\r");
                TW.Text = "";
                SP.Play();
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
                Sc.Shutdown(SocketShutdown.Both);
                Sc.Disconnect(true);
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void Mute_Click(object sender, EventArgs e)
        {
            try
            {
                Sonido.Visible = true;
                Mute.Visible = false;
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void Sonido_Click(object sender, EventArgs e)
        {
            try
            {
                Sonido.Visible = false;
                Mute.Visible = true;
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

        private void Tim_Tick(object sender, EventArgs e)
        {
            try
            {
                Hora.Text = HoraNY();
                Global++;
                if (Global >= 300)
                {
                    TimeSpan TS = DateTime.Now - Tiempo;
                    if (TS.TotalSeconds > 100)
                    {                        
                        ImaD(true);
                        ImaC(false);
                        InL("Desconectado");
                        Sc.Shutdown(SocketShutdown.Both);
                        Sc.Disconnect(true);
                        MessageBox.Show("Se perdió comunicación con servidor");
                        Application.Restart();
                    }
                    else
                    {
                        ImaD(false);
                        ImaC(true);
                        InL("Conectado");
                    }
                    Global = 0;
                }
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void Mini_Click(object sender, EventArgs e)
        {
            try
            {
                Maxi.Visible = true;
                Mini.Visible = false;
                this.Size = new Size(375, 85);
                if (P != null)
                {
                    BPlan.Text = "Plan>";
                    P.Close();
                    Abre = false;

                }

                Location = new Point(Screen.PrimaryScreen.Bounds.Width - 375, Screen.PrimaryScreen.Bounds.Height - 120);
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void Maxi_Click(object sender, EventArgs e)
        {
            try
            {
                Maxi.Visible = false;
                Mini.Visible = true;
                this.Size = new System.Drawing.Size(Tabs.Size.Width + (pictureBox1.Size.Width) / 46, (Tabs.Size.Height + 2 * Botones.Size.Height)); new System.Drawing.Size(pictureBox1.Size.Width + (pictureBox1.Size.Width) / 46, (Tabs.Size.Height + 2 * Botones.Size.Height)); 
                BDesplega.Text = ">>";
                this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
                this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void TW_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }   

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private Bitmap Foto()
        {
            try
            {
                Graphics gr = this.CreateGraphics();
                // Tamaño de lo que queremos copiar

                // Creamos el bitmap con el área que vamos a capturar
                // En este caso, con el tamaño del formulario actual
                Bitmap bm = new Bitmap(65, 65);
                // Un objeto Graphics a partir del bitmap
                Graphics gr2 = Graphics.FromImage(bm);
                // Copiar el área de la pantalla que ocupa el formulario

                gr2.CopyFromScreen(Control.MousePosition.X - 32, Control.MousePosition.Y - 32, 0, 0, new Size(65, 65));

                // Asignamos la imagen al PictureBox
                return(bm);
            }
            catch (Exception ex)
            {                
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
                return (null);
            }
            
        }
       
        private void Compra_MousUp(object sender, MouseEventArgs e)
        {
            Button B = (Button) sender;
            ImCompra[9 - Convert.ToInt16(B.Name.Substring(7))].Image = Foto();
            Comprar[9 - Convert.ToInt16(B.Name.Substring(7))] = new Point(Control.MousePosition.X, Control.MousePosition.Y);
        }
        private void Venta_MousUp(object sender, MouseEventArgs e)
        {
            Button B = (Button)sender;
            ImVenta[9 - Convert.ToInt16(B.Name.Substring(6))].Image = Foto();
            Vender[9 - Convert.ToInt16(B.Name.Substring(6))] = new Point(Control.MousePosition.X, Control.MousePosition.Y);
        }   
        public void SendClick(Point[] C)
        {
            try
            {
                foreach (Point P in C)
                {

                    if (P != new Point(0, 0))
                    {
                        SetCursorPos(P.X, P.Y);
                        mouse_event(MouseEventLeftDown, 0, 0, 0, 0);
                        mouse_event(MouseEventLeftUp, 0, 0, 0, 0);
                        if (RBDC.Checked)
                        {
                            mouse_event(MouseEventLeftDown, 0, 0, 0, 0);
                            mouse_event(MouseEventLeftUp, 0, 0, 0, 0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void BCompra1_Click(object sender, EventArgs e)
        {

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
        private void CK_Enable(object sender, EventArgs e)
        {
            CheckBox CK = (CheckBox)sender;
            Panel Pl;

            Pl = (Panel)CK.Parent;
            foreach (Control C in Pl.Controls)
            {
                if (C is Button)
                {
                    if (CK.Checked == true)
                    {
                        C.Enabled = true;                        
                    }
                    else
                    {
                        C.Enabled = false;
                        if(C.Name.IndexOf("Compra") > -1)
                            Comprar[9 - Convert.ToInt16(C.Name.Substring(7))] = new Point(0, 0);
                        else
                            Vender[9 - Convert.ToInt16(C.Name.Substring(6))] = new Point(0, 0);
                    }
                }
                if (C is PictureBox)
                {
                    PictureBox PB;
                    PB = (PictureBox)C;
                    if (CK.Checked == true)
                    {
                        PB.Image = WindowsFormsApplication1.Properties.Resources.Click;
                    }
                    else
                    {
                        PB.Image = WindowsFormsApplication1.Properties.Resources.Block;                        
                    }
                }
            }

        }

        private void fin()
        {
            Sc = null;
            estado = null;
            
            
            Application.ExitThread();
            Application.Restart();
           
            
        }

        private void TR_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            p = System.Diagnostics.Process.Start("IExplore.exe", e.LinkText);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(xml.VURL);
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void BWeb_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(xml.VURL);
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void BFace_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.facebook.com/InversionEnLineaFans");
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void BTwiter_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://twitter.com/InversEnLinea");
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void BYoutube_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/user/InversionEnLinea");
            }
            catch (Exception ex)
            {
                Funciones.Log(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        private void BPlan_Click(object sender, EventArgs e)
        {
            
            if (!Abre)
            {
                BPlan.Text = "Plan<";
                P = new Plan();
                P.Show();
                PPal_LocationChanged(null, null);
                PlanT(PlanTrabajo); 
                Abre = true;
            }
            else
            {
                BPlan.Text = "Plan>";
                P.Close();
                Abre = false;
            }
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
        private void PlanT(string txt)
        {
          /*  if (P != null)
            {
                P.InTR = txt;
            }*/
            Pnn(txt);
        }

        private void PPal_LocationChanged(object sender, EventArgs e)
        {
            if (P != null)
            {
                P.Location = new Point(this.Location.X + this.Size.Width, this.Location.Y + 70);
            }
        }

        private void TW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift)
            {
                shift = true;
            }
            else
            {
                shift = false;
            }
            if (e.KeyValue == 13 && !shift )
            {
                e.SuppressKeyPress = true;
                BEnviar_Click(null, null);
            }
        }

        private void BDesplega_Click(object sender, EventArgs e)
        {
            if (BDesplega.Text == "<<")
            {
                this.Size = new System.Drawing.Size(Tabs.Size.Width + (pictureBox1.Size.Width) / 46, (Tabs.Size.Height + 2 * Botones.Size.Height)); new System.Drawing.Size(pictureBox1.Size.Width + (pictureBox1.Size.Width) / 46, (Tabs.Size.Height + 2 * Botones.Size.Height)); 
                this.Refresh();
                BDesplega.Text = ">>";
            }
            else
            {
                this.Size = new System.Drawing.Size(pictureBox1.Size.Width + (pictureBox1.Size.Width) / 46, (Tabs.Size.Height + 2 * Botones.Size.Height)); 
                BDesplega.Text = "<<";
            }
        }

     
      
      
    } 
}
