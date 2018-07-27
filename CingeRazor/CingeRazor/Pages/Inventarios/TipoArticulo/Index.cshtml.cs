using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CingeRazor.Models;

namespace CingeRazor.Pages.TipoArticulo
{
    public class IndexModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public IndexModel(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

        public IList<TipoArticulos> TipoArticulos { get;set; }

        public async Task OnGetAsync()
        {
            TipoArticulos = await _context.TipoArticulos.ToListAsync();
        }
    }
}
