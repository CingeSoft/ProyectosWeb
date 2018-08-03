using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CingeRazor.Models
{
    public partial class InventFacturaLinea
    {
        public string Consecutivo { get; set; }
        [Required(ErrorMessage = "El campo Mascota es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Mascota { get; set; }

        [Required(ErrorMessage = "El campo Linea es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public int Linea { get; set; }

        [Required(ErrorMessage = "El campo Articulo es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Articulo { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
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
