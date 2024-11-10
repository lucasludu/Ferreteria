using Ferreteria.Models;
using Ferreteria.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
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
                    (a, c) => new { a, c }
                )
                .Join(this.Context.Proveedores,
                    ar => ar.a.ProveedorId,
                    p => p.Id,
                    (ar, p) => new {ar.a, ar.c, p}
                )
                .Select(ac => new
                {
                    art = ac.a,
                    nombreCategoria = ac.c.Nombre,
                    nombreProveedor = ac.p.Nombre
                }).ToList();
            
            return query == null 
                ? null 
                : query.Select(a => new ArticuloDto(
                    a.art.Nombre, 
                    a.art.Precio, 
                    a.art.Stock, 
                    a.nombreCategoria,
                    a.art.Marca,
                    a.nombreProveedor,
                    (bool)a.art.Activo)
                )
                .ToList();
        }

        public ArticuloDto GetByParamsDto(Expression<Func<Articulo, bool>> expression)
        {
            var query = this.Context.Articulos
                .Where(expression)
                .Join(Context.Categorias,
                    a => a.CategoriaId,
                    c => c.Id,
                    (a, c) => new { a, c}
                )
                 .Join(this.Context.Proveedores,
                    ar => ar.a.ProveedorId,
                    p => p.Id,
                    (ar, p) => new { ar.a, ar.c, p }
                )
                .Select(x => new
                {
                    art = x.a,
                    NombreCategoria = x.c.Nombre,
                    nombreProveedor = x.p.Nombre
                })
                .FirstOrDefault();
            return query != null 
                ? new ArticuloDto (
                        query.art.Nombre, 
                        query.art.Precio, 
                        query.art.Stock, 
                        query.NombreCategoria,
                        query.art.Marca,
                        query.nombreProveedor,
                        (bool)query.art.Activo
                    )
                : null;
        }

        public Articulo GetByParams(Expression<Func<Articulo, bool>> expression)
        {
            return this.Context.Articulos.Where(expression).FirstOrDefault();
        }

        public List<Articulo> GetAllByParams(Expression<Func<Articulo, bool>> expression)
        {
            return this.Context.Articulos.Where(expression).ToList();
        }

        public List<ArticuloDto> GetAllDtoByCategoria(int idCategoria)
        {
            var query = this.Context.Articulos
                .Join(Context.Categorias,
                    a => a.CategoriaId,
                    c => c.Id,
                    (a, c) => new { a, c }
                )
                .Join(this.Context.Proveedores,
                    ar => ar.a.ProveedorId,
                    p => p.Id,
                    (ar, p) => new { ar.a, ar.c, p }
                )
                .Where(x => idCategoria == 0 || x.c.Id == idCategoria)
                .Select(x => new
                {
                    Nombre = x.a.Nombre,
                    Precio = x.a.Precio,
                    Stock = x.a.Stock,
                    NombreCategoria = x.c.Nombre,
                    NombreProveedor = x.p.Nombre,
                    Marca = x.a.Marca,
                    Activo = x.a.Activo
                })
                .ToList(); 

            return 
                query.Select(q => new ArticuloDto (
                    q.Nombre,
                    q.Precio,
                    q.Stock,
                    q.NombreCategoria,
                    q.Marca,
                    q.NombreProveedor,
                    (bool)q.Activo
                )).ToList();
        }




        public bool ExisteArticulo(Expression<Func<Articulo, bool>> expression)
        {
            return this.Context.Articulos
                .Any(expression);
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


        public bool InsertAll(List<Articulo> articuloList)
        {
            var transaction = this.Context.Database.BeginTransaction();

            try
            {
                foreach(var articulo in articuloList)
                {
                    var existe = this.GetByParams(a => a.Nombre.ToLower().Trim().Equals(articulo.Nombre.ToLower().Trim()));

                    if(existe != null)
                    {
                        existe.Nombre = articulo.Nombre;
                        existe.Precio = articulo.Precio;
                        existe.CategoriaId = articulo.CategoriaId;
                        existe.Stock += articulo.Stock;

                        this.Context.Entry(existe).State = EntityState.Modified;
                    }
                    else
                    {
                        this.Context.Articulos.Add(articulo);
                    }
                }
                this.Context.SaveChanges();

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
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
