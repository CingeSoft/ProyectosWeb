using System;
using System.Collections.Generic;

namespace CingeWeb.Models
{
    public partial class Articulos
    {
        public string Código { get; set; }
        public string Nombre { get; set; }
        public string TipoArticulo { get; set; }
        public string CódigoUnidad { get; set; }
        public decimal CostoPromedio { get; set; }
        public decimal MargenUtilida { get; set; }
        public decimal PrecioVenta { get; set; }
        public bool PagaImpuesto { get; set; }
        public DateTime FechaCreacíon { get; set; }

        public Medidas CódigoUnidadNavigation { get; set; }
        public TipoArticulos TipoArticuloNavigation { get; set; }
    }
}
