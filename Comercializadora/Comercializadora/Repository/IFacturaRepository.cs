using Comercializadora.Models;
namespace Comercializadora.Repository

{
    public interface IFacturaRepository
    {
        public void AgregarFactura(Factura factura);

        public List<Factura> ObtenerFacturas();

    }
}
