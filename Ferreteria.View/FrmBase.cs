using Ferreteria.View.Utiles;
using System;
using System.Drawing;
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
        /// Actualizo el label
        /// </summary>
        /// <param name="label">Label</param>
        /// <param name="message">Message</param>
        /// <param name="color">Color</param>
        public void ActualizarLabel(Label label, string message, Color color)
        {
            if (label != null)
            {
                label.Text = message;
                label.ForeColor = color;
            }
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

        /// <summary>
        /// Mensaje de aviso Yes/No
        /// </summary>
        /// <param name="message">Mensaje</param>
        /// <param name="title">Titulo</param>
        /// <returns></returns>
        protected bool ConfirmarAccion(string message, string title)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        /// <summary>
        /// Exporta la grilla a Excel
        /// </summary>
        /// <param name="dgv">Data Grid View</param>
        protected void ExportExcel(DataGridView dgv)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelUtil.ExportDataGridViewToXlsx(dgv, sfd.FileName);
                        this.ShowPopupMessageInfo("Exportación Excitosa.");
                    }
                    catch (Exception ex)
                    {
                        this.ShowPopupMessageError(ex.Message);
                    }
                }
            }
        }
    }
}
