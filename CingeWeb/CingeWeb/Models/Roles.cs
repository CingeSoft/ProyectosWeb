using System;
using System.Collections.Generic;

namespace CingeWeb.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public string IdRol { get; set; }
        public string NombreRol { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
