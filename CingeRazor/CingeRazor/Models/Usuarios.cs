using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace CingeRazor.Models
{
    public partial class Usuarios
    {
        private static readonly string SALT = "safnkjf0w320tnSN02TR2SAFQOasdaslfnal20";

        [Required(ErrorMessage = "El campo Usuario es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "El campo NombreUsuario es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "El campo Contraseñas es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Contraseñas { get; set; }

        [Required(ErrorMessage = "El campo IdRol es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string IdRol { get; set; }

        [Required(ErrorMessage = "El campo FechaCreacion es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public DateTime FechaCreacion { get; set; }

        [Required(ErrorMessage = "El campo UltimoLogeo es requerido")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public DateTime UltimoLogeo { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Email { get; set; }

        public Roles IdRolNavigation { get; set; }

        public static string EncriptarContrasena(string contrasena)
        {
            byte[] salt = System.Text.Encoding.ASCII.GetBytes(SALT);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(password: contrasena,
                                                                        salt: salt,
                                                                        prf: KeyDerivationPrf.HMACSHA1,
                                                                        iterationCount: 10000,
                                                                        numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}
