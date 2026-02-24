using Comercializadora.Models;
using Comercializadora.Repository;

namespace Comercializadora.Service
{
    public class FacturaService : IFacturaService
        

    {
        public readonly IFacturaRepository _facturaRepository;
        private readonly IDetalleFacturaRepository _detalleRepository;


        public FacturaService(IFacturaRepository facturaRepository, IDetalleFacturaRepository detalleRepository)
        {
            _facturaRepository = facturaRepository;
            _detalleRepository = detalleRepository;
        }

        public void AgregarFactura(Factura factura)
        {

            _facturaRepository.AgregarFactura(factura);

        }

        public void CalcularTotales(int facturaId)
        {
            var factura = _facturaRepository.ObtenerFacturas().FirstOrDefault(f => f.Id == facturaId);
            var detalles = _detalleRepository.ObtenerDetalles().Where(d => d.FacturaId == facturaId).ToList();

            if (factura != null)
            {
                factura.Subtotal = detalles.Sum(d => d.Cantidad * d.PrecioUnitario);
                factura.Impuesto = factura.Subtotal * 0.13m; 
                factura.Total = factura.Subtotal + factura.Impuesto;
            }
        }

        public List<Factura> ObtenerFacturas()
        {
           return _facturaRepository.ObtenerFacturas();
        }
    }
}
