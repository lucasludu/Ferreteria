using Ferreteria.Models;
using Ferreteria.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Ferreteria.Business
{
    public class ArticuloNegocio : FContext
    {

        public List<Articulo> GetAll()
        {
            return this.Context.Articulos.ToList();
        }

        public List<ArticuloDto> GetAllDto()
        {
            var query = this.Context.Articulos
                .Join(Context.Categorias,
                    a => a.CategoriaId,
                    c => c.Id,
                    (a, c) => new { a, c })
                .Select(ac => new
                {
                    art = ac.a,
                    nombreCategoria = ac.c.Nombre
                }).ToList();
            
            return query == null 
                ? null 
                : query.Select(a => new ArticuloDto(a.art.Nombre, a.art.Descripcion, a.art.Precio, a.art.Stock, a.nombreCategoria)).ToList();
        }

        public ArticuloDto GetByConditionDto(Expression<Func<Articulo, bool>> expression)
        {
            var query = this.Context.Articulos
                .Where(expression)
                .Join(Context.Categorias,
                    a => a.CategoriaId,
                    c => c.Id,
                    (a, c) => new { Articulo = a, Categoria = c})
                .Select(x => new
                {
                    a = x.Articulo,
                    NombreCategoria = x.Categoria.Nombre
                })
                .FirstOrDefault();
            return query != null 
                ? new ArticuloDto(
                    query.a.Nombre, 
                    query.a.Descripcion, 
                    query.a.Precio, 
                    query.a.Stock, 
                    query.NombreCategoria)
                : null;
        }

        public Articulo GetByParams(Expression<Func<Articulo, bool>> expression)
        {
            return this.Context.Articulos.Where(expression).FirstOrDefault();
        }

        public bool Save(Articulo articulo, EntityState state)
        {
            var existe = this.GetByParams(a => a.Id == articulo.Id);

            if(existe != null)
            {
                this.Context.Entry(existe).CurrentValues.SetValues(articulo);
                this.Context.Entry(existe).State = state;
            }
            else
            {
                this.Context.Entry(articulo).State = state;
            }
            return this.Context.SaveChanges() > 0;
        }

        public bool Insert(Articulo articulo)
        {
            return this.Save(articulo, EntityState.Added);
        }

        public bool Delete(Articulo articulo)
        {
            return this.Save(articulo, EntityState.Deleted);
        }

        public bool Update(Articulo articulo)
        {
            return this.Save(articulo, EntityState.Modified);
        }

    }
}
