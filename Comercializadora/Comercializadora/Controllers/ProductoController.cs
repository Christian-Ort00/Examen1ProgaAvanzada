
using Comercializadora.Models;
using Comercializadora.Service;
using Microsoft.AspNetCore.Mvc;
namespace Comercializadora.Controllers
{


    public class ProductoController : Controller
    {

        public readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }
        public IActionResult Index()
        {
            var productos = _productoService.ObtenerProductos();
            return View(productos);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Crear(Producto producto)
        {
            _productoService.AgregarProducto(producto);
            return RedirectToAction("Index");
        }
    }
}
