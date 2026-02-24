using Comercializadora.Models;
using Comercializadora.Repository;

namespace Comercializadora.Service
{
    public class DetalleFacturaService : IDetalleFacturaService

    {

        public readonly IFacturaService _facturaService;
        public readonly IDetalleFacturaRepository _detalleFacturaRepository;
        public readonly IProductoService _productoService;

        public DetalleFacturaService(IFacturaService facturaService, IDetalleFacturaRepository detalleFacturaRepository, IProductoService productoService)
        {
            _facturaService = facturaService;
            _detalleFacturaRepository = detalleFacturaRepository;
            _productoService = productoService;
        }

        public void AgregarDetalle(DetalleFactura detalle)
        {
            var producto = _productoService.ObtenerProductos().FirstOrDefault(p => p.Id == detalle.ProductoId);

            var factura = _facturaService.ObtenerFacturas().FirstOrDefault(f => f.Id == detalle.FacturaId);

            var detalleExistente = new DetalleFactura
            {
                FacturaId = factura.Id,
                ProductoId = producto.Id,
                NombreProducto = producto.Nombre,
                Cantidad = detalle.Cantidad,
                PrecioUnitario = producto.Precio,
            };

            _detalleFacturaRepository.agregarDetalle(detalleExistente);
            _facturaService.CalcularTotales(detalle.FacturaId);


        }

        public List<DetalleFactura> ObtenerDetalles()
        {
            return _detalleFacturaRepository.ObtenerDetalles();
        }
    }
}
