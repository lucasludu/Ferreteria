using Ferreteria.Business;
using Ferreteria.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferreteria.View.Abm
{
    public partial class FrmAbmProveedor : FrmBase
    {

        public Proveedor _proveedor { get;set; }
        public Proveedor _proveedorCopy { get;set; }

        public FrmAbmProveedor(Proveedor proveedor)
        {
            InitializeComponent();

            _proveedor = (proveedor == null)
                ? new Proveedor()
                : proveedor;

            bsProveedor.DataSource = _proveedor;

            if (proveedor != null) 
            { 
                _proveedorCopy = proveedor.Clone();
            } 
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, System.EventArgs e)
        {
            var negocio = new ProveedorNegocio();

            try
            {
                var existeProveedor = negocio.ExisteProveedor(a => 
                    a.Id == ((Proveedor)bsProveedor.DataSource).Id
                );


                lblMessage.Text = (!existeProveedor)
                    ? negocio.Insert((Proveedor)bsProveedor.Current)
                        ? "Se agrego correctamente."
                        : "No se pudo agregar el proveedor."
                    : negocio.Update((Proveedor)bsProveedor.Current)
                       ? "Se modificó correctamente."
                       : "No se pudo modificar el proveedor.";
            }
            catch (Exception ex)
            {
                this.ShowPopupMessageError(ex.Message);
            }
            finally
            {
                _proveedor = (Proveedor)bsProveedor.Current;
                Cursor = Cursors.WaitCursor;
                await Task.Delay(2000);
                lblMessage.Text = string.Empty;
                Cursor = Cursors.Default;
                this.Close();
            }
        }

        private void FrmAbmProveedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = _proveedor == null
                ? DialogResult.Cancel
                : DialogResult.OK;
        }

    }
}
