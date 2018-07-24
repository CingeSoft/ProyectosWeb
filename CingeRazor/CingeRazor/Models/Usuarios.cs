using System;
using System.Collections.Generic;

namespace CingeRazor.Models
{
    public partial class Usuarios
    {
        public string Usuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseñas { get; set; }
        public string IdRol { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime UltimoLogeo { get; set; }
        public string Email { get; set; }

        public Roles IdRolNavigation { get; set; }
    }
}
