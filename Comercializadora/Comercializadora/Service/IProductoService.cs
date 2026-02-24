
using Comercializadora.Models;
namespace Comercializadora.Service
{
    public interface IProductoService
    {

        public void AgregarProducto(Producto producto);

        public List<Producto> ObtenerProductos();
    }
}
