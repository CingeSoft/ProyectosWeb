using System;
using System.Collections.Generic;

namespace CingeWeb.Models
{
    public partial class Zonas
    {
        public Zonas()
        {
            Clientes = new HashSet<Clientes>();
        }

        public string CódigoZona { get; set; }
        public string NombreZona { get; set; }

        public ICollection<Clientes> Clientes { get; set; }
    }
}
