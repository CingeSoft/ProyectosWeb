using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CingeRazor.Models
{
    public partial class Compañias
    {
        [Required(ErrorMessage = "El campo IdCompañia es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string IdCompañia { get; set; }

        [Required(ErrorMessage = "El campo NombreCompañia es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string NombreCompañia { get; set; }

        [Required(ErrorMessage = "El campo Telefono es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Fax es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Fax { get; set; }

        [Required(ErrorMessage = "El campo ApartadoPostal es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ApartadoPostal { get; set; }

        [Required(ErrorMessage = "El campo Direccion es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo CedulaJuridica es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CedulaJuridica { get; set; }

        [Required(ErrorMessage = "El campo Correo es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo PaginaWeb es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PaginaWeb { get; set; }

        [Required(ErrorMessage = "El campo FacturaElectronica es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string FacturaElectronica { get; set; }

        [Required(ErrorMessage = "El campo DireccionLogo es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string DireccionLogo { get; set; }
    }
}
