using Ferreteria.Business;
using Ferreteria.Models.DTOs;
using Ferreteria.View.Menu;
using System;

namespace Ferreteria.View.Auth
{
    public partial class FrmLogin : FrmBase
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            bsLogin.DataSource = new LoginDto();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var loginBs = (LoginDto)bsLogin.Current;
            try
            {
                var existeEmpleado = new EmpleadoNegocio()
                    .GetByCondition(a => a.Correo.Equals(loginBs.Correo) && a.Password.Equals(loginBs.Password));

                if(existeEmpleado != null)
                {
                    var frmMenuPpal = new FrmMenuPpal(existeEmpleado);
                    frmMenuPpal.ShowDialog();
                }
                else
                {
                    this.ShowPopupMessageError("Usuario Inexistente");
                }

            }
            catch (Exception ex)
            {
                this.ShowPopupMessageError(ex.Message);
            }
        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            var frmRegistrarUsuario = new FrmRegistroUsuario();
            frmRegistrarUsuario.ShowDialog();
        }
    }
}
