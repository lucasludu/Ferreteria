namespace Ferreteria.Models.DTOs
{
    public class ArticuloDto
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public string Proveedor { get; set; }
        public bool Activo { get; set; }

        public ArticuloDto()
        {
            
        }

        public ArticuloDto(string nombre, decimal precio, int stock, string categoria, string marca, string proveedor, bool activo) : this()
        {
            this.Nombre = nombre;
            this.Precio = precio;
            this.Stock = stock;
            this.Categoria = categoria;
            this.Marca = marca;
            this.Proveedor = proveedor;
            this.Activo = activo;
        }
    }
}
