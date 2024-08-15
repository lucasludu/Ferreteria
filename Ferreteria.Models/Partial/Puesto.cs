using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.Models
{
    public partial class Puesto
    {
        public Puesto(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }

    }
}
