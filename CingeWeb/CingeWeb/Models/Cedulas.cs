using System;
using System.Collections.Generic;

namespace CingeWeb.Models
{
    public partial class Cedulas
    {
        public Cedulas()
        {
            Clientes = new HashSet<Clientes>();
        }

        public string CódigoCédula { get; set; }
        public string Cédula { get; set; }

        public ICollection<Clientes> Clientes { get; set; }
    }
}
