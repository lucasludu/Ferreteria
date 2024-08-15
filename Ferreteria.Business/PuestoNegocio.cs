using Ferreteria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.Business
{
    public class PuestoNegocio : FContext
    {
        public List<Puesto> GetAll()
        {
            return this.Context.Puestos.ToList();
        }
    }
}
