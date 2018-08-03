using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CingeRazor.Models;

namespace CingeRazor.Pages.Factura
{
    public class IndexModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public IndexModel(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

        public IList<InventFactura> InventFactura { get;set; }

        public async Task OnGetAsync()
        {
            InventFactura = await _context.InventFactura
                .Include(i => i.ClienteNavigation)
                .Include(i => i.TipoIdentificacionNavigation).ToListAsync();
        }
    }
}
