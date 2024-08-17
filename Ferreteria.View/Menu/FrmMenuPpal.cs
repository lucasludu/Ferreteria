using Ferreteria.Business;
using Ferreteria.Models;
using Ferreteria.Models.Mapper;
using Ferreteria.View.Abm;
using Ferreteria.View.Auth;
using Ferreteria.View.Consulta;
using System;
using System.Linq;
using System.Windows.Forms;

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

                if(emp.Puesto.Equals("Administrador"))
                {
                    btnFrmLocal.Enabled = true;
                    btnFrmCategoria.Enabled = true;
                    btnFrmArticulo.Enabled = true;
                    btnFrmVenta.Enabled = true;
                }
                else
                {
                    btnFrmLocal.Enabled = false;
                    btnFrmCategoria.Enabled = false;
                }
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
            var register = AutoMapperProfile.EmpleadoToRegisterDto(_Empleado);
            var frmRegistro = new FrmRegistroUsuario(register);
            var result = frmRegistro.ShowDialog();

            if(result == DialogResult.Cancel)
            {
                var dto = new EmpleadoNegocio().GetDto(frmRegistro.registerDto.Correo);
                bsEmpleado.DataSource = dto;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var frmLogin = Application.OpenForms.OfType<FrmLogin>().FirstOrDefault();

            if(frmLogin != null)
            {
                frmLogin.Close();
            }

            Application.Exit();
        }

        private void btnFrmCategoria_Click(object sender, EventArgs e)
        {
            var frmCategoria = new FrmCategoria();
            frmCategoria.ShowDialog();
        }
    }
}
