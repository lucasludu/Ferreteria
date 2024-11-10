using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.Models.DTOs
{
    public class RegisterDto
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public Nullable<int> PuestoId { get; set; }
        public Nullable<int> LocalId { get; set; }

        public RegisterDto()
        {
            
        }

        public RegisterDto(string nombre, string correo, string password, int? puestoId, int? localId)
        {
            this.Nombre = nombre;
            this.Correo = correo;
            this.Password = password;
            this.PuestoId = puestoId;
            this.LocalId = localId;
        }

    }
}
