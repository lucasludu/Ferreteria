using Ferreteria.Business;
using Ferreteria.Models;
using Ferreteria.View.Abm;
using Ferreteria.View.Utiles;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ferreteria.View.Consulta
{
    public partial class FrmConsultaProveedor : FrmBase
    {

        #region CONSTRUCTOR

        public FrmConsultaProveedor()
        {
            InitializeComponent();
        }

        private void FrmConsultaProveedor_Load(object sender, EventArgs e)
        {
            this.InicializarProveedores();
        }

        #endregion

        #region EVENTOS

        #region REGION

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (bsProveedores.List.Count >= 0)
            {
                gbxFilter.Enabled = true;
                this.Filter();
                lblCantidadRegistros.Text = bsProveedores.List.Count.ToString();
            }
        }

        #endregion

        #region BOTONES

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            this.InicializarProveedores();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                var listaProveedores = new ProveedorNegocio().GetAll();
                if (listaProveedores.Count > 0)
                {
                    bsProveedores.DataSource = new ExtendedBindingList<Proveedor>(listaProveedores);
                    lblCantidadRegistros.Text = listaProveedores.Count.ToString();
                    btnExcel.Enabled = true;
                    gbxFilter.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                this.ShowPopupMessageError(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frmAbmProveedores = new FrmAbmProveedor(null);
            var result = frmAbmProveedores.ShowDialog();

            if (result == DialogResult.OK && frmAbmProveedores._proveedor != null)
            {
                bsProveedores.Add(frmAbmProveedores._proveedor);
                bsProveedores.ResetBindings(false);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            this.ExportExcel(dgvProveedores);
        }

        #endregion

        #region GRILLA

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvColEliminar.Index)
                {
                    var proveedorBs = (Proveedor)bsProveedores.Current;

                    if (MessageBox.Show($"¿Esta seguro que desea eliminar al proveedor {proveedorBs.Nombre}?",
                       "Eliminar",
                       MessageBoxButtons.YesNoCancel,
                       MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var negocio = new ProveedorNegocio();
                        try
                        {
                            var proveedorSelect = negocio.GetByCondition(c => c.Nombre == proveedorBs.Nombre);

                            if (negocio.Delete(proveedorSelect))
                            {
                                this.ShowPopupMessageInfo($"Se ha eliminado al proveedor {proveedorSelect.Nombre}");
                                bsProveedores.Remove(proveedorBs);
                                lblCantidadRegistros.Text = bsProveedores.List.Count.ToString();
                                bsProveedores.ResetBindings(false);
                            }
                            else
                            {
                                this.ShowPopupMessageError($"No se ha podido eliminar al proveedor {proveedorSelect.Nombre}");
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

        private void dgvProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var proveedorSeleccionado = (Proveedor)bsProveedores.Current;

                var frmAbmProveedor = new FrmAbmProveedor(proveedorSeleccionado);
                var result = frmAbmProveedor.ShowDialog();

                if (result == DialogResult.OK && frmAbmProveedor._proveedor != null)
                {
                    bsProveedores[e.RowIndex] = new ProveedorNegocio().GetByCondition(a => a.Id == frmAbmProveedor._proveedor.Id);
                    bsProveedores.ResetBindings(false);
                }
            }
        }

        #endregion

        #endregion

        #region MÉTODOS PRIVADOS

        private void InicializarProveedores()
        {
            bsProveedores.DataSource = new ExtendedBindingList<Proveedor>();
            bsProveedor.DataSource = new Proveedor();
            txtFilter.Text = string.Empty;
            btnExcel.Enabled = false;
            gbxFilter.Enabled = false;
        }

        private void Filter()
        {
            var lista = new ExtendedBindingList<Proveedor>(new ProveedorNegocio().GetAll());
            var filtro = txtFilter.Text.ToLower();

            Predicate<Proveedor> predicate = c =>
                string.IsNullOrEmpty(filtro) ||
                c.Nombre.ToLower().Contains(filtro) ||
                c.Telefono.Contains(filtro) ||
                c.Correo.Contains(filtro);

            var lista_casteada = new List<Proveedor>(lista);
            var listaFiltrada = lista_casteada.FindAll(predicate);

            bsProveedores.DataSource = string.IsNullOrEmpty(filtro)
                ? lista
                : new ExtendedBindingList<Proveedor>(listaFiltrada);

            bsProveedores.ResetBindings(false);
        }

        #endregion
  
    }
}
