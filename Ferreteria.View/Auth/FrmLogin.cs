using Ferreteria.Business;
using Ferreteria.Models.DTOs;
using Ferreteria.View.Menu;
using System;

namespace Ferreteria.View.Auth
{
    public partial class FrmLogin : FrmBase
    {
        #region CONSTRUCTOR | FORM

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            bsLogin.DataSource = new LoginDto();
        }

        #endregion

        #region BOTONES

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var loginBs = (LoginDto)bsLogin.Current;
            var negocio = new EmpleadoNegocio();
            try
            {
                if (negocio.ExisteEmpleado(a => a.Correo.Equals(loginBs.Correo) && a.Password.Equals(loginBs.Password)))
                {
                    new FrmMenuPpal(negocio.GetByCondition(a => a.Correo.Equals(loginBs.Correo) && a.Password.Equals(loginBs.Password))).ShowDialog();
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
            new FrmRegistroUsuario(null).ShowDialog();
        }

        #endregion

    }
}
