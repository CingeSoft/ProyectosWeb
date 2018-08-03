using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CingeRazor.Models
{
    public partial class Mascotas
    {
        public Mascotas()
        {
            InventFacturaMascota = new HashSet<InventFacturaMascota>();
        }
        //[Required(ErrorMessage = "El campo CódigoMascota es requerido")]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        //public string CódigoMascota { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Peso es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public decimal Peso { get; set; }

        [Required(ErrorMessage = "El campo Sexo es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "El campo Edad es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public decimal Edad { get; set; }

        [Required(ErrorMessage = "El campo Especie es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Especie { get; set; }

        [Required(ErrorMessage = "El campo Código es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Código { get; set; }

        public Clientes CódigoNavigation { get; set; }
        public ICollection<InventFacturaMascota> InventFacturaMascota { get; set; }
    }
}
