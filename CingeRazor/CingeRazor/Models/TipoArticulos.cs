using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CingeRazor.Models
{
    public partial class TipoArticulos
    {
        public TipoArticulos()
        {
            Articulos = new HashSet<Articulos>();
        }
        [Required(ErrorMessage = "El campo TipoArticulo es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string TipoArticulo { get; set; }
        [Required(ErrorMessage = "El campo NombreTipo es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string NombreTipo { get; set; }

        public ICollection<Articulos> Articulos { get; set; }
    }
}
