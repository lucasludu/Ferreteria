namespace Ferreteria.Models.DTOs
{
    public class VentaInsertDto
    {
        public int LocalId { get; set; }
        public int ArticuloId { get; set; }
        public decimal Importe { get; set; }
        public int Unidad { get; set; }

        public VentaInsertDto()
        {
            
        }

        public VentaInsertDto(int localId, int articuloId, decimal importe, int unidad) : this()
        {
            this.LocalId = localId;
            this.ArticuloId = articuloId;
            this.Importe = importe;
            this.Unidad = unidad;
        }
    }
}
