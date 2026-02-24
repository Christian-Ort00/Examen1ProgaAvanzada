using Comercializadora.Models;
namespace Comercializadora.Repository
{
    public interface IDetalleFacturaRepository 
    {

        public void agregarDetalle(DetalleFactura detalle);

        public List<DetalleFactura> ObtenerDetalles(); 
    }
}
