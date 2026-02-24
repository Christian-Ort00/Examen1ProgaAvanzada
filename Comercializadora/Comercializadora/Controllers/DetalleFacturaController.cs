using Comercializadora.Models;
using Comercializadora.Service;
using Microsoft.AspNetCore.Mvc;

namespace Comercializadora.Controllers
{
    public class DetalleFacturaController : Controller
    {

        public readonly IDetalleFacturaService _detalleFacturaService;
        public readonly IProductoService _productoService;

        public DetalleFacturaController(IDetalleFacturaService detalleFacturaService, IProductoService productoService)
        {
            _detalleFacturaService = detalleFacturaService;
            _productoService = productoService;
        }

        [HttpGet]
        public IActionResult Crear(int id)
        {
            ViewBag.Productos = _productoService.ObtenerProductos();
            var detalle = new DetalleFactura
            {
                FacturaId = id
            };  
            return View(detalle);
        }

        [HttpPost]
        public IActionResult Crear(DetalleFactura detalle)
        {
            ModelState.Remove("Factura");
            ModelState.Remove("NombreProducto");
            ModelState.Remove("PrecioUnitario");

            if (ModelState.IsValid)
            {
                _detalleFacturaService.AgregarDetalle(detalle);
                return RedirectToAction("Index", "Factura");
            }
            ViewBag.Productos = _productoService.ObtenerProductos();
            return View(detalle);
        }



    }
}
