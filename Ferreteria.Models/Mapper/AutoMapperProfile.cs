using Ferreteria.Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Ferreteria.Models.Mapper
{
    public static class AutoMapperProfile
    {

        #region Local --> LocalDto

        public static LocalDto LocalToLocalDto(Local local)
        {
            return new LocalDto(
                    local.Nombre,
                    local.Direccion,
                    local.Telefono
                );
        }

        public static List<LocalDto> ListLocalToListLocalDto(List<Local> list)
        {
            return list.Select(a => LocalToLocalDto(a)).ToList();
        }

        #endregion

        #region LocalDto --> Local

        public static Local LocalDtoToLocal(LocalDto localDto)
        {
            return new Local(
                    localDto.Nombre,
                    localDto.Direccion,
                    localDto.Telefono
                );
        }

        public static List<Local> ListLocalDtoToListLocal(List<LocalDto> listDto)
        {
            return listDto.Select(a => LocalDtoToLocal(a)).ToList();
        }

        #endregion


        #region Empleado --> RegisterDto

        public static RegisterDto EmpleadoToRegisterDto(Empleado empleado)
        {
            return new RegisterDto(
                    empleado.Nombre,
                    empleado.Correo,
                    empleado.Password,
                    (int)empleado.PuestoId,
                    (int)empleado.LocalId
                );
        }

        #endregion

        #region RegisterDto --> Empleado

        public static Empleado RegisterDtoToEmpledo(RegisterDto registerDto) 
        {
            return new Empleado(
                    registerDto.Nombre,
                    registerDto.Correo,
                    registerDto.Password,
                    registerDto.PuestoId,
                    registerDto.LocalId
                );
        }

        #endregion


        #region Empleado --> LoginDto

        public static LoginDto EmpleadoToLoginDto(Empleado empleado)
        {
            return new LoginDto(
                    empleado.Correo,
                    empleado.Password
                );
        }

        #endregion

        #region LoginDto --> Empleado

        public static Empleado LoginDtoToEmpleado(LoginDto loginDto)
        {
            return new Empleado(
                    null,
                    loginDto.Correo,
                    loginDto.Password,
                    0,
                    0
                );
        }

        #endregion


    }
}
