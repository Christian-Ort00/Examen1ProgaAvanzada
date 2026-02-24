
using Comercializadora.Models;

namespace Comercializadora.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        List<Producto> productos = new List<Producto>();

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        public List<Producto> ObtenerProductos()
        {
            return productos;
        }
    }
}
