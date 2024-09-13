using Ferreteria.Business;
using Ferreteria.Models;
using Ferreteria.Models.DTOs;
using Ferreteria.View.Utiles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferreteria.View.Popup
{
    public partial class FrmImportArticulo : FrmBase
    {
        public List<Articulo> _listaArticulo { get; set; }

        public FrmImportArticulo()
        {
            InitializeComponent();
        }

        private void FrmImportArticulo_Load(object sender, EventArgs e)
        {
            Inicializar();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            Inicializar();
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            if (ofdArticulos.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofdArticulos.FileName;
                this.LoadDataIntoGrid(filePath);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var listaDto = (ExtendedBindingList<ArticuloDto>)bsImportArticulos.List;
            var lista = new List<Articulo>();
            if (listaDto.Count > 0)
            {
                try
                {
                    
                    foreach (var item in listaDto)
                    {
                        var articulo = new Articulo(item.Nombre, item.Descripcion, item.Precio, item.Stock, new CategoriaNegocio().GetByCondition(c => c.Nombre.Equals(item.Categoria)).Id);

                        lista.Add(articulo);
                    }

                    lblMessage.Text = new ArticuloNegocio().InsertAll(lista)
                        ? "Importado Exitosamente"
                        : "No se pudo Importar la lista de articulos.";
                }
                catch (Exception ex)
                {
                    this.ShowPopupMessageError(ex.Message);
                    throw;
                }
                finally
                {
                    _listaArticulo = lista;
                    await Task.Delay(2000);
                    this.Close();
                }
            }
        }

        private void Inicializar()
        {
            bsImportArticulos.DataSource = new ExtendedBindingList<ArticuloDto>();
            lblCantidadRegistros.Text = bsImportArticulos.List.Count.ToString();
            btnSave.Visible = false;
        }

        private void LoadDataIntoGrid(string filePath)
        {
            DataTable dt = ExcelUtil.ReadExcelFile(filePath);
            
            var lista = new List<ArticuloDto>();
            foreach(DataRow row in dt.Rows)
            {
                var dto = new ArticuloDto
                {
                    Nombre = row["Nombre"].ToString(),
                    Descripcion = row["Descripcion"].ToString(),
                    Precio = Convert.ToDecimal(row["Precio"]),
                    Stock = Convert.ToInt32(row["Stock"]),
                    Categoria = row["Categoria"].ToString()
                };
                lista.Add(dto);
            }

            bsImportArticulos.DataSource = new ExtendedBindingList<ArticuloDto>(lista);
            btnSave.Visible = lista.Count > 0
                ? true
                : false;
        }


        
    }
}
