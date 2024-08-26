using Ferreteria.Models;
using Ferreteria.Models.DTOs;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Ferreteria.Business
{
    public class EmpleadoNegocio : FContext
    {

        public Empleado GetByCondition(Expression<Func<Empleado, bool>> condition)
        {
            return this.Context.Empleados
                .Where(condition)
                .FirstOrDefault();
        }

        public Empleado GetById(int id)
        {
            return this.Context.Empleados
                .Where(a => a.Id == id)
                .FirstOrDefault();
        }

        public bool ExisteEmpleado(Expression<Func<Empleado, bool>> expression)
        {
            return this.Context.Empleados
                .Any(expression);
        }

        public EmpleadoDto GetDto(string correo)
        {
            var empleadoData = Context.Empleados
                .Join(Context.Locales,
                    e => e.LocalId,
                    l => l.Id,
                    (e, l) => new { e, l })
                .Join(Context.Puestos,
                    el => el.e.PuestoId,
                    p => p.Id,
                    (el, p) => new { el.e, el.l, p })
                .Where(ep => ep.e.Correo.Equals(correo))
                .Select(ep => new
                {
                    NombreEmpleado = ep.e.Nombre,
                    CorreoEmpleado = ep.e.Correo,
                    NombrePuesto = ep.p.Nombre,
                    NombreLocal = ep.l.Nombre
                })
                .FirstOrDefault();

            return empleadoData != null ? new EmpleadoDto (
                empleadoData.NombreEmpleado,
                empleadoData.CorreoEmpleado,
                empleadoData.NombrePuesto,
                empleadoData.NombreLocal
            ) : null;

        }

        public bool Save(Empleado empleado, EntityState state)
        {
            var existe = this.GetByCondition(e => e.Id == empleado.Id);

            if(existe != null)
            {
                this.Context.Entry(existe).CurrentValues.SetValues(empleado);
                this.Context.Entry(existe).State = state;
            }
            else
            {
                this.Context.Entry(empleado).State = state;
            }
            return this.Context.SaveChanges() > 0;
        } 

        public bool Insert(Empleado empleado)
        {
            return this.Save(empleado, EntityState.Added);
        }

        public bool Update(Empleado empleado)
        {
            return this.Save(empleado, EntityState.Modified);
        }

    }
}
