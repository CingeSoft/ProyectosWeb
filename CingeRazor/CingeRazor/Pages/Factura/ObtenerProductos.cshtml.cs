using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CingeRazor.Pages.Factura
{
    public class ObtenerProductosModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public ObtenerProductosModel(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }
        public PaginatedList<Models.Articulos> Articulos { get; set; }
        public string CodigoBusqueda { get; set; }
        public string NombreBusqueda { get; set; }
        public string PrecioVentaBusqueda { get; set; }
        public string CodigoSort { get; set; }
        public string NombreSort { get; set; }
        public string ActualSort { get; set; }

        public async Task OnGetAsync(
           string ordenSort,
           string codigoActual,
           string nombreActual,
           string codigoBusqueda,
           string nombreBusqueda,
           string precioventaBusqueda,
           int? pageIndex)
        {
            ActualSort = ordenSort;

            CodigoSort = String.IsNullOrEmpty(ordenSort) || ordenSort == "Codigo" ? "codigo_desc" : "Codigo";
            NombreSort = ordenSort == "Nombre" ? "nombre_desc" : "Nombre";
            if (codigoBusqueda != null ||
               nombreBusqueda != null)

                    
            {
                pageIndex = 1;
            }
            else
            {
                if (codigoBusqueda == null)
                    codigoBusqueda = codigoActual;
                if (nombreBusqueda == null)
                    nombreBusqueda = nombreActual;
                
            }
            CodigoBusqueda = codigoBusqueda;
            NombreBusqueda = nombreBusqueda;
            //PrecioVentaBusqueda = precioventabusqueda;

            //IQueryable <Models.Articulos> ListaProductos = from s in _context.Articulos
            //                                        select s;
            //if (!String.IsNullOrEmpty(PrecioVentaBusqueda))
            //    ListaProductos = ListaProductos.Where(s => s.PrecioVenta.StartsWith(precioventabusqueda));
            //if (!String.IsNullOrEmpty(nombreBusqueda))
            //    ListaProductos = ListaProductos.Where(s => s.Nombre.Contains(nombreBusqueda));
            



            IQueryable<Models.Articulos> articulo = from s in _context.Articulos
                                                  select s;
            if (!String.IsNullOrEmpty(codigoBusqueda))
                articulo = articulo.Where(s => s.Código.StartsWith(codigoBusqueda));
            if (!String.IsNullOrEmpty(nombreBusqueda))
                articulo = articulo.Where(s => s.Nombre.Contains(nombreBusqueda));
            switch (ordenSort)
            {
                case "codigo_desc":
                    articulo = articulo.OrderByDescending(s => s.Código);
                    break;
                case "Nombre":
                    articulo = articulo.OrderBy(s => s.Nombre);
                    break;
                case "nombre_desc":
                    articulo = articulo.OrderByDescending(s => s.Nombre);
                    break;
               
            }

            int pageSize = 5;
            Articulos = await PaginatedList<Models.Articulos>.CreateAsync(articulo.AsNoTracking(), pageIndex ?? 1, pageSize);

        }
}
}