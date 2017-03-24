using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        ///        
        [STAThread]        
        static void Main()
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (IsExecutingApplication() == false)
            {
                Application.Run(new PPal());
            }
            else
            {
            }
        }
        private static bool IsExecutingApplication()
        {
            // Proceso actual
            System.Diagnostics.Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();

            // Matriz de procesos
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();

            // Recorremos los procesos en ejecución
            foreach (System.Diagnostics.Process p in processes)
            {
                if (p.Id != currentProcess.Id)
                {
                    if (p.ProcessName == currentProcess.ProcessName)
                    {
                        return true;
                    }
                }
            }
            return false;
        } 
    }
     

}
