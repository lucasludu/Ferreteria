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
    
    public partial class Venta
    {
        public int Id { get; set; }
        public Nullable<int> LocalId { get; set; }
        public Nullable<int> ArticuloId { get; set; }
        public decimal Importe { get; set; }
        public int Unidad { get; set; }
        public Nullable<System.DateTime> FechaVta { get; set; }
        public Nullable<int> MetodoPagoId { get; set; }
    
        public virtual Articulo Articulo { get; set; }
        public virtual Local Local { get; set; }
        public virtual MetodoPago MetodoPago { get; set; }
    }
}
