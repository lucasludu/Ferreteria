using System;

namespace Ferreteria.Models
{
    public partial class Venta
    {
        public Venta()
        {
            FechaVta = DateTime.Now;
        }

        public Venta(int? localId, int? articuloId, decimal importe, int unidad) : this()
        {
            LocalId = localId;
            ArticuloId = articuloId;
            Importe = importe;
            Unidad = unidad;
        }
    }
}
