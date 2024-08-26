using Ferreteria.Business;
using Ferreteria.Models;
using Ferreteria.Models.DTOs;
using Ferreteria.Models.Mapper;
using Ferreteria.View.Abm;
using Ferreteria.View.Utiles;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ferreteria.View.Consulta
{
    public partial class FrmConsultaLocal : FrmBase
    {
        
        #region Constructor

        public FrmConsultaLocal()
        {
            InitializeComponent();
        }

        private void FrmConsultaLocal_Load(object sender, EventArgs e)
        {
            bsLocales.DataSource = new ExtendedBindingList<LocalDto>();
            lblCantRegistros.Text = bsLocales.List.Count.ToString();

            gbxFilter.Enabled = false;
            btnExcel.Enabled = false;
        }

        #endregion

        #region Eventos
        
        #region TXT

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (bsLocales.List.Count >= 0)
            {
                gbxFilter.Enabled = true;
                Filter();
                lblCantRegistros.Text = bsLocales.List.Count.ToString();
            }
        }

        #endregion

        #region Botones

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frmAbmLocal = new FrmAbmLocal(null);
            var result = frmAbmLocal.ShowDialog();

            if (result == DialogResult.Cancel && frmAbmLocal._local != null)
            {
                bsLocales.Add(AutoMapperProfile.LocalToLocalDto(frmAbmLocal._local));
                lblCantRegistros.Text = bsLocales.List.Count.ToString();
                bsLocales.ResetBindings(false);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                bsLocales.DataSource = this.GetList();
                lblCantRegistros.Text = bsLocales.List.Count.ToString();

                gbxFilter.Enabled = true;
                btnExcel.Enabled = true;
            }
            catch (Exception ex)
            {
                this.ShowPopupMessageError(ex.Message);
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            bsLocales.DataSource = new List<LocalDto>();
            lblCantRegistros.Text = bsLocales.List.Count.ToString();

            btnExcel.Enabled = false;
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
                        ExcelUtil.ExportDataGridViewToXlsx(dgvLocales, sfd.FileName);
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

        #region Grilla

        private void dgvLocales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var localSelectedDto = (LocalDto)bsLocales.Current;
                var _localSelected = new LocalNegocio().GetByParams(l => l.Nombre == localSelectedDto.Nombre);
                
                if (localSelectedDto != null)
                {
                    var frmAbmLocal = new FrmAbmLocal(_localSelected);
                    var result = frmAbmLocal.ShowDialog();

                    if (result == DialogResult.Cancel && frmAbmLocal._local != null)
                    {
                        bsLocales[e.RowIndex] = AutoMapperProfile.LocalToLocalDto(frmAbmLocal._local);
                        bsLocales.ResetBindings(false);
                    }
                }
            }
        }

        private void dgvLocales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvColEliminar.Index)
                {
                    var localBs = (LocalDto)bsLocales.Current;
                    if (MessageBox.Show($"¿Está seguro que desea eliminar al local {localBs.Nombre}?",
                                        "Eliminar",
                                        MessageBoxButtons.YesNoCancel,
                                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            var _localSelected = new LocalNegocio().GetByParams(l => l.Nombre == localBs.Nombre);
                            if (new LocalNegocio().Delete(_localSelected))
                            {
                                this.ShowPopupMessageInfo($"Se ha eliminado el local {_localSelected.Nombre}");
                                bsLocales.Remove(localBs);
                                lblCantRegistros.Text = bsLocales.List.Count.ToString();
                                bsLocales.ResetBindings(false);
                            }
                            else
                            {
                                this.ShowPopupMessageError($"No se ha podido eliminar el local {_localSelected.Nombre}");
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

        #region MÉTODOS PRIVADOS

        private void Filter()
        {
            var lista = this.GetList();
            var filtro = txtFilter.Text.ToLower();

            Predicate<LocalDto> predicate = l =>
                string.IsNullOrEmpty(filtro) ||
                l.Nombre.ToLower().Contains(filtro) ||
                l.Direccion.ToLower().Contains(filtro) ||
                l.Telefono.ToLower().Contains(filtro);

            var listaFiltrada = (new List<LocalDto>(lista)).FindAll(predicate);

            bsLocales.DataSource = string.IsNullOrEmpty(filtro)
                ? lista
                : new ExtendedBindingList<LocalDto>(listaFiltrada);

            bsLocales.ResetBindings(false);
        }

        private ExtendedBindingList<LocalDto> GetList()
        {
            var listaLocales = new LocalNegocio().GetAll();
            var dtoList = AutoMapperProfile.ListLocalToListLocalDto(listaLocales);
            return new ExtendedBindingList<LocalDto>(dtoList);
        }

        #endregion

    }
}
