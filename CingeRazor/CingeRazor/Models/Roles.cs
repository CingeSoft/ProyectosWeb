using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CingeRazor.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Usuarios = new HashSet<Usuarios>();
        }
        [Required(ErrorMessage = "El campo IdRol es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]

        public string IdRol { get; set; }
        [Required(ErrorMessage = "El campo NombreRol es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string NombreRol { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
