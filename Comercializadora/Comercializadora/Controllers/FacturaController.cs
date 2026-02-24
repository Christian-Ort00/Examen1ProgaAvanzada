using Comercializadora.Models;
using Comercializadora.Service;
using Microsoft.AspNetCore.Mvc;

namespace Comercializadora.Controllers
{
    public class FacturaController : Controller
    {

        public readonly IFacturaService _facturaService;

        public FacturaController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }
        public IActionResult Index()
        {
            var facturas= _facturaService.ObtenerFacturas();
            return View(facturas);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult Crear(Factura factura)
        {
            _facturaService.AgregarFactura(factura);
            return RedirectToAction("Index");
        }




    }
}
