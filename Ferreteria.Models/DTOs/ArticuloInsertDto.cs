using System;

namespace Ferreteria.Models.DTOs
{
    public class ArticuloInsertDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public Nullable<int> CategoriaId { get; set; }

        public ArticuloInsertDto()
        {
            
        }

        public ArticuloInsertDto(string nombre, string descripcion, decimal precio, int stock, int categoriaId) : this()
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Stock = stock;
            this.CategoriaId = categoriaId;
        }

        public ArticuloInsertDto(int id, string nombre, string descripcion, decimal precio, int stock, int categoriaId) 
            : this(nombre, descripcion, precio, stock, categoriaId)
        {
            this.Id = id;
        }

    }
}
