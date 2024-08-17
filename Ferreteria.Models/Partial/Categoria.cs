using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.Models
{
    public partial class Categoria
    {
        public Categoria(string nombre)
        {
            this.Nombre = nombre;
        }

        public Categoria(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }
    }
}
