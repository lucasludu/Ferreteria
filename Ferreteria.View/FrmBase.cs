using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferreteria.View
{
    public partial class FrmBase : Form
    {
        public FrmBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Muestra un MessageBox con el mensaje pasado, un botón OK y el icono Information.
        /// </summary>
        /// <param name="message">Mensaje a mostrar en MessageBox.</param>
        protected void ShowPopupMessageInfo(string message)
        {
            MessageBox.Show(message, "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Muestra un MessageBox con el mensaje pasado, un botón OK y el icono Error.
        /// </summary>
        /// <param name="message">Mensaje a mostrar en MessageBox.</param>
        protected void ShowPopupMessageError(string message)
        {
            MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }





    }
}
