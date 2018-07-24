using System;
using System.Collections.Generic;

namespace CingeRazor.Models
{
    public partial class Compañias
    {
        public string IdCompañia { get; set; }
        public string NombreCompañia { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
        public string ApartadoPostal { get; set; }
        public string Direccion { get; set; }
        public string CedulaJuridica { get; set; }
        public string Correo { get; set; }
        public string PaginaWeb { get; set; }
        public string FacturaElectronica { get; set; }
        public string DireccionLogo { get; set; }
    }
}
