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

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Fax { get; set; }

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

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PaginaWeb { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string FacturaElectronica { get; set; }

        [DisplayName("Logo")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string DireccionLogo { get; set; }
    }
}
