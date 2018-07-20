using System;
using System.Collections.Generic;

namespace CingeWeb.Models
{
    public partial class Medidas
    {
        public Medidas()
        {
            Articulos = new HashSet<Articulos>();
        }

        public string CódigoUnidad { get; set; }
        public string NombreUnidad { get; set; }

        public ICollection<Articulos> Articulos { get; set; }
    }
}
