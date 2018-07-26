using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CingeRazor.Models
{
    public partial class Usuarios
    {
        [Required(ErrorMessage = "El campo Usuario es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "El campo NombreUsuario es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "El campo Contraseñas es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Contraseñas { get; set; }
        public string ContraseñaSalt { get; set; }

        [Required(ErrorMessage = "El campo IdRol es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string IdRol { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = ("MM/dd/yyyy hh:mm tt"))]
        public DateTime FechaCreacion 
        {
        get
        {
        return DateTime.Now ;
        }

        set
        {
                
        }
        }
        public string ReturnDateForDisplay
        {
            get
            {
                return this.FechaCreacion.ToString("d");
            }
        }

        [Required(ErrorMessage = "El campo UltimoLogeo es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public DateTime UltimoLogeo { get; set; }

        [Required(ErrorMessage = "El campo Email es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Email { get; set; }

        public Roles IdRolNavigation { get; set; }
    }
}
