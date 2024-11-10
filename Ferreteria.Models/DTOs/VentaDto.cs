using System;

namespace Ferreteria.Models.DTOs
{
    public class VentaDto
    {
        public string Local { get; set; }
        public string Articulo { get; set; }
        public decimal Importe { get; set; }
        public int Unidad { get; set; }
        public DateTime FechaVta { get; set; }

        public VentaDto()
        {
            
        }

        public VentaDto(string local, string articulo, decimal importe, int unidad, DateTime fechaVenta) : this()
        {
            this.Local = local;
            this.Articulo = articulo;
            this.Importe = importe;
            this.Unidad = unidad;
            this.FechaVta = fechaVenta;
        }

    }
}
