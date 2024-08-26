using Ferreteria.Business;
using Ferreteria.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferreteria.View.Abm
{
    public partial class FrmAbmArticulo : FrmBase
    {

        #region CONSTRUCTOR | FRM

        public Articulo _Articulo { get; set; }
        public Articulo _Articulo_Copy { get; set; }

        public FrmAbmArticulo(Articulo articulo)
        {
            InitializeComponent();

            var categoriaNegocio = new CategoriaNegocio();
            if (articulo == null)
            {
                bsArticulo.DataSource = new Articulo();

                var listaCategoria = categoriaNegocio.GetAll();
                listaCategoria.Add(new Categoria(0, "< Ingrese una categoria >"));
                bsCategoria.DataSource = listaCategoria.OrderBy(a => a.Id);
                bsCategoria.Position = 0;
            }
            else
            {
                bsArticulo.DataSource = articulo;

                var listaCategoria = categoriaNegocio.GetAll();
                listaCategoria.Add(new Categoria(0, "< Ingrese una categoria >"));
                bsCategoria.DataSource = listaCategoria.OrderBy(a => a.Id);

                bsCategoria.Position = categoriaNegocio.GetByCondition(a => a.Id == articulo.CategoriaId).Id;
            }


        }

        private void FrmAbmArticulo_Load(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }

        private void FrmAbmArticulo_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            DialogResult = _Articulo == null
                ? System.Windows.Forms.DialogResult.Cancel
                : System.Windows.Forms.DialogResult.OK;
        }

        #endregion

        #region EVENTOS

        #region BOTONES

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var negocio = new ArticuloNegocio();
            var articuloBs = (Articulo)bsArticulo.Current;

            try
            {
                var existeArticulo = negocio.GetByParams(a => a.Id == articuloBs.Id);

                if (existeArticulo != null)
                {
                    lblMessage.Text = negocio.Update(articuloBs)
                        ? "Se modificó con exito"
                        : "No se pudo modificar";
                }
                else
                {
                    lblMessage.Text = negocio.Insert(articuloBs)
                        ? "Se agregó con exito"
                        : "No se pudo agregar";
                }
            }
            catch (Exception ex)
            {
                this.ShowPopupMessageError(ex.Message);
            }
            finally
            {
                _Articulo = articuloBs;
                await Task.Delay(2000);
                this.Close();
            }
        }

        #endregion

        #region TXT

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDescripcion.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPrecio.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtStock.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCategoria.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        #endregion

        #endregion
    
    }
}
