using AspNetCoreGeneratedDocument;
using Comercializadora.Models;
using Comercializadora.Service;
using Microsoft.AspNetCore.Mvc;

namespace Comercializadora.Controllers
{
    public class FacturaController : Controller
    {

        public readonly IFacturaService _facturaService;
        public readonly IDetalleFacturaService _detalleFacturaService;

        public FacturaController(IFacturaService facturaService, IDetalleFacturaService detalleFacturaService)
        {
            _facturaService = facturaService;
            _detalleFacturaService= detalleFacturaService;
        }
        public IActionResult Index()
        {
            var facturas = _facturaService.ObtenerFacturas();
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

        [HttpGet]
        public IActionResult Detalle(int id)
        {
            var factura = _facturaService.ObtenerFacturas().FirstOrDefault(f => f.Id == id);
            var detalle = _detalleFacturaService.ObtenerDetallesPorFactura(id);

            ViewBag.Detalles= detalle;
            return View(factura);




        }
        public FileResult DescargarTxt(int id)
        {
            var factura = _facturaService.ObtenerFacturas().FirstOrDefault(f => f.Id == id);
            var detalles = _detalleFacturaService.ObtenerDetallesPorFactura(id);

            string contenido = $"Cliente: {factura.NombreCliente}\n" +
                               $"Fecha: {factura.Fecha:dd/MM/yyyy}\n\n" +
                               "Productos:\n";

            foreach (var detalle in detalles)
            {
                contenido += $"{detalle.NombreProducto} - Cantidad: {detalle.Cantidad} - Precio: {detalle.PrecioUnitario}\n";
            }

            contenido += $"\nSubtotal: {factura.Subtotal}\n" +
                         $"Impuesto: {factura.Impuesto}\n" +
                         $"Total: {factura.Total}";

            byte[] archivoBytes = System.Text.Encoding.UTF8.GetBytes(contenido);
            string contentType = "text/plain";
            string fileName = $"Factura_{factura.Id}.txt";

            return File(archivoBytes, contentType, fileName);
        }

    }
}
