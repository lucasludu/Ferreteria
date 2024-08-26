using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.Models
{
    public partial class Articulo
    {
        public Articulo(string nombre, string descripcion, decimal precio, int stock, int categoriaId) : this()
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Stock = stock;
            this.CategoriaId = categoriaId;
        }

        public Articulo(int id, string nombre, string descripcion, decimal precio, int stock, int categoriaId)
            : this(nombre, descripcion, precio, stock, categoriaId)
        {
            this.Id = id;
        }

        public Articulo Clone()
        {
            return new Articulo (
                    Id = this.Id,
                    Nombre = this.Nombre,
                    Descripcion = this.Descripcion,
                    Precio = this.Precio,
                    Stock = this.Stock,
                    (int)(CategoriaId = this.CategoriaId)
                );
        }
    }
}
