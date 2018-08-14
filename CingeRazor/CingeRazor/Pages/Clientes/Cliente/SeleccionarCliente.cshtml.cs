using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CingeRazor.Models;

namespace CingeRazor.Pages.Clientes.Cliente
{
    public class SeleccionarClienteModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public SeleccionarClienteModel(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

        public class ClienteSeleccionado
        {
            public string Código { get; set; }
            public string Nombre { get; set; }
            public string Localidad { get; set; }
            public string CódigoCédula { get; set; }
            public string Cédula { get; set; }
            public string TelefonoCodigoArea { get; set; }
            public string Teléfono { get; set; }
            public string Dirección { get; set; }
            public string Email { get; set; }
            public DateTime FechaCreacíon { get; set; }
            public string CódigoZona { get; set; }

        }

        public JsonResult OnGet(string idCliente)
        {
            Models.Clientes Clientes = _context.Clientes
                .Include(c => c.CódigoCédulaNavigation)
                .Include(c => c.CódigoZonaNavigation).FirstOrDefault(m => m.Código == idCliente);

            ClienteSeleccionado seleccionado = new ClienteSeleccionado();

            seleccionado.Código = Clientes.Código;
            seleccionado.Nombre = Clientes.Nombre;
            seleccionado.Localidad = Clientes.Localidad;
            seleccionado.CódigoCédula = Clientes.CódigoCédula;
            seleccionado.Cédula = Clientes.Cédula;
            seleccionado.TelefonoCodigoArea = Clientes.TelefonoCodigoArea;
            seleccionado.Teléfono = Clientes.Teléfono;
            seleccionado.Dirección = Clientes.Dirección;
            seleccionado.Email = Clientes.Email;
            seleccionado.FechaCreacíon = Clientes.FechaCreacíon;
            seleccionado.CódigoZona = Clientes.CódigoZona;

            JsonResult resultado = new JsonResult(seleccionado);

            return resultado;
        }
    }
}