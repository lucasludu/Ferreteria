using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.Models.DTOs
{
    public class EmpleadoDto
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Puesto { get; set; }
        public string Local { get; set; }

        public EmpleadoDto()
        {
            
        }

        public EmpleadoDto(string nombre, string correo, string puesto, string local) : base()
        {
            this.Nombre = nombre;
            this.Correo = correo;
            this.Puesto = puesto;
            this.Local = local;
        }
    }
}
