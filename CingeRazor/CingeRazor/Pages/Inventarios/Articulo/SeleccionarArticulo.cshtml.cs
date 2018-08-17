using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CingeRazor.Models;

namespace CingeRazor.Pages.Inventarios.Articulo
{
    public class SeleccionarArticuloModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;
      
        public SeleccionarArticuloModel(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

        public class ArticuloSeleccionado
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
        }

        public JsonResult OnGet(string idProducto)
        {
            Articulos Articulos = _context.Articulos
                .Include(a => a.CódigoUnidadNavigation)
                .Include(a => a.TipoArticuloNavigation).FirstOrDefault(m => m.Código == idProducto);

            ArticuloSeleccionado seleccionado = new ArticuloSeleccionado();
             if (Articulos != null)
             {
                seleccionado.Código = Articulos.Código;
            seleccionado.Nombre = Articulos.Nombre;
            seleccionado.TipoArticulo = Articulos.TipoArticulo;
            seleccionado.CódigoUnidad = Articulos.CódigoUnidad;
            seleccionado.CostoPromedio = Articulos.CostoPromedio;
            seleccionado.MargenUtilida = Articulos.MargenUtilida;
            seleccionado.PrecioVenta = Articulos.PrecioVenta;
            seleccionado.PagaImpuesto = Articulos.PagaImpuesto;
            seleccionado.FechaCreacíon = Articulos.FechaCreacíon;

             }

            JsonResult resultado = new JsonResult(seleccionado);

            return resultado;
            
        }
    }
}