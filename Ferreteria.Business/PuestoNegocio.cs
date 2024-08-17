using Ferreteria.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ferreteria.Business
{
    public class PuestoNegocio : FContext
    {
        public List<Puesto> GetAll()
        {
            return this.Context.Puestos.ToList();
        }

        public Puesto GetById(int id)
        {
            return this.Context.Puestos.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
