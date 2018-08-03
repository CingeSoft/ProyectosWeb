using System;
using System.Collections.Generic;

namespace CingeWeb.Models
{
    public partial class Mascotas
    {
        public Mascotas()
        {
            InventFacturaMascota = new HashSet<InventFacturaMascota>();
        }

        public string Nombre { get; set; }
        public decimal Peso { get; set; }
        public string Sexo { get; set; }
        public decimal Edad { get; set; }
        public string Especie { get; set; }
        public string Código { get; set; }

        public Clientes CódigoNavigation { get; set; }
        public ICollection<InventFacturaMascota> InventFacturaMascota { get; set; }
    }
}
