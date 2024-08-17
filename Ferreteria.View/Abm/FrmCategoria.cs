using Ferreteria.Business;
using Ferreteria.Models;
using Ferreteria.View.Utiles;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferreteria.View.Abm
{
    public partial class FrmCategoria : FrmBase
    {
        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            InicializarCategoria();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            InicializarCategoria();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            gbxData.Enabled = true;
            txtNombre.Focus();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                var lista = new CategoriaNegocio().GetAll();
                bsCategorias.DataSource = new ExtendedBindingList<Categoria>(lista);
                lblCantidadRegistros.Text = lista.Count.ToString();
            }
            catch (Exception ex)
            {
                this.ShowPopupMessageError(ex.Message);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelUtil.ExportDataGridViewToXlsx(dgvCategorias, sfd.FileName);
                        this.ShowPopupMessageInfo("Exportación Excitosa.");
                    }
                    catch (Exception ex)
                    {
                        this.ShowPopupMessageError(ex.Message);
                    }
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var negocio = new CategoriaNegocio();
            var categoria = (Categoria)bsCategoria.DataSource;
            try
            {
                var existeCategoria = negocio.GetByCondition(a => a.Nombre.ToLower().Trim().Equals(categoria.Nombre.ToLower().Trim()));
                
                if(existeCategoria == null)
                {
                    lblMessage.Text = negocio.Insert(categoria)
                        ? "Se agrego correctamente."
                        : "No se pudo agregar la categoria.";

                    bsCategorias.Add(categoria);
                    bsCategorias.ResetBindings(false);
                }
                else
                {
                    this.ShowPopupMessageError("La categoria a agregar ya se encuentra registrada.");
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
                lblMessage.Text = string.Empty;
                Cursor = Cursors.Default;
            }
        }



        private void InicializarCategoria()
        {
            gbxData.Enabled = false;
            bsCategorias.DataSource = new ExtendedBindingList<Categoria>();
            bsCategoria.DataSource = new Categoria();
            lblCantidadRegistros.Text = string.Empty;
        }
    }
}
