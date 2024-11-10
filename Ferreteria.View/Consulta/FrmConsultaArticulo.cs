using Ferreteria.Business;
using Ferreteria.Models;
using Ferreteria.Models.DTOs;
using Ferreteria.View.Abm;
using Ferreteria.View.Popup;
using Ferreteria.View.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                var dto = new ArticuloNegocio().GetByParamsDto(a => a.Id == frmAddArticulo._Articulo.Id);
                bsArticulos.Add(dto);
                bsArticulos.ResetBindings(false);
                lblCantidadRegistros.Text = bsArticulos.List.Count.ToString();
            }
        }

        private async void btnShow_Click(object sender, EventArgs e)
        {
            var listaArticulos = this.GetList();
            if (listaArticulos.Count > 0)
            {
                bsArticulos.DataSource = listaArticulos;
                lblCantidadRegistros.Text = bsArticulos.List.Count.ToString();
                btnExcel.Enabled = true;
                gbxFilter.Enabled = true; 
            }
            else
            {
                lblMessage.Text = "No hay articulos ingresados.";
                await Task.Delay(2000);
                lblMessage.Text = string.Empty; 
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            this.ExportExcel(dgvArticulos);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var frmImportArticulo = new FrmImportArticulo();
            var result = frmImportArticulo.ShowDialog();

            if(result == DialogResult.OK && frmImportArticulo._listaArticulo.Count > 0)
            {
                bsArticulos.DataSource = frmImportArticulo._listaArticulo;
            }
        }

        private void btnBuscaCategoria_Click(object sender, EventArgs e)
        {
            var negocio = new ArticuloNegocio();

            try
            {
                var listaArticulos = negocio.GetAllDtoByCategoria(((Categoria)bsCategorias.Current).Id);
                if(listaArticulos.Count > 0)
                {
                    bsArticulos.DataSource = listaArticulos;
                    lblCantidadRegistros.Text = bsArticulos.List.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                this.ShowPopupMessageError(ex.Message);
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
                        bsArticulos[e.RowIndex] = negocio.GetByParamsDto(a => a.Id == frmAbmArticulo._Articulo.Id);
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
                var articuloDto = (ArticuloDto)bsArticulos.Current;
                var nombreArticulo = articuloDto.Nombre.ToLower().Trim();

                #region Col-Eliminar
                if (e.ColumnIndex == dgvColEliminar.Index)
                {
                    if (this.ConfirmarAccion($"¿Está seguro de eliminar el articulo {articuloDto.Nombre}?", "Eliminar"))
                    {
                        try
                        {
                            var articulo = negocio
                                .GetByParams(a => a.Nombre.ToLower().Trim().Equals(nombreArticulo));

                            if (articulo != null && negocio.Delete(articulo))
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
                            this.ShowPopupMessageError($"Error al eliminar el archivo: {ex.Message}");
                        }
                    }
                }
                #endregion

                #region Col-Baja
                if (e.ColumnIndex == dgvActivo.Index)
                {
                    var estadoAnterior = articuloDto.Activo == true ? "Baja" : "Alta";
                    if (this.ConfirmarAccion($"¿Está seguro de dar de {estadoAnterior} el articulo {articuloDto.Nombre}?", "Alta/Baja"))
                    {
                        try
                        {
                            var articulo = negocio
                                .GetByParams(a => a.Nombre.ToLower().Trim().Equals(nombreArticulo));

                            if (articulo != null)
                            {
                                articulo.Activo = !articulo.Activo;

                                if (negocio.Update(articulo))
                                {
                                    var estado = articulo.Activo ? "Alta" : "Baja";
                                    this.ShowPopupMessageInfo($"El articulo {articulo.Nombre} fue dado de {estado}");
                                    bsArticulos.ResetBindings(false);
                                    lblCantidadRegistros.Text = bsArticulos.List.Count.ToString();
                                }
                                else
                                {
                                    this.ShowPopupMessageError("No se pudo eliminar el articulo.");
                                } 
                            }
                            else
                            {
                                ShowPopupMessageError("El artículo no se encontró en la base de datos.");
                            }
                        }
                        catch (Exception ex)
                        {
                            ShowPopupMessageError($"Error al actualizar el estado del artículo: {ex.Message}");
                        }
                    }
                }
                #endregion
            }
        }

        private void dgvArticulos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= bsArticulos.Count)
                return; // Salir si el índice de fila es inválido

            var articuloItem = dgvArticulos.Rows[e.RowIndex].DataBoundItem as Articulo;
            if (articuloItem != null && e.ColumnIndex == dgvActivo.Index)
            {
                if (!articuloItem.Activo)
                {
                    e.Value = null; // Quitar la imagen para artículos inactivos
                    e.CellStyle.NullValue = null; // El valor nulo a mostrar en la celda
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

            var listaCategorias = new CategoriaNegocio().GetAll();
            listaCategorias.Add(new Categoria(0, "TODOS"));
            bsCategorias.DataSource = listaCategorias.OrderBy(a => a.Id);

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
                a.Marca.ToLower().Contains(filtro) ||
                a.Categoria.ToLower().Contains(filtro);

            var listaFiltrada = (new List<ArticuloDto>(lista)).FindAll(predicate);

            bsArticulos.DataSource = string.IsNullOrEmpty(filtro)
                ? lista
                : new ExtendedBindingList<ArticuloDto>(listaFiltrada);

            bsArticulos.ResetBindings(false);
        }

        #endregion


    }
}
