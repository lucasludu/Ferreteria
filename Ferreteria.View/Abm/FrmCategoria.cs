using Ferreteria.Business;
using Ferreteria.Models;
using Ferreteria.View.Utiles;
using System;
using System.Collections.Generic;
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
            gbxFilter.Enabled = false;
            btnExcel.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            InicializarCategoria();
            gbxFilter.Enabled = false;
            btnExcel.Enabled = false;
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
                gbxFilter.Enabled = true;
                btnExcel.Enabled = true;
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
                if(negocio.ExisteCategoria(a => a.Nombre.ToLower().Trim().Equals(categoria.Nombre.ToLower().Trim())))
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

        private void Filter()
        {
            var lista = new ExtendedBindingList<Categoria>(new CategoriaNegocio().GetAll());
            var filtro = txtFilter.Text.ToLower(); 

            Predicate<Categoria> predicate = c =>
                string.IsNullOrEmpty(filtro) ||
                c.Nombre.ToLower().Contains(filtro); 

            var lista_casteada = new List<Categoria>(lista);
            var listaFiltrada = lista_casteada.FindAll(predicate);

            bsCategorias.DataSource = string.IsNullOrEmpty(filtro)
                ? lista
                : new ExtendedBindingList<Categoria>(listaFiltrada);

            bsCategorias.ResetBindings(false);
        }


        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (bsCategorias.List.Count >= 0)
            {
                gbxFilter.Enabled = true;
                Filter();
                lblCantidadRegistros.Text = bsCategorias.List.Count.ToString(); 
            }
        }

    }
}
