using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CingeRazor.Models
{
    public partial class Articulos
    {
        [Required(ErrorMessage = "El campo Código es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Código { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo TipoArticulo es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string TipoArticulo { get; set; }

        [Required(ErrorMessage = "El campo CódigoUnidad es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CódigoUnidad { get; set; }

        [Required(ErrorMessage = "El campo CostoPromedio es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public decimal CostoPromedio { get; set; }

        [Required(ErrorMessage = "El campo MargenUtilida es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public decimal MargenUtilida { get; set; }


        [Required(ErrorMessage = "El campo PrecioVenta es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]

        public decimal PrecioVenta { get; set; }

        [Required(ErrorMessage = "El campo PagaImpuesto es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public bool PagaImpuesto { get; set; }

        [Required(ErrorMessage = "El campo FechaCreacíon es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public DateTime FechaCreacíon { get; set; }

        public Medidas CódigoUnidadNavigation { get; set; }
        public TipoArticulos TipoArticuloNavigation { get; set; }







    }


}

