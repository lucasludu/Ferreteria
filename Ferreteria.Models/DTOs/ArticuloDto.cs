namespace Ferreteria.Models.DTOs
{
    public class ArticuloDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Categoria { get; set; }

        public ArticuloDto()
        {
            
        }

        public ArticuloDto(string nombre, string descripcion, decimal precio, int stock, string categoria) : this()
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
            Categoria = categoria;
        }
    }
}
