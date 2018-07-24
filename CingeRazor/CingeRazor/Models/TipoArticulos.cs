using System;
using System.Collections.Generic;

namespace CingeRazor.Models
{
    public partial class TipoArticulos
    {
        public TipoArticulos()
        {
            Articulos = new HashSet<Articulos>();
        }

        public string TipoArticulo { get; set; }
        public string NombreTipo { get; set; }

        public ICollection<Articulos> Articulos { get; set; }
    }
}
