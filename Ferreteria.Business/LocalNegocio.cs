using Ferreteria.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Ferreteria.Business
{
    public class LocalNegocio : FContext
    {

        public List<Local> GetAll()
        {
            return this.Context.Locales.ToList();
        }

        public Local GetById(int id)
        {
            return this.Context.Locales
                .Where(a => a.Id == id)
                .FirstOrDefault();
        }

        public Local GetByParams(Expression<Func<Local, bool>> where)
        {
            return this.Context.Locales
                .Where(where)
                .FirstOrDefault();
        }

        public bool Save(Local local, EntityState state)
        {
            var existe = this.GetById(local.Id);

            if (existe != null)
            {
                this.Context.Entry(existe).CurrentValues.SetValues(local);
                this.Context.Entry(existe).State = state;
            } 
            else 
            {
                this.Context.Entry(local).State = state;
            }
            return this.Context.SaveChanges() > 0;
        }

        public bool Insert(Local local)
        {
            return this.Save(local, EntityState.Added);
        }

        public bool Update(Local local)
        {
            return this.Save(local, EntityState.Modified);
        }

        public bool Delete(Local local)
        {
            return this.Save(local, EntityState.Deleted);
        }
    }
}
