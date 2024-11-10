using Ferreteria.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Ferreteria.Business
{
    public class ProveedorNegocio : FContext
    {

        public List<Proveedor> GetAll()
        {
            return this.Context.Proveedores.ToList();    
        }

        public Proveedor Get(int id)
        {
            return this.Context.Proveedores.Where(a => a.Id == id).FirstOrDefault(); 
        }

        public Proveedor GetByCondition(Expression<Func<Proveedor, bool>> condition)
        {
            return this.Context.Proveedores.Where(condition).FirstOrDefault();
        }

        public bool ExisteProveedor(Expression<Func<Proveedor, bool>> expression)
        {
            return this.Context.Proveedores
                .Any(expression);
        }


        public bool Save(Proveedor proveedor, EntityState state)
        {
            var existe = this.Get(proveedor.Id);

            if(existe != null)
            {
                this.Context.Entry(existe).CurrentValues.SetValues(proveedor);
                this.Context.Entry(existe).State = state;
            }
            else
            {
                this.Context.Entry(proveedor).State = state;
            }
            return this.Context.SaveChanges() > 0;
        }

        public bool Insert(Proveedor proveedor)
        {
            return this.Save(proveedor, EntityState.Added);
        }

        public bool Update(Proveedor proveedor)
        {
            return this.Save(proveedor, EntityState.Modified);
        }

        public bool Delete(Proveedor proveedor)
        {
            return this.Save(proveedor, EntityState.Deleted);
        }

    }
}
