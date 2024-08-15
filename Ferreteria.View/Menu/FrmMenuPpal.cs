using Ferreteria.Business;
using Ferreteria.Models;
using Ferreteria.View.Auth;
using Ferreteria.View.Consulta;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ferreteria.View.Menu
{
    public partial class FrmMenuPpal : FrmBase
    {
        public Empleado _Empleado { get; set; }

        public FrmMenuPpal(Empleado empleado)
        {
            InitializeComponent();

            _Empleado = empleado;

            try
            {
                var emp = new EmpleadoNegocio().GetDto(empleado.Correo);
                bsEmpleado.DataSource = emp;
            }
            catch (Exception ex)
            {
                this.ShowPopupMessageError(ex.Message);
            }
        }

        private void btnFrmLocal_Click(object sender, EventArgs e)
        {
            var frmLocal = new FrmConsultaLocal();
            frmLocal.ShowDialog();
        }

        private void btnModificarRegistro_Click(object sender, EventArgs e)
        {
            var frmRegistro = new FrmRegistroUsuario();
            frmRegistro.ShowDialog();
        }
    }
}
