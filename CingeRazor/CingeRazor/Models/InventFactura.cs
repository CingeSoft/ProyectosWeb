using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "El campo Cliente es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Cliente { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo TipoIdentificacion es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string TipoIdentificacion { get; set; }

        [Required(ErrorMessage = "El campo Identificacion es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "El campo Email es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo Telefono es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Direccion es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Direccion { get; set; }
        
        public decimal Subtotal { get; set; }
       
        public decimal Descuento { get; set; }
       
        public decimal Impuesto { get; set; }
       
        public decimal Total { get; set; }

        public string CreadoPor { get; set; }

        public DateTime CreadoFecha { get; set; }

        [Required(ErrorMessage = "El campo FormaPago es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string FormaPago { get; set; }

        public Clientes ClienteNavigation { get; set; }
        public Cedulas TipoIdentificacionNavigation { get; set; }
        public ICollection<InventFacturaLinea> InventFacturaLinea { get; set; }
        public ICollection<InventFacturaMascota> InventFacturaMascota { get; set; }
    }
}
