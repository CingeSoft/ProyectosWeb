using System;
using System.Collections.Generic;

namespace CingeRazor.Models
{
    public partial class InventFacturaLinea
    {
        public string Consecutivo { get; set; }
        public string Mascota { get; set; }
        public int Linea { get; set; }
        public string Articulo { get; set; }
        public string Nombre { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioTotal { get; set; }
        public decimal DescuentoPorcentaje { get; set; }
        public decimal Descuento { get; set; }
        public decimal ImpuestoPorcentaje { get; set; }
        public decimal Impuesto { get; set; }
        public decimal TotalLinea { get; set; }

        public Articulos ArticuloNavigation { get; set; }
        public InventFactura ConsecutivoNavigation { get; set; }
        public InventFacturaMascota InventFacturaMascota { get; set; }
    }
}
