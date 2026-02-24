using Comercializadora.Models;
using Comercializadora.Repository;

namespace Comercializadora.Service
{
    public class FacturaService : IFacturaService
        

    {
        public readonly IFacturaRepository _facturaRepository;

        public FacturaService(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        public void AgregarFactura(Factura factura)
        {
            _facturaRepository.AgregarFactura(factura);

        }

        public List<Factura> ObtenerFacturas()
        {
           return _facturaRepository.ObtenerFacturas();
        }
    }
}
