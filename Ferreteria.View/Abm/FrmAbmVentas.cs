using Ferreteria.Business;
using Ferreteria.Models;
using Ferreteria.View.Consulta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferreteria.View.Abm
{
    public partial class FrmAbmVentas : FrmBase
    {

        #region FRM | Constructor

        public Venta _Venta { get; set; }
        public Venta _Venta_Copy { get; set; }
        private string _importe { get; set; }

        public FrmAbmVentas(Venta venta)
        {
            InitializeComponent();

            try
            {
                bsLocales.DataSource = new LocalNegocio().GetAll();

                if (venta == null)
                {
                    bsVenta.DataSource = new Venta();

                    var listaCategorias = new CategoriaNegocio().GetAll();
                    listaCategorias.Add(new Categoria(0, "<< Ingrese categoria >>"));
                    bsCategoria.DataSource = listaCategorias.OrderBy(a => a.Id).ToList();
                    bsCategoria.Position = 0;
                }
                else
                {
                    bsVenta.DataSource = venta;

                    var listaCategorias = new CategoriaNegocio().GetAll();
                    listaCategorias.Add(new Categoria(0, "<< Ingrese categoria >>"));
                    bsCategoria.DataSource = listaCategorias.OrderBy(a => a.Id).ToList();
                    bsCategoria.Position = new CategoriaNegocio().GetByCondition(a => a.Id == venta.Articulo.CategoriaId).Id;
                }

                this.cmbCategorias.SelectedIndexChanged += new System.EventHandler(this.cmbCategorias_SelectedIndexChanged);

            }
            catch (Exception ex)
            {
                this.ShowPopupMessageError(ex.Message);
            }
        }

        private void FrmAbmVentas_Load(object sender, EventArgs e)
        {
            cmbLocal.Focus();
        }

        private void FrmAbmVentas_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            DialogResult = _Venta == null
                ? DialogResult.Cancel
                : DialogResult.OK;
        }

        #endregion

        #region Combos | TXT

        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategorias.SelectedValue != null)
            {
                int categoriaId = (int)cmbCategorias.SelectedValue;
                LoadArticulosByCategoria(categoriaId);
            }
        }

        #endregion

        #region BTN

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultaArticulo_Click(object sender, EventArgs e)
        {
            var frmConsultaArticulo = new FrmConsultaArticulo();
            frmConsultaArticulo.ShowDialog();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var ventaNegocio = new VentaNegocio();
            var ventaCurrent = (Venta)bsVenta.Current;
            ventaCurrent.Importe = decimal.Parse(txtImporte.Text);

            try
            {
                var existeVenta = ventaNegocio.Exists(v => v.Id == ventaCurrent.Id);
                ventaCurrent.Local = new LocalNegocio().GetById((int)ventaCurrent.LocalId);

                lblMessage.Text = !existeVenta
                    ? ventaNegocio.Insert(ventaCurrent)
                        ? "Se agregó la venta"
                        : "No se pudo ingresar la venta"
                    : ventaNegocio.Update(ventaCurrent)
                        ? "Se modificó la venta"
                        : "No se pudo modificar la venta";
            }
            catch (Exception ex)
            {
                this.ShowPopupMessageError(ex.Message);
            }
            finally
            {
                _Venta = ventaCurrent;
                await Task.Delay(2000);
                this.Close();
            }

        }

        #endregion

        #region Métodos Privados

        private void LoadArticulosByCategoria(int categoriaId)
        {
            try
            {
                var listaArticulos = new ArticuloNegocio().GetAllByParams(a => a.CategoriaId == categoriaId);
                bsArticulo.DataSource = listaArticulos.Count > 0
                    ? listaArticulos
                    : new List<Articulo>();
            }
            catch (Exception ex)
            {
                this.ShowPopupMessageError(ex.Message);
            }
        }

        #endregion

        private void txtUnidad_TextChanged(object sender, EventArgs e)
        {
            if(int.TryParse(txtUnidad.Text, out int cantidad))
            {
                if (bsArticulo.Current != null)
                {
                    var articuloCurrent = (Articulo)bsArticulo.Current;
                    var importe = cantidad * articuloCurrent.Precio;
                    _importe = importe.ToString("F2");
                }
            } 
            else
            {
                txtImporte.Text = string.Empty;
            }
        }

        private void txtImporte_TextChanged(object sender, EventArgs e)
        {
            // Creo una variable privada (_importe) para guardar los datos que 
            // se cargan de las unidades de los articulos en venta por el precio
            // asi evito que se setee en 0
            if (_importe != null)
            {
                txtImporte.Text = _importe.ToString(); 
            }
        }

    }
}
