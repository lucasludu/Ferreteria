using Ferreteria.Business;
using Ferreteria.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferreteria.View.Abm
{
    public partial class FrmAbmCategoria : FrmBase
    {
        #region Propiedades | Constructor | Frm

        public Categoria _categoria { get; set; }
        public Categoria _categoriaCopy { get; set; }

        public FrmAbmCategoria(Categoria categoria)
        {
            InitializeComponent();

            bsCategoria.DataSource = (categoria == null)
                ? new Categoria()
                : categoria;

            if(categoria != null)   _categoriaCopy = categoria.Clone();
        }

        private void FrmAbmCategoria_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = _categoria == null
                ? DialogResult.Cancel
                : DialogResult.OK;
        }

        #endregion

        #region BTN

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var negocio = new CategoriaNegocio();
            var categoria = (Categoria)bsCategoria.Current;
            try
            {
                var existeCategoria = negocio.ExisteCategoria(a => 
                    a.Nombre.ToLower().Trim().Equals(_categoriaCopy.Nombre.ToLower().Trim()));

                lblMessage.Text = (!existeCategoria)
                    ? negocio.Insert(categoria)
                        ? "Se agrego correctamente."
                        : "No se pudo agregar la categoria."
                    : negocio.Update(categoria)
                       ? "Se modificó correctamente."
                       : "No se pudo modificar la categoria.";
            }
            catch (Exception ex)
            {
                this.ShowPopupMessageError(ex.Message);
            }
            finally
            {
                _categoria = categoria;
                Cursor = Cursors.WaitCursor;
                await Task.Delay(2000);
                lblMessage.Text = string.Empty;
                Cursor = Cursors.Default;
                this.Close();
            }
        }

        #endregion
    }
}
