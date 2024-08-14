using System.Runtime.Remoting;

namespace Ferreteria.Models
{
    public partial class Local
    {
        public Local(string nombre, string direccion, string telefono)
        {
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
        }

        public Local(int id, string nombre, string direccion, string telefono)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
        }

        
        public Local Clone()
        {
            return new Local
            {
                Id = this.Id,
                Nombre = this.Nombre,
                Direccion = this.Direccion,
                Telefono = this.Telefono,
                Empleadoes = this.Empleadoes,
                Ventas = this.Ventas
            };
        }

    }
}
