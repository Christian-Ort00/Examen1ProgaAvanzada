using System.ComponentModel.DataAnnotations;

namespace Comercializadora.Models
{
    public class Factura
    {
        public int Id { get; set; }

        [Required]
        public string NombreCliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }  
    }
}
