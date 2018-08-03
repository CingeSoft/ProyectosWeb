using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CingeRazor.Models
{
    public partial class InventFacturaMascota
    {
        public InventFacturaMascota()
        {
            InventFacturaLinea = new HashSet<InventFacturaLinea>();
        }

        public string Consecutivo { get; set; }
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Nombre { get; set; }

        public InventFactura ConsecutivoNavigation { get; set; }
        public Mascotas NombreNavigation { get; set; }
        public ICollection<InventFacturaLinea> InventFacturaLinea { get; set; }
    }
}
