using Ferreteria.Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Ferreteria.Models.Mapper
{
    public static class AutoMapperProfile
    {

        #region LOCAL

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

        #endregion

        #region Empleado

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
                    (int)registerDto.PuestoId,
                    (int)registerDto.LocalId
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

        #endregion

        #region Articulo

        #region ArticuloInsertDto --> Articulo

        public static Articulo ArticuloInsertDtoToArticulo (ArticuloInsertDto dto)
        {
            return new Articulo(
                    dto.Nombre,
                    dto.Precio,
                    dto.Stock,
                    (int)dto.CategoriaId,
                    dto.Marca,
                    (int)dto.ProveedorId
                );
        }

        #endregion


        #region Articulo --> ArticuloInsertDto

        public static ArticuloInsertDto ArticuloToArticuloInsertDto (Articulo articulo)
        {
            return new ArticuloInsertDto(
                    articulo.Nombre, 
                    articulo.Precio,
                    articulo.Stock,
                    (int)articulo.CategoriaId,
                    articulo.Marca,
                    (int)articulo.ProveedorId
                );
        }

        #endregion

        #endregion

        #region VENTA

        #region VentaInsertDto --> Venta

        public static Venta VentaInsertDtoToVenta(VentaInsertDto dto)
        {
            return new Venta(
                    dto.LocalId,
                    dto.ArticuloId,
                    dto.Importe,
                    dto.Unidad
                );
        }

        #endregion

        #region Venta --> VentaInsertDto

        public static VentaInsertDto VentaToVentaInsertDto(Venta venta)
        {
            return new VentaInsertDto(
                    (int)venta.LocalId,
                    (int)venta.ArticuloId,
                    venta.Importe,
                    venta.Unidad
                );
        }

        #endregion

        #endregion

    }
}
