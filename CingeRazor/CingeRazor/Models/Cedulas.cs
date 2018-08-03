using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CingeRazor.Models
{
    public partial class Cedulas
    {
        public Cedulas()
        {
            Clientes = new HashSet<Clientes>();
            InventFactura = new HashSet<InventFactura>();
        }
        [Required(ErrorMessage = "El campo CódigoCédula es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CódigoCédula { get; set; }
        [Required(ErrorMessage = "El campo Cédula es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Cédula { get; set; }

        public ICollection<Clientes> Clientes { get; set; }
        public ICollection<InventFactura> InventFactura { get; set; }
    }
}
