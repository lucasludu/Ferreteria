using Ferreteria.Business;
using Ferreteria.Models;
using Ferreteria.Models.DTOs;
using Ferreteria.Models.Mapper;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferreteria.View.Auth
{
    public partial class FrmRegistroUsuario : FrmBase
    {
        public FrmRegistroUsuario()
        {
            InitializeComponent();
        }

        private void FrmRegistroUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                bsRegistroUsuario.DataSource = new RegisterDto();

                var listaLocales = new LocalNegocio().GetAll();
                listaLocales.Add(new Local(0, "<< Seleccione un local >>"));
                bsLocal.DataSource = listaLocales.OrderBy(l => l.Id).ToList();
                
                var listaRoles = new PuestoNegocio().GetAll();
                listaRoles.Add(new Puesto(0, "<< Seleccione un rol >>"));
                bsRol.DataSource = listaRoles.OrderBy(r => r.Id).ToList();
            }
            catch (Exception ex)
            {
                this.ShowPopupMessageError(ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var registroBs = (RegisterDto)bsRegistroUsuario.Current;
            var negocio = new EmpleadoNegocio();
            try
            {
                var existeRegistro = negocio.GetByCondition(a => a.Correo.Equals(registroBs.Correo));
                if(existeRegistro == null)
                {
                    if (registroBs.Password.Equals(txtConfirmPassword.Text))
                    {
                        lblMessage.Text = negocio.Insert(AutoMapperProfile.RegisterDtoToEmpledo(registroBs))
                            ? "Registro exitoso"
                            : "No se pudo ingresar el registro";
                    } 
                    else
                    {
                        this.ShowPopupMessageError("Los Password no coinciden.");
                    }
                }
                else
                {
                    this.ShowPopupMessageError("El usuario ya se encuentra registrado.");
                }
            }
            catch (Exception ex)
            {
                this.ShowPopupMessageError(ex.Message);
            }
            finally
            {
                Cursor = Cursors.WaitCursor;
                await Task.Delay(2000);
                this.Close();
            }
        }
    }
}
