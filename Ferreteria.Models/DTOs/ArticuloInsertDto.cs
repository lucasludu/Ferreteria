using System;

namespace Ferreteria.Models.DTOs
{
    public class ArticuloInsertDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public Nullable<int> CategoriaId { get; set; }
        public string Marca { get; set; }
        public Nullable<int> ProveedorId { get; set; }

        public ArticuloInsertDto()
        {
            
        }

        public ArticuloInsertDto(string nombre, decimal precio, int stock, int categoriaId, string marca, int proveedorId) : this()
        {
            this.Nombre = nombre;
            this.Precio = precio;
            this.Stock = stock;
            this.CategoriaId = categoriaId;
            this.Marca = marca;
            this.ProveedorId = proveedorId;
        }

        public ArticuloInsertDto(int id, string nombre, decimal precio, int stock, int categoriaId, string marca, int proveedorId) 
            : this(nombre, precio, stock, categoriaId, marca, proveedorId)
        {
            this.Id = id;
        }

    }
}
