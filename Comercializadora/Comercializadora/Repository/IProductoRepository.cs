
using Comercializadora.Models;


namespace Comercializadora.Repository

{
    public interface IProductoRepository
    {
        void AgregarProducto(Producto producto);
        List<Producto> ObtenerProductos();




    }
}
