using System;
using System.Collections.Generic;

namespace CingeRazor.Models
{
    public partial class InventFacturaMascota
    {
        public InventFacturaMascota()
        {
            InventFacturaLinea = new HashSet<InventFacturaLinea>();
        }

        public string Consecutivo { get; set; }
        public string Nombre { get; set; }

        public InventFactura ConsecutivoNavigation { get; set; }
        public Mascotas NombreNavigation { get; set; }
        public ICollection<InventFacturaLinea> InventFacturaLinea { get; set; }
    }
}
