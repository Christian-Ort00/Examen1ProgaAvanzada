
using Comercializadora.Models;
using Comercializadora.Repository;
namespace Comercializadora.Service
{
    public class ProductoService : IProductoService
    {

        public readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }
        public void AgregarProducto(Producto producto)
        {
            _productoRepository.AgregarProducto(producto);
        }

        public List<Producto> ObtenerProductos()
        {
            return _productoRepository.ObtenerProductos();
        }
    }
}
