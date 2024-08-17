﻿using Ferreteria.Business;
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
        public RegisterDto registerDto { get; set; }

        public FrmRegistroUsuario(RegisterDto registerDto)
        {
            InitializeComponent();

            this.registerDto = registerDto;

            var negocioLocal = new LocalNegocio();
            var negocioPuesto = new PuestoNegocio();

            try
            {
                if (registerDto != null)
                {
                    bsRegistroUsuario.DataSource = registerDto;

                    var listaLocales = new LocalNegocio().GetAll();
                    listaLocales.Add(new Local(0, "<< Seleccione un local >>"));
                    bsLocal.DataSource = listaLocales.OrderBy(l => l.Id).ToList();

                    var listaRoles = new PuestoNegocio().GetAll();
                    listaRoles.Add(new Puesto(0, "<< Seleccione un rol >>"));
                    bsRol.DataSource = listaRoles.OrderBy(r => r.Id).ToList();
                    
                    bsLocal.Position = negocioLocal.GetById(registerDto.LocalId).Id;
                    bsRol.Position = negocioPuesto.GetById(registerDto.PuestoId).Id;
                }
                else
                {
                    bsRegistroUsuario.DataSource = new RegisterDto();

                    var listaLocales = new LocalNegocio().GetAll();
                    listaLocales.Add(new Local(0, "<< Seleccione un local >>"));
                    bsLocal.DataSource = listaLocales.OrderBy(l => l.Id).ToList();

                    var listaRoles = new PuestoNegocio().GetAll();
                    listaRoles.Add(new Puesto(0, "<< Seleccione un rol >>"));
                    bsRol.DataSource = listaRoles.OrderBy(r => r.Id).ToList();
                }
            }
            catch (Exception ex)
            {
                this.ShowPopupMessageError(ex.Message);
            }
        }

        private void FrmRegistroUsuario_Load(object sender, EventArgs e)
        {

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
                if (registerDto == null)
                {
                    var existeRegistro = negocio.GetByCondition(a => a.Correo.Equals(registroBs.Correo));
                    if (existeRegistro == null)
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
                else
                {
                    var usuario = negocio.GetByCondition(a => a.Correo.Equals(registerDto.Correo));
                    var usuarioUpdate = new Empleado(
                                                        usuario.Id, 
                                                        registerDto.Nombre, 
                                                        registerDto.Correo, 
                                                        registerDto.Password,
                                                        registerDto.PuestoId,
                                                        registerDto.LocalId);
                    lblMessage.Text = negocio.Update(usuarioUpdate)
                        ? "Modificación Exitosa"
                        : "No se pudo modificar el registro del empleado";
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
