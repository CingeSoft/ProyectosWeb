using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CingeRazor.Models;

namespace CingeRazor.Pages.Clientes.Mascota
{
    public class ListaMascotaModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public ListaMascotaModel(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }
        

        public class MascotaSeleccionado
        {
            public string Nombre { get; set; }
            public decimal Peso { get; set; }
            public string Sexo { get; set; }
            public decimal Edad { get; set; }
            public string Especie { get; set; }
            public string Código { get; set; }

        }

        public JsonResult OnGet(string idMascota)
        {
            Mascotas Mascotas = _context.Mascotas
              .Include(m => m.CódigoNavigation).FirstOrDefault(m => m.Código == idMascota);

           
            MascotaSeleccionado seleccionado = new MascotaSeleccionado();

            seleccionado.Nombre = Mascotas.Nombre;
            seleccionado.Peso = Mascotas.Peso;
            seleccionado.Sexo = Mascotas.Sexo;
            seleccionado.Edad = Mascotas.Edad;
            seleccionado.Especie = Mascotas.Especie;
            seleccionado.Código = Mascotas.Código;

            JsonResult resultado = new JsonResult(seleccionado);

            return resultado;

        }
    }
}