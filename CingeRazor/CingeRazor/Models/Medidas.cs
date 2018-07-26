using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CingeRazor.Models
{
    public partial class Medidas
    {
        public Medidas()
        {
            Articulos = new HashSet<Articulos>();
        }
        [Required(ErrorMessage = "El campo CódigoUnidad es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CódigoUnidad { get; set; }
        [Required(ErrorMessage = "El campo NombreUnidad es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string NombreUnidad { get; set; }

        public ICollection<Articulos> Articulos { get; set; }
    }
}
