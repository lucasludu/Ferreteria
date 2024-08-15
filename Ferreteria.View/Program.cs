using Ferreteria.View.Abm;
using Ferreteria.View.Auth;
using Ferreteria.View.Menu;
using System;
using System.Windows.Forms;

namespace Ferreteria.View
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());
        }
    }
}
