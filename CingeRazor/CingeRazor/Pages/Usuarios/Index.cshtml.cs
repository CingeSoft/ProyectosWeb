using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CingeRazor.Models;

namespace CingeRazor
{
    public class IndexModelUsuarios : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public IndexModelUsuarios(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

        public IList<Usuarios> Usuarios { get;set; }

        public async Task OnGetAsync()
        {
            Usuarios = await _context.Usuarios
                .Include(u => u.IdRolNavigation).ToListAsync();
        }
    }
}
