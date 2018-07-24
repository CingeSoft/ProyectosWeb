using System;
using System.Collections.Generic;

namespace CingeRazor.Models
{
    public partial class Mascotas
    {
        public string CódigoMascota { get; set; }
        public string Nombre { get; set; }
        public decimal Peso { get; set; }
        public string Sexo { get; set; }
        public decimal Edad { get; set; }
        public string Especie { get; set; }
        public string Código { get; set; }

        public Clientes CódigoNavigation { get; set; }
    }
}
