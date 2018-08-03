using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CingeRazor.Models
{
    public partial class Zonas
    {
        public Zonas()
        {
            Clientes = new HashSet<Clientes>();
        }
        [Key]
        
        [Required(ErrorMessage = "El campo CódigoZona es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CódigoZona { get; set; }
        [Required(ErrorMessage = "El campo NombreZona es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string NombreZona { get; set; }

        public ICollection<Clientes> Clientes { get; set; }
    }
}
