using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CingeRazor.Models
{
    public partial class Clientes
    {
        public Clientes()
        {
            InventFactura = new HashSet<InventFactura>();
            Mascotas = new HashSet<Mascotas>();
        }
        [Required(ErrorMessage = "El campo Código es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Código { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Localidad es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Localidad { get; set; }

        [Required(ErrorMessage = "El campo CódigoCédula es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CódigoCédula { get; set; }

        [Required(ErrorMessage = "El campo Cédula es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Cédula { get; set; }

        [Required(ErrorMessage = "El campo TelefonoCodigoArea es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string TelefonoCodigoArea { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Teléfono { get; set; }

        [Required(ErrorMessage = "El campo Dirección es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Dirección { get; set; }

        [Required(ErrorMessage = "El campo Email es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo FechaCreacíon es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public DateTime FechaCreacíon { get; set; }

        [Required(ErrorMessage = "El campo CódigoZona es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CódigoZona { get; set; }

        public Cedulas CódigoCédulaNavigation { get; set; }
        public Zonas CódigoZonaNavigation { get; set; }
        public ICollection<Mascotas> Mascotas { get; set; }
        public ICollection<InventFactura> InventFactura { get; set; }
    }
}
