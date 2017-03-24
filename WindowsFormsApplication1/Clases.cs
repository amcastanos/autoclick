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

namespace WindowsFormsApplication1
{
    public class XmlElementoSer
    {
        string IP,Port,URL;        

        public void Open(ref bool VIP)
        {   
            try
            {
                XmlDocument Archivo = new XmlDocument();//Crea un Objeto XmlDocument.
                Archivo.Load("Config.XML");//Lee el archivo.                                

                XmlNodeList IPS = Archivo.GetElementsByTagName("IPSERVIDOR");//Hace una lista de elementos contenidos por la etiqueta RutaDB
                IP = ((XmlElement)IPS[0]).GetElementsByTagName("IP").Item(0).InnerText;

                XmlNodeList Pto = Archivo.GetElementsByTagName("PTOSERVIDOR");//Hace una lista de elementos contenidos por la etiqueta URL
                Port = ((XmlElement)Pto[0]).GetElementsByTagName("PTO").Item(0).InnerText;//Hace una lista de elementos contenidos por la etiqueta Tabla en la primera etiqueta RutaDB encontrada.

                XmlNodeList Dat = Archivo.GetElementsByTagName("DATOS");
                URL = ((XmlElement)Dat[0]).GetElementsByTagName("URL").Item(0).InnerText;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("No se pudo cargar el archivo de configuración"); 
                Funciones.Log(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), ex.Message + ex.StackTrace.Substring(ex.StackTrace.Length - 11));
            }
        }

        public string VIP
        {
            get { return (IP); }
        }        
        public int VPort
        {
            get { return (Convert.ToInt16(Port)); }
        }
        public string VURL
        {
            get { return (URL); }
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

            MailMessage correo = new MailMessage();
            correo.From = new MailAddress(EmailFrom, "Traders Jorge & Lender");     
            correo.To.Add(Mailto);
            correo.Subject = Tit;
            correo.Body = Tex;
            correo.IsBodyHtml = false;
            correo.Priority = MailPriority.Normal;
            
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(EmailFrom, Clave);
            client.Port = Port;
            client.Host = Host;
            client.EnableSsl = true;
            try
            {
                client.Send(correo);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                 System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public static void Log(string Ruta,string Tex)
        {
            StreamWriter Wr = null;
            string Archivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Eventos\\Eventos" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + ".txt";
            Ruta = Ruta.Substring(6);

            if(!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Eventos"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Eventos");
            }
           
            try
            {
                Wr = File.AppendText(Archivo);     
                Wr.NewLine = "\r\n";
                Wr.Write(Wr.NewLine);
                Wr.Write(DateTime.Now.ToLongTimeString() + ": " + Tex);
                Wr.Close();
            }
            catch (Exception ex)
            {
                Wr.Close();
            }
        }
        public static int Login(string txt)
        {
            return (0);
        }
        public static string[] Captura(string cadena,ref int valor)
        {
            int ini,fin,aux,cont,ind,ind2;
            string[] retorno;
            string auxs;

            ini = cadena.IndexOf("/*");
            fin = cadena.IndexOf("*/"); 

            if(ini > fin || ini==fin || ini == -1 || fin == -1)
            {
                return(null);
            }

            cadena = cadena.Substring(ini + 2,fin - ini);

            aux = Convert.ToInt16(cadena.Substring(0,1));

            switch (aux)
            {
                case 0:
                    {
                        valor = 0;
                        return (null);                        
                    }
                case 1:
                    {
                        valor = 1;
                        return (null);                       
                    }
                case 2:
                    {
                        cadena = cadena.Substring(2);
                        cont = ind = 0;
                        auxs = cadena;
                        while (auxs.IndexOf("$") > -1 && cont < 101)
                        {
                            cont++;
                            ind = auxs.IndexOf("$");
                            auxs = auxs.Substring(ind + 1);
                        }
                        cont++;

                        retorno = new string[cont];

                        cont = 0;
                        ind = cadena.IndexOf("$");
                        while (ind > -1)
                        {
                            retorno[cont] = cadena.Substring(0, ind);
                            cadena = cadena.Substring(ind + 1);
                            ind = cadena.IndexOf("$");
                            cont++;
                        }

                        retorno[cont] = cadena.Substring(0, cadena.Length - 2);
                        valor = 2;
                        return (retorno);
                    }
                case 3:
                    {
                        valor = 3;
                        return (null);
                    }
                case 4:
                    {
                        valor = 4;
                        return (null);
                    }
            }

            return (null);
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
        public bool cerrar,VIP,Login,reponde;
        public string Nombre,Clave;        

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
            int ind,h;

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
            Nombres = new string[Auxs.Length - 1];
            Clientes = new Usuario[Aux.Length - 1];

            for (h = 0; h < ind; h++)
            {
                Nombres[h] = Auxs[h];
                Clientes[h] = new Usuario(Aux[h].VNombre, Aux[h].VSc);
            }

            for (h = ind + 1; h < Auxs.Length - 1; h++)
            {
                Nombres[h] = Auxs[h];
                Clientes[h] = new Usuario(Aux[h].VNombre, Aux[h].VSc);
            }
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
            return (Clientes[i]); 
        }
        public bool Exist(string Nom)
        {
            for(int j = 0; j < Nombres.Length ; j++)
            {
                if(Nombres[j] == Nom)
                {
                    return(true);
                }
            }
            return(false);
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
