using Ferreteria.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.Business
{
    public class CategoriaNegocio : FContext
    {

        public List<Categoria> GetAll()
        {
            return this.Context.Categorias.ToList();    
        }

        public Categoria Get(int id)
        {
            return this.Context.Categorias.Where(a => a.Id == id).FirstOrDefault(); 
        }

        public Categoria GetByCondition(Expression<Func<Categoria, bool>> condition)
        {
            return this.Context.Categorias.Where(condition).FirstOrDefault();
        }

        public bool ExisteCategoria(Expression<Func<Categoria, bool>> expression)
        {
            return this.Context.Categorias
                .Any(expression);
        }


        public bool Save(Categoria categoria, EntityState state)
        {
            var existe = this.Get(categoria.Id);

            if(existe != null)
            {
                this.Context.Entry(existe).CurrentValues.SetValues(categoria);
                this.Context.Entry(existe).State = state;
            }
            else
            {
                this.Context.Entry(categoria).State = state;
            }
            return this.Context.SaveChanges() > 0;
        }

        public bool Insert(Categoria categoria)
        {
            return this.Save(categoria, EntityState.Added);
        }

        public bool Update(Categoria categoria)
        {
            return this.Save(categoria, EntityState.Modified);
        }

    }
}
