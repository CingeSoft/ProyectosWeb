using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CingeRazor.Models;

namespace CingeRazor.Pages.Cliente
{
    public class IndexModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public IndexModel(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

        public IList<Models.Clientes> Clientes { get;set; }

        public async Task OnGetAsync()
        {
            Clientes = await _context.Clientes
                .Include(c => c.CódigoCédulaNavigation)
                .Include(c => c.CódigoZonaNavigation).ToListAsync();


           

        }
    }
}   
