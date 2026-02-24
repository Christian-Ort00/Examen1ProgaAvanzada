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
        public IActionResult Crear()
        {
            ViewBag.Productos = _productoService.ObtenerProductos();
            return View();
        }

        [HttpPost]
        public IActionResult Crear(DetalleFactura detalle)
        {
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
