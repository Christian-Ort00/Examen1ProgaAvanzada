using Comercializadora.Models;
namespace Comercializadora.Service
{
    public interface IFacturaService
    {
        public void AgregarFactura(Factura factura);
        public List<Factura> ObtenerFacturas();


    }
}
