using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.Models.DTOs
{
    public class LoginDto
    {
        public string Correo { get; set; }
        public string Password { get; set; }

        public LoginDto()
        {
            
        }

        public LoginDto(string correo, string password) : base()
        {
            this.Correo = correo;
            this.Password = password;
        }
    }
}
