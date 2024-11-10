using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.Models
{
    public partial class Proveedor
    {
        public Proveedor(string nombre, string telefono, string correo)
        {
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Correo = correo;
        }

        public Proveedor(int id, string nombre, string telefono, string correo)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Correo = correo;
        }

        public Proveedor Clone()
        {
            return new Proveedor(this.Id, this.Nombre, this.Telefono, this.Correo);
        }

    }
}
