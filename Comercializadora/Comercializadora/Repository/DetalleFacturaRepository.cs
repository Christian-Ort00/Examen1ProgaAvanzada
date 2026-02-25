using Comercializadora.Models;

namespace Comercializadora.Repository
{
    public class DetalleFacturaRepository : IDetalleFacturaRepository

    {

        List<DetalleFactura> detalles = new List<DetalleFactura>();

        
        public void agregarDetalle(DetalleFactura detalle)
        {
            detalles.Add(detalle);
        }

        public List<DetalleFactura> ObtenerDetalles()
        {
            return detalles;
        }

        public List<DetalleFactura> ObtenerDetallesPorFactura(int facturaId)
        {
            return detalles.Where(d => d.FacturaId == facturaId).ToList();  
        }
    }
}
