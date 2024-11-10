namespace Ferreteria.Models
{
    public partial class Articulo
    {
        public Articulo(string nombre, decimal precio, int stock, int categoriaId, string marca, int proveedorId) : this()
        {
            this.Nombre = nombre;
            this.Precio = precio;
            this.Stock = stock;
            this.CategoriaId = categoriaId;
            this.Marca = marca;
            this.ProveedorId = proveedorId;
            this.Activo = true;
        }

        public Articulo(int id, string nombre, decimal precio, int stock, int categoriaId, string marca, int proveedorId)
            : this(nombre, precio, stock, categoriaId, marca, proveedorId)
        {
            this.Id = id;
            this.Activo = true;
        }

        public Articulo Clone()
        {
            return new Articulo (
                    Id = this.Id,
                    Nombre = this.Nombre,
                    Precio = this.Precio,
                    Stock = this.Stock,
                    (int)(CategoriaId = this.CategoriaId),
                    Marca = this.Marca,
                    (int)(ProveedorId = this.ProveedorId)
            );
        }
    }
}
