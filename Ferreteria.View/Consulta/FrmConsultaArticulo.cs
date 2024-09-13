using ExcelDataReader;
using Ferreteria.Business;
using Ferreteria.Models.DTOs;
using Ferreteria.View.Abm;
using Ferreteria.View.Popup;
using Ferreteria.View.Utiles;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Ferreteria.View.Consulta
{
    public partial class FrmConsultaArticulo : FrmBase
    {

        #region Constructor | Frm

        public FrmConsultaArticulo()
        {
            InitializeComponent();
        }

        private void FrmConsultaArticulo_Load(object sender, EventArgs e)
        {
            this.InicializaScreen();

        }

        #endregion

        #region Eventos

        #region TXT

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if(bsArticulos.List.Count >= 0)
            {
                gbxFilter.Enabled = true;
                this.Filter();
                lblCantidadRegistros.Text = bsArticulos.List.Count.ToString();
            }
        }

        #endregion

        #region BOTONES

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            this.InicializaScreen();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frmAddArticulo = new FrmAbmArticulo(null);
            var result = frmAddArticulo.ShowDialog();

            if (result == DialogResult.OK && frmAddArticulo._Articulo != null)
            {
                var dto = new ArticuloNegocio().GetByConditionDto(a => a.Id == frmAddArticulo._Articulo.Id);
                bsArticulos.Add(dto);
                bsArticulos.ResetBindings(false);
                lblCantidadRegistros.Text = bsArticulos.List.Count.ToString();
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            bsArticulos.DataSource = this.GetList();
            lblCantidadRegistros.Text = bsArticulos.List.Count.ToString();
            btnExcel.Enabled = true;
            gbxFilter.Enabled = true;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            //using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV file|*.csv" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelUtil.ExportDataGridViewToXlsx(dgvArticulos, sfd.FileName);
                        this.ShowPopupMessageInfo("Exportación Excitosa.");
                    }
                    catch (Exception ex)
                    {
                        this.ShowPopupMessageError(ex.Message);
                    }
                }
            }
        }


        

        #endregion

        #region GRILLA

        private void dgvArticulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var negocio = new ArticuloNegocio();
            if (e.RowIndex >= 0)
            {
                var articuloSelcted = (ArticuloDto)bsArticulos.Current;
                var articulo = negocio.GetByParams(a => a.Nombre.ToLower().Trim().Equals(articuloSelcted.Nombre.ToLower().Trim()));

                if (articuloSelcted != null)
                {
                    var frmAbmArticulo = new FrmAbmArticulo(articulo);
                    var result = frmAbmArticulo.ShowDialog();

                    if (result == DialogResult.OK && frmAbmArticulo._Articulo != null)
                    {
                        bsArticulos[e.RowIndex] = negocio.GetByConditionDto(a => a.Id == frmAbmArticulo._Articulo.Id);
                        bsArticulos.ResetBindings(false);
                    }
                }
            }
        }


        private void dgvArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var negocio = new ArticuloNegocio();
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvColEliminar.Index)
                {
                    var articuloDto = (ArticuloDto)bsArticulos.Current;
                    if (MessageBox.Show(
                            $"¿Está seguro de eliminar el articulo {articuloDto.Nombre}?",
                            "Eliminar",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        ) == DialogResult.Yes)
                    {
                        try
                        {
                            var articulo = negocio
                                .GetByParams(a => a.Nombre.ToLower().Trim().Equals(articuloDto.Nombre.ToLower().Trim()));

                            if (negocio.Delete(articulo))
                            {
                                this.ShowPopupMessageInfo($"El articulo {articulo.Nombre} fue eliminado");
                                bsArticulos.Remove(articuloDto);
                                bsArticulos.ResetBindings(false);
                                lblCantidadRegistros.Text = bsArticulos.List.Count.ToString();
                            }
                            else
                            {
                                this.ShowPopupMessageError("No se pudo eliminar el articulo.");
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

        #endregion

        #endregion

        #region Métodos Privados

        private ExtendedBindingList<ArticuloDto> GetList()
        {
            var lista = new ArticuloNegocio().GetAllDto();
            return new ExtendedBindingList<ArticuloDto>(lista);
        }

        private void InicializaScreen()
        {
            bsArticulos.DataSource = new ExtendedBindingList<ArticuloDto>();
            bsArticulo.DataSource = new ArticuloDto();

            lblCantidadRegistros.Text = string.Empty;

            gbxFilter.Enabled = false;
            btnExcel.Enabled = false;
        }

        private void Filter()
        {
            var lista = this.GetList();
            var filtro = txtFilter.Text.ToLower();

            Predicate<ArticuloDto> predicate = a =>
                string.IsNullOrEmpty(filtro) ||
                a.Nombre.ToLower().Contains(filtro) ||
                a.Descripcion.ToLower().Contains(filtro) ||
                a.Categoria.ToLower().Contains(filtro);

            var listaFiltrada = (new List<ArticuloDto>(lista)).FindAll(predicate);

            bsArticulos.DataSource = string.IsNullOrEmpty(filtro)
                ? lista
                : new ExtendedBindingList<ArticuloDto>(listaFiltrada);

            bsArticulos.ResetBindings(false);
        }

        #endregion

        private void btnImport_Click(object sender, EventArgs e)
        {
            var frmImportArticulo = new FrmImportArticulo();
            var result = frmImportArticulo.ShowDialog();

            if(result == DialogResult.OK && frmImportArticulo._listaArticulo.Count > 0)
            {
                bsArticulos.DataSource = frmImportArticulo._listaArticulo;
            }
        }
    }
}
