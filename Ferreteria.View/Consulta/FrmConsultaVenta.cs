using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Ferreteria.Business;
using Ferreteria.Models;
using Ferreteria.Models.DTOs;
using Ferreteria.Models.Mapper;
using Ferreteria.View.Abm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Ferreteria.View.Consulta
{
    public partial class FrmConsultaVenta : FrmBase
    {
        public FrmConsultaVenta()
        {
            InitializeComponent();
        }

        private void FrmConsultaVenta_Load(object sender, EventArgs e)
        {
            try
            {
                var listaLocales = new LocalNegocio().GetAll();
                listaLocales.Add(new Local(0, "TODOS"));
                bsLocal.DataSource = listaLocales.OrderBy(a => a.Id);
            }
            catch (Exception ex)
            {
                this.ShowPopupMessageError(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            bsVentas.DataSource = new List<VentaDto>();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                var listaVentas = new VentaNegocio().GetAllDto();

                if(listaVentas.Count > 0)
                {
                    bsVentas.DataSource = listaVentas;
                }
            }
            catch (Exception ex)
            {
                this.ShowPopupMessageError(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frmAbmVenta = new FrmAbmVentas(null);
            var result = frmAbmVenta.ShowDialog();

            if(result == DialogResult.OK)
            {
                var venta = frmAbmVenta._Venta;
                bsVentas.Add(new VentaDto(
                        venta.Local.Nombre,
                        venta.Articulo.Nombre,
                        venta.Importe,
                        venta.Unidad,
                        (DateTime)venta.FechaVta
                    ));
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }
    }
}
