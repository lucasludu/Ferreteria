using Ferreteria.Models;
using Ferreteria.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Ferreteria.Business
{
    public class VentaNegocio : FContext
    {

        public List<Venta> GetAll()
        {
            return this.Context.Ventas.ToList();
        }

        public List<VentaDto> GetAllDto()
        {
            return this.Context.Ventas
                .Join(this.Context.Locales,
                    v => v.LocalId,
                    l => l.Id,
                    (v,l) => new { v, l })
                .Join(this.Context.Articulos,
                    ve => ve.v.ArticuloId,
                    a => a.Id,
                    (ve, a) => new { ve.v, ve.l, a})
                .Select(venta => new VentaDto
                {
                    Local = venta.l.Nombre,
                    Articulo = venta.a.Nombre,
                    Importe = venta.v.Importe,
                    Unidad = venta.v.Unidad,
                    FechaVta = venta.v.FechaVta ?? DateTime.MinValue
                })
                .ToList();
        }

        public Venta GetByCondition(Expression<Func<Venta, bool>> condition)
        {
            return this.Context.Ventas
                .Where(condition)
                .FirstOrDefault();
        }

        public VentaDto GetDto(Expression<Func<Venta, bool>> condition)
        {
            return this.Context.Ventas
                .Where(condition)
                .Join(this.Context.Locales,
                    v => v.LocalId,
                    l => l.Id,
                    (v, l) => new { v, l })
                .Join(this.Context.Articulos,
                    ve => ve.v.ArticuloId,
                    a => a.Id,
                    (ve, a) => new { ve.v, ve.l, a })
                .Select(venta => new VentaDto
                {
                    Local = venta.l.Nombre,
                    Articulo = venta.a.Nombre,
                    Importe = venta.v.Importe,
                    Unidad = venta.v.Unidad,
                    FechaVta = venta.v.FechaVta ?? DateTime.MinValue
                })
                .FirstOrDefault();
        }

        public bool Exists(Expression<Func<Venta, bool>> expression)
        {
            return this.Context.Ventas.Any(expression);
        }

        public bool Save(Venta venta, EntityState state)
        {
            using(var transaction = this.Context.Database.BeginTransaction())
            {
                try
                {
                    // Busco el articulo
                    var articulo = this.Context.Articulos
                        .Where(a => a.Id == venta.ArticuloId)
                        .FirstOrDefault();

                    // Verifico que exista el articulo
                    if(articulo == null)
                    {
                        throw new Exception("El articulo no existe");
                    }

                    // Si la operacion es un Insert, resto el stock
                    if(state == EntityState.Added)
                    {
                        if(articulo.Stock < venta.Unidad)
                        {
                            throw new Exception("No hay suficiente stock para realizar la venta");
                        }
                        articulo.Stock -= venta.Unidad; 
                    }
                    // Si es una actualizacion, ajusta el stock segun el cambio en las unidades
                    else if(state == EntityState.Modified)
                    {
                        var ventaOriginal = this.Context.Ventas
                            .AsNoTracking()
                            .Where(v => v.Id == venta.Id)
                            .FirstOrDefault();

                        if(ventaOriginal != null)
                        {
                            var difUnidades = ventaOriginal.Unidad - venta.Unidad;
                            articulo.Stock += difUnidades; // Devuelvo el stock modificado
                        }
                    }
                    // Si es eliminado, restauro el stock
                    else if(state == EntityState.Deleted)
                    {
                        articulo.Stock += venta.Unidad;
                    }

                    // Guardo los cambios de la venta y en el articulo
                    this.Context.Entry(venta).State = state;
                    this.Context.SaveChanges();

                    // Aplico la transaccion
                    transaction.Commit();

                    return true;
                }
                catch(Exception ex)
                {
                    // En caso de un error se hace un rollback.
                    transaction.Rollback();
                    throw new Exception("Error al realizar la operacion" + ex.Message);
                }
            }   
        }


        public bool Insert(Venta venta)
        {
            return this.Save(venta, EntityState.Added);
        }

        public bool Update(Venta venta)
        {
            return this.Save(venta, EntityState.Modified);
        }

        public bool Delete(Venta venta)
        {
            return this.Save(venta, EntityState.Deleted);
        }


    }
}
