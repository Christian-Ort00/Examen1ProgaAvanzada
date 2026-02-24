using Comercializadora.Models;

namespace Comercializadora.Repository
{
    public class FacturaRepository : IFacturaRepository
    {
        List<Factura> facturas = new List<Factura>();

        public void AgregarFactura(Factura factura)
        {
            factura.Id = facturas.Count + 1; 
            facturas.Add(factura);
        }

        public List<Factura> ObtenerFacturas()
        {
            return facturas;
        }
    }
}
