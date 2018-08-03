using System;
using System.Collections.Generic;

namespace CingeRazor.Models
{
    public partial class InventFactura
    {
        public InventFactura()
        {
            InventFacturaLinea = new HashSet<InventFacturaLinea>();
            InventFacturaMascota = new HashSet<InventFacturaMascota>();
        }

        public string Consecutivo { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public string Nombre { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
        public string CreadoPor { get; set; }
        public DateTime CreadoFecha { get; set; }
        public string FormaPago { get; set; }

        public Clientes ClienteNavigation { get; set; }
        public Cedulas TipoIdentificacionNavigation { get; set; }
        public ICollection<InventFacturaLinea> InventFacturaLinea { get; set; }
        public ICollection<InventFacturaMascota> InventFacturaMascota { get; set; }
    }
}
