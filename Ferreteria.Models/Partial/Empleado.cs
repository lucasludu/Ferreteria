using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            
        }

        public Empleado(string nombre, string correo, string password, int idRol, int idLocal) : base()
        {
            this.Nombre = nombre;
            this.Correo = correo;
            this.Password = password;
            this.PuestoId = idRol;
            this.LocalId = idLocal;
        }

        public Empleado(int id, string nombre, string correo, string password, int idRol, int idLocal) 
            : this(nombre, correo, password, idRol, idLocal)
        {
            this.Id = id;
        }

    }
}
