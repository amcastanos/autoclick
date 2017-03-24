using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Web;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.IO;
using System.Net.Sockets;

namespace SignalTrade
{
    public class XmlElementoSer
    {
        string Conex,URL,Host,Port,Ports,clave,email;
        string[] TablasDB;
        bool Access;
       

        public void Open(bool Ac,ref bool VIP)
        {
            int Cont;
            
            Access = Ac;
            try
            {
                XmlDocument Archivo = new XmlDocument();//Crea un Objeto XmlDocument.
                Archivo.Load("Config.XML");//Lee el archivo.                                

                XmlNodeList Ruta = Archivo.GetElementsByTagName("RutaDB");//Hace una lista de elementos contenidos por la etiqueta RutaDB
                XmlNodeList Listar = ((XmlElement)Ruta[0]).GetElementsByTagName("DB");//Hace una lista de elementos contenidos por la etiqueta DB en la primera etiqueta RutaDB encontrada.
                foreach (XmlElement Nodo in Listar)//Recorre los elementos en la lista "Listar"
                {
                    if (Access)
                    {
                        Conex = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=";//Crea la ConexionString
                        Conex += Nodo.GetElementsByTagName("Ruta").Item(0).InnerText + ";Jet OLEDB:Database Password=";
                        Conex += Funciones.DEncript(Nodo.GetElementsByTagName("Clave").Item(0).InnerText) + ";";
                    }
                    else
                    {
                        Conex = "data source =" + Nodo.GetElementsByTagName("Ruta").Item(0).InnerText;//Crea la ConexionString
                        Conex += "; initial catalog =" + Nodo.GetElementsByTagName("Nombre").Item(0).InnerText + "; user id =";
                        Conex += Nodo.GetElementsByTagName("Usuario").Item(0).InnerText + "; password =";
                        Conex += Funciones.DEncript(Nodo.GetElementsByTagName("Clave").Item(0).InnerText);
                    }
                }

                XmlNodeList UR = Archivo.GetElementsByTagName("URL");//Hace una lista de elementos contenidos por la etiqueta URL
                URL = ((XmlElement)UR[0]).GetElementsByTagName("web").Item(0).InnerText;//Hace una lista de elementos contenidos por la etiqueta Tabla en la primera etiqueta RutaDB encontrada.
                Ports = ((XmlElement)UR[0]).GetElementsByTagName("PORTSER").Item(0).InnerText;//Hace una lista de elementos contenidos por la etiqueta Tabla en la primera etiqueta RutaDB encontrada.
                
                XmlNodeList Tablas = Archivo.GetElementsByTagName("Tablas");//Hace una lista de elementos contenidos por la etiqueta Tablas
                XmlNodeList LisTablas = ((XmlElement)Tablas[0]).GetElementsByTagName("Tabla");//Hace una lista de elementos contenidos por la etiqueta Tabla en la primera etiqueta RutaDB encontrada.
                TablasDB = new string[LisTablas.Count];
                Cont = 0;
                foreach (XmlElement Nodo in LisTablas)//Recorre los elementos en la lista "Listar"
                {
                    TablasDB[Cont] = Nodo.GetElementsByTagName("Nombre").Item(0).InnerText;
                    Cont++;
                }

                XmlNodeList VI = Archivo.GetElementsByTagName("Servicios");//Hace una lista de elementos contenidos por la etiqueta URL
                VIP = Convert.ToBoolean(((XmlElement)VI[0]).GetElementsByTagName("VIP").Item(0).InnerText);//Hace una lista de elementos contenidos por la etiqueta Tabla en la primera etiqueta RutaDB encontrada.

                XmlNodeList Ho = Archivo.GetElementsByTagName("Mail");//Hace una lista de elementos contenidos por la etiqueta URL
                Host = ((XmlElement)Ho[0]).GetElementsByTagName("Host").Item(0).InnerText;//Hace una lista de elementos contenidos por la etiqueta Tabla en la primera etiqueta RutaDB encontrada.
                               
                Port = ((XmlElement)Ho[0]).GetElementsByTagName("Port").Item(0).InnerText;//Hace una lista de elementos contenidos por la etiqueta Tabla en la primera etiqueta RutaDB encontrada.
                                
                email = ((XmlElement)Ho[0]).GetElementsByTagName("Email").Item(0).InnerText;//Hace una lista de elementos contenidos por la etiqueta Tabla en la primera etiqueta RutaDB encontrada.

                clave = ((XmlElement)Ho[0]).GetElementsByTagName("Clave").Item(0).InnerText;//Hace una lista de elementos contenidos por la etiqueta Tabla en la primera etiqueta RutaDB encontrada.
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("No se pudo cargar el archivo de configuración"); 
                Funciones.Log(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        public string VURL
        {
            get { return (URL); }
        }
        public string VConex
        {
            get { return(Conex);}
        }
        public string[] VTablas
        {
            get { return (TablasDB); }
        }
        public string VHost
        {
            get { return (Host); }
        }
        public string VEmail
        {
            get { return (email); }
        }
        public int VPort
        {
            get { return (Convert.ToInt16(Port)); }
        }
        public int VPorts
        {
            get { return (Convert.ToInt16(Ports)); }
        }
        public string VClave
        {
            get { return (Funciones.DEncript(clave )); }
        }
    }
    class Funciones
    {
        public static string Encript(string A)
        {
            string R;
            R = "";
            char l;
            for (int i = 0; i < A.Length; i++)
            {
                l = Convert.ToChar((Convert.ToInt16(A[i]) + ((i + 1) * 2)));
                R = R.Insert(R.Length, l.ToString());
            }
            return (R);
        }
        public static string DEncript(string A)
        {
            string R;
            R = "";
            char l;
            for (int i = 0; i < A.Length; i++)
            {
                l = Convert.ToChar((Convert.ToInt16(A[i]) - ((i + 1) * 2)));
                R = R.Insert(R.Length, l.ToString());
            }
            return (R);
        }

        public static string Encriptar(string str)
        {
            SHA1 sha1 = SHA1Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha1.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        public static string Contra(int Tam)
        {
            string Base = "abcdefghijkmlnopqrstuvwxyzABCDEFGHIJKMLNOPQRSTUVWXYZ1234567890";
            string r = "";

            Random Semilla = new Random();
            for (int i = 0; i < Tam; i++)
            {
                r += Base[Semilla.Next(0, 62)];
            }
            return (r);
        }

        public static void Mail(string EmailFrom,string Mailto,string Tit,string Tex,string Clave,string Host, int Port)
        {
                        
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(EmailFrom, "Traders Lender & Jorge");
                mail.To.Add(Mailto);
                mail.Subject = Tit;
                mail.Body = Tex;
                mail.IsBodyHtml = false;
                mail.Priority = MailPriority.Normal;

                using (SmtpClient smtp = new SmtpClient(Host, Port))
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential(EmailFrom, Clave);                    
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    try
                    {
                        smtp.Send(mail);
                    }
                    catch (System.Net.Mail.SmtpException ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }
                }
            }
           
        }

        public static void Log(string Ruta,string Tex)
        {
            
            StreamWriter Wr;
            
            string Archivo = "\\Eventos\\Eventos" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + ".txt";
            Ruta = Ruta.Substring(6);

            Wr = File.AppendText(Ruta + Archivo);     
            
            try
            {          
                Wr.NewLine = "\r\n";
                Wr.Write(Wr.NewLine);
                Wr.Write(DateTime.Now.ToLongTimeString() + ": " + Tex);                
                Wr.Close();
            }
            catch(Exception ex)
            {
                 Wr.Close();
            }
        }
        public static int Login(CUsuarios Us, BDS Base, string txt,ref string Nom,ref string cl)
        {            
            string[] res;

            res = Captura(txt);

            if (res.Length == 2)
            {
                Nom = res[0];
                cl = res[1];
            }
            else
            {
                return (0);
            }

            DataRow[] DRC;
            try
            {
                if (Us.Exist(Nom))
                {
                    return (4);
                }
                DRC = Base.Tabla("Usuarios").Select("Usuario='" + Nom + "' AND VIP='false'");
                if (DRC.Length > 0)
                {
                    TimeSpan duracion = DateTime.Parse(DRC[0].ItemArray[8].ToString()) - DateTime.Today;
                    if (duracion.Days < 0)
                    {
                        return (1);
                    }
                    if (DRC[0].ItemArray[2].ToString() == Encriptar(cl))
                    {
                        return (2);
                    }
                }
                else
                {
                    return (0);
                }
                return (0);
            }
            catch (Exception ex)
            {
                return (0);
            }
        }
        public static string[] Captura(string cadena)
        {
            int ini,fin,aux,cont,ind,ind2;
            string[] retorno;
            

            ini = cadena.IndexOf("/*");
            fin = cadena.IndexOf("*/"); 

            if(ini > fin || ini==fin || ini == -1 || fin == -1)
            {
                return(null);
            }

            cadena = cadena.Substring(ini + 2,fin - ini);
                       
            cont = ind = 0;
            while(cadena.Substring(ind + 1).IndexOf("$") > -1)
            {
                cont++;
                ind = cadena.Substring(ind).IndexOf("$");
            }
            cont++;

            retorno = new string[cont];

            cont = 0;
            ind = cadena.IndexOf("$");            
            while(ind > -1)
            {
                retorno[cont] = cadena.Substring(0,ind);
                cadena = cadena.Substring(ind + 1);
                ind = cadena.IndexOf("$");
                cont++;
            }

            retorno[cont] = cadena.Substring(0, cadena.Length - 2);

            return(retorno);
        }
        public static bool validarEmail(string email)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                { return true; }
                else
                { return false; }
            }
            else
            { return false; }
        }
    }
    public class BDS
    {
        OleDbDataAdapter DA;
        OleDbCommandBuilder CB;
        OleDbConnection OleConex;
        SqlDataAdapter DASQL;
        SqlCommandBuilder CBSQL;
        SqlConnection SQLConex;
        DataSet DS;
        DataTable DT;
        bool Access;
        string Conex;

        public void Open(string Con, bool Ac,string[] TablasDB)
        {
            Conex = Con;
            Access = Ac;
            if (Access)
            {
                OleConex = new OleDbConnection(Conex);
            }
            else
            {
                SQLConex = new SqlConnection(Conex);
            }

            int i;
            DS = new DataSet();
            i = 0;

            foreach (string Actual in TablasDB)
            {
                if (Access)
                {
                    DA = new OleDbDataAdapter("SELECT * FROM " + Actual, Conex);//Crea el Adaptador para la tabla TablasBD[i].
                    CB = new OleDbCommandBuilder(DA);
                }
                else
                {
                    DASQL = new SqlDataAdapter("SELECT * FROM " + Actual, Conex);
                    CBSQL = new SqlCommandBuilder(DASQL);
                }
                DT = new System.Data.DataTable();//Crea un Objeto DataTable.
                if (Access)
                {
                    DA.Fill(DT);//Agrega los datos de la Base de datos al DataTable.
                }
                else
                {
                    DASQL.Fill(DT);//Agrega los datos de la Base de datos al DataTable.
                }

                DS.Tables.Add(DT);//Agrega el DataTable al DataSet
                DS.Tables[i].TableName = Actual;//Le fija el nombre al DataTable en el DataSet.

                i++;
            }           
        }
        public bool BD(string Sel)
        {
            try
            {
                CloseBD();
                if (Access)
                {
                    OleConex.Open();
                    OleDbCommand cmd = new OleDbCommand(Sel, OleConex);//Pasa la sentencia a la base de datos.
                    cmd.ExecuteNonQuery();//Ejecuta la Sentencia en la BD.
                    OleConex.Close();//Cierra la Conexion a la Base de Datos
                }
                else
                {
                    SQLConex.Open();
                    SqlCommand cmd = new SqlCommand(Sel, SQLConex);//Pasa la sentencia a la base de datos.
                    cmd.ExecuteNonQuery();//Ejecuta la Sentencia en la BD.
                    SQLConex.Close();//Cierra la Conexion a la Base de Datos
                }
                return (true);
            }
            catch (Exception ex)
            {
                Funciones.Log(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
                return (false);
            }
        }
        public DataRow[] Consulta(string tab, string Sel)
        {
            DataRow[] DR;
            DR = DS.Tables[tab].Select(Sel.Trim());
            return (DR);
        }
        public DataRow NuevoR(string Tab)
        {
            DataRow DR;

            DR = DS.Tables[Tab].NewRow();

            return (DR);
        }
        public System.Data.DataTable Tabla(string N)
        {
            return (DS.Tables[N]);
        }        
        public void Eliminar(string Tab, DataRow DR)
        {
            DS.Tables[Tab].Rows.Remove(DR);
        }
        public bool Agregar(string Tab, DataRow Reg)
        {
            try
            {
                DS.Tables[Tab].Rows.Add(Reg);
                return (true);
            }
            catch (Exception ex)
            {
                return (false);
            }
        }

        public DataSet ValorDS()
        {
            return (DS);
        }

        public System.Data.DataTable Load(string Consulta)
        {
            System.Data.DataTable DTT = new System.Data.DataTable();
            if (Access)
            {
                DA = new OleDbDataAdapter(Consulta, Conex);//Crea el Adaptador para la tabla TablasBD[i].
                CB = new OleDbCommandBuilder(DA);
            }
            else
            {
                DASQL = new SqlDataAdapter(Consulta, SQLConex);//Crea el Adaptador para la tabla TablasBD[i].
                CBSQL = new SqlCommandBuilder(DASQL);
            }
            DTT = new System.Data.DataTable();//Crea un Objeto DataTable.
            if (Access)
            {
                DA.Fill(DTT);//Agrega los datos de la Base de datos al DataTable.
            }
            else
            {
                DASQL.Fill(DTT);
            }
            return (DTT);
        }
        public void CloseBD()
        {
            if (Access)
            {
                if (OleConex.State == ConnectionState.Open)
                {
                    OleConex.Close();
                }
            }
            else
            {
                if (SQLConex.State == ConnectionState.Open)
                {
                    SQLConex.Close();
                }
            }
        }        

    }
    public class Globales
    {
        bool cerrar,VIP;
        string Nombre;

        public bool VCerrar
        {
            get { return (cerrar); }
            set { cerrar = value; }
        }
        public bool VVIP
        {
            get { return (VIP); }
            set { VIP = value; }
        }
        public string VNombre
        {
            get { return (Nombre); }
            set { Nombre = value; }
        }
    }
    public class Usuario
    {
        string Nombre;
        StateObject Sc;

        public Usuario()
        {
            Nombre = "";
            Sc = new StateObject();
        }
        public Usuario(string Nom,StateObject S)
        {
            Nombre = Nom;            
            Sc = S;
        }
        public string VNombre
        {
            get { return (Nombre); }
            set { Nombre = value; }
        }
        public StateObject VSc
        {
            get {return(Sc);}
        }
    }
    public class CUsuarios
    {
        Usuario[] Clientes,Aux;
        string[] Nombres,Auxs;
        int tam;
       
        public void Agregar(string Nom,StateObject S)
        {
            if (Clientes == null)
            {
                Clientes = new Usuario[1];
                Clientes[0] = new Usuario(Nom,S);         
                Nombres = new string[1];
                Nombres[0] = Nom;       
                return;
            }
            Aux = new Usuario[Clientes.Length];
            Auxs = new string[Nombres.Length];
            Clientes.CopyTo(Aux,0);
            Nombres.CopyTo(Auxs,0);
            Nombres = new string[Auxs.Length + 1];
            Clientes = new Usuario[Aux.Length + 1];
            Auxs.CopyTo(Nombres,0); 
            Aux.CopyTo(Clientes, 0);
            Clientes[Clientes.Length - 1] = new Usuario(Nom,S);    
            Nombres[Nombres.Length - 1] = Nom;
            tam = Clientes.Length;
        }
        public void Eliminar(Usuario Us)
        {
            int ind,h,j;

            for (h = 1; h < Length; h++)
            {
                if (Us.VNombre == Clientes[h].VNombre)
                {
                    break; 
                }
            }
            ind = h;

            Aux = new Usuario[Clientes.Length];
            Auxs = new string[Nombres.Length]; 
            Clientes.CopyTo(Aux, 0);
            Nombres.CopyTo(Auxs, 0);
            Clientes = null;
            Nombres = null;
            Nombres = new string[Auxs.Length - 1];
            Clientes = new Usuario[Aux.Length - 1];

            for (h = 0; h < ind; h++)
            {
                Nombres[h] = Auxs[h];
                Clientes[h] = new Usuario(Aux[h].VNombre, Aux[h].VSc);
            }

            for (j = ind, h = ind + 1; h < Auxs.Length; h++)
            {
                Nombres[j] = Auxs[h];
                Clientes[j] = new Usuario(Aux[h].VNombre, Aux[h].VSc);
                j++;
            }
            Aux = null;
            Auxs = null;
            tam = Clientes.Length;
        }

        public string[] VNombres
        {
            get { return (Nombres); }
        }
        public string VPNombres
        {            
            get 
            {
                string retorno = string.Empty;
                for (int j = 0; j < Nombres.Length; j++)
                {
                    retorno += "$" + Nombres[j] ;
                }
                return (retorno);
            }
        }
        public int Length
        {
            get { return (tam); }
        }
        public Usuario ItemArray(int i)
        {
            try
            {
                return (Clientes[i]);
            }
            catch (Exception ex)
            {
                return (null);
            }
        }
        public bool Exist(string Nom)
        {
            for(int j = 0; j < Nombres.Length ; j++)
            {
                if(Nombres[j].Trim().ToUpper() == Nom.Trim().ToUpper())
                {
                    return(true);
                }
            }
            return(false);
        }
        public Usuario ExistN(string Nom)
        {
            for (int j = 0; j < Nombres.Length; j++)
            {
                if (string.Equals(Nombres[j].Trim().ToUpper(), Nom.Trim().ToUpper()))
                {
                    return (Clientes[j]);
                }
            }
            return (null);
        }
    }
    public class StateObject
    {
        public Socket workSocket = null;
        public const int BufferSize = 1024;
        public byte[] buffer = new byte[BufferSize];
        public StringBuilder sb = new StringBuilder();
    }    
}
