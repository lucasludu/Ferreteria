//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ferreteria.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public Nullable<int> PuestoId { get; set; }
        public Nullable<int> LocalId { get; set; }
    
        public virtual Local Local { get; set; }
        public virtual Puesto Puesto { get; set; }
    }
}
