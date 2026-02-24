namespace Comercializadora.Models
{
    public class DetalleFactura
    {
        public int ProductoId { get; set; }

        public int FacturaId { get; set; }

        public string NombreProducto { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

    }
}
