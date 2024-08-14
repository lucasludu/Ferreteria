using Ferreteria.Business;
using Ferreteria.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferreteria.View.Abm
{
    public partial class FrmAbmLocal : FrmBase
    {
        public Local _local { get; set; }
        public Local Local_past { get; set; }

        public FrmAbmLocal(Local local)
        {
            InitializeComponent();

            var localSelect = local != null
                ? local
                : new Local();

            bsLocal.DataSource = localSelect;
            Local_past = localSelect.Clone();
        }

        private void FrmAbmLocal_Load(object sender, EventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var negocio = new LocalNegocio();
            var localBs = (Local)bsLocal.Current;
            try
            {
                _local = negocio.GetById(Local_past.Id);

                if (_local != null)
                {
                    _local = new Local(_local.Id, localBs.Nombre, localBs.Direccion, localBs.Telefono);
                    lblMessage.Text = negocio.Update(_local)
                        ? $"El local {_local.Nombre} ha sido modificado."
                        : "No se pudo realizar la modificación.";
                }
                else
                {
                    lblMessage.Text = negocio.Insert(localBs)
                        ? $"Se agregó el local {localBs.Nombre}"
                        : "No se pudo agregar correctamente.";
                    _local = localBs;
                }
            }
            catch (Exception ex)
            {
                this.ShowPopupMessageError(ex.Message);
            }
            finally
            {
                Cursor = Cursors.WaitCursor;
                await Task.Delay(2000);
                this.Close();
            }
        }
  
    }
}
