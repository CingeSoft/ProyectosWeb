using System;
using System.Collections.Generic;

namespace CingeWeb.Models
{
    public partial class Clientes
    {
        public string Código { get; set; }
        public string Nombre { get; set; }
        public string Localidad { get; set; }
        public string CódigoCédula { get; set; }
        public string Cédula { get; set; }
        public string TelefonoCodigoArea { get; set; }
        public string Teléfono { get; set; }
        public string Dirección { get; set; }
        public string Email { get; set; }
        public DateTime FechaCreacíon { get; set; }
        public string CódigoZona { get; set; }

        public Cedulas CódigoCédulaNavigation { get; set; }
        public Zonas CódigoZonaNavigation { get; set; }
    }
}
