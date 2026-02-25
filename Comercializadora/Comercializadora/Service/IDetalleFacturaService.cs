using Comercializadora.Models;

namespace Comercializadora.Service
{
    public interface IDetalleFacturaService


    {
        public void AgregarDetalle(DetalleFactura detalle);

        
        public List<DetalleFactura> ObtenerDetalles();
        
        public List<DetalleFactura> ObtenerDetallesPorFactura(int facturaId);

    }
}
