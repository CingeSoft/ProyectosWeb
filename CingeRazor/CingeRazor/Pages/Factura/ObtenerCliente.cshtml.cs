using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CingeRazor.Pages.Factura
{

    public class ObtenerClienteModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public ObtenerClienteModel(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

        public PaginatedList<Models.Clientes> Clientes { get; set; }
        public string CodigoBusqueda { get; set; }
        public string NombreBusqueda { get; set; }
        public string CedulaBusqueda { get; set; }
        public string TelefonoBusqueda { get; set; }
        public string NombreSort { get; set; }
        public string CodigoSort { get; set; }
        public string CedulaSort { get; set; }
        public string TelefonoSort { get; set; }
        public string ActualSort { get; set; }

        public async Task OnGetAsync(
            string ordenSort,
            string codigoActual,
            string nombreActual,
            string cedulaActual,
            string telefonoActual, 
            string codigoBusqueda, 
            string nombreBusqueda, 
            string cedulaBusqueda, 
            string telefonoBusqueda, 
            int? pageIndex)
        {
            ActualSort = ordenSort;

            CodigoSort = String.IsNullOrEmpty(ordenSort) || ordenSort == "Codigo" ? "codigo_desc" : "Codigo";
            NombreSort = ordenSort == "Nombre" ? "nombre_desc" : "Nombre";
            TelefonoSort = ordenSort == "Telefono" ? "telefono_desc" : "Telefono";
            CedulaSort = ordenSort == "Cedula" ? "cedula_desc" : "Cedula";

            if (codigoBusqueda != null ||
                nombreBusqueda != null ||
                cedulaBusqueda != null ||
                telefonoBusqueda != null)
            {
                pageIndex = 1;
            }
            else
            {
                if (codigoBusqueda == null)
                    codigoBusqueda = codigoActual;
                if (nombreBusqueda == null)
                    nombreBusqueda = nombreActual;
                if (cedulaBusqueda == null)
                    cedulaBusqueda = cedulaActual;
                if (telefonoBusqueda == null)
                    telefonoBusqueda = telefonoActual;
            }

            CodigoBusqueda = codigoBusqueda;
            NombreBusqueda = nombreBusqueda;
            CedulaBusqueda = cedulaBusqueda;
            TelefonoBusqueda = telefonoBusqueda;

            IQueryable<Models.Clientes> cliente = from s in _context.Clientes
                                                    select s;

            if (!String.IsNullOrEmpty(codigoBusqueda))
                cliente = cliente.Where(s => s.Código.StartsWith(codigoBusqueda));
            if (!String.IsNullOrEmpty(nombreBusqueda))
                cliente = cliente.Where(s => s.Nombre.Contains(nombreBusqueda));
            if (!String.IsNullOrEmpty(cedulaBusqueda))
                cliente = cliente.Where(s => s.Cédula.Contains(cedulaBusqueda));
            if (!String.IsNullOrEmpty(telefonoBusqueda))
                cliente = cliente.Where(s => s.Teléfono.Contains(telefonoBusqueda));

            switch (ordenSort)
            {
                case "codigo_desc":
                    cliente = cliente.OrderByDescending(s => s.Código);
                    break;
                case "Nombre":
                    cliente = cliente.OrderBy(s => s.Nombre);
                    break;
                case "nombre_desc":
                    cliente = cliente.OrderByDescending(s => s.Nombre);
                    break;
                case "Telefono":
                    cliente = cliente.OrderBy(s => s.Teléfono);
                    break;
                case "telefono_desc":
                    cliente = cliente.OrderByDescending(s => s.Teléfono);
                    break;
                case "Cedula":
                    cliente = cliente.OrderBy(s => s.Cédula);
                    break;
                case "cedula_desc":
                    cliente = cliente.OrderByDescending(s => s.Cédula);
                    break;
                default:
                    cliente = cliente.OrderBy(s => s.Código);
                    break;
            }

            int pageSize = 5;
            Clientes = await PaginatedList<Models.Clientes>.CreateAsync(cliente.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }

}