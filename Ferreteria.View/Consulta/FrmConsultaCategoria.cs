using Ferreteria.Business;
using Ferreteria.Models;
using Ferreteria.View.Abm;
using Ferreteria.View.Utiles;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ferreteria.View.Consulta
{
    public partial class FrmConsultaCategoria : FrmBase
    {
        #region Propiedades | Constructor | FrmLoad

        public Categoria _CategoriaCopy { get; set; }

        public FrmConsultaCategoria()
        {
            InitializeComponent();
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            InicializarCategoria();
            gbxFilter.Enabled = false;
            btnExcel.Enabled = false;
        }

        #endregion

        #region Eventos

        #region TXT

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (bsCategorias.List.Count >= 0)
            {
                gbxFilter.Enabled = true;
                Filter();
                lblCantidadRegistros.Text = bsCategorias.List.Count.ToString();
            }
        }

        #endregion

        #region BTN

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
            var frmAbmCategoria = new FrmAbmCategoria(null);
            var result = frmAbmCategoria.ShowDialog();

            if (result == DialogResult.OK && frmAbmCategoria._categoria != null)
            {
                bsCategorias.Add(frmAbmCategoria._categoria);
                bsCategorias.ResetBindings(false);
            }
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
            this.ExportExcel(dgvCategorias);
        }

        #endregion

        #region Grilla

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                if(e.ColumnIndex == dgvColEliminar.Index)
                {
                    var categoriaBS = (Categoria)bsCategorias.Current;

                    if(MessageBox.Show($"¿Esta seguro que desea eliminar la categoria {categoriaBS.Nombre}?",
                        "Eliminar",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var negocio = new CategoriaNegocio();
                        try
                        {
                            var _categoriaSelect = negocio.GetByCondition(c => c.Nombre == categoriaBS.Nombre);

                            if(negocio.Delete(_categoriaSelect))
                            {
                                this.ShowPopupMessageInfo($"Se ha eliminado la categoria {_categoriaSelect.Nombre}");
                                bsCategorias.Remove(categoriaBS);
                                lblCantidadRegistros.Text = bsCategorias.List.Count.ToString();
                                bsCategorias.ResetBindings(false);
                            }
                            else
                            {
                                this.ShowPopupMessageError($"No se ha podido eliminar la categoria {_categoriaSelect.Nombre}");
                            }
                        }
                        catch (Exception ex)
                        {
                            this.ShowPopupMessageError(ex.Message);
                        }
                    }
                }
            }
        }
        
        private void dgvCategorias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var categoriaSeleccionada = (Categoria)bsCategorias.Current;

                var frmAbmCategoria = new FrmAbmCategoria(categoriaSeleccionada);
                var result = frmAbmCategoria.ShowDialog();

                if (result == DialogResult.OK && frmAbmCategoria._categoria != null)
                {
                    bsCategorias[e.RowIndex] = new CategoriaNegocio().GetByCondition(a => a.Id == frmAbmCategoria._categoria.Id);
                    bsCategorias.ResetBindings(false);
                }
            }
        }

        #endregion

        #endregion

        #region Métodos Privados

        private void InicializarCategoria()
        {
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

        #endregion

    }
}
