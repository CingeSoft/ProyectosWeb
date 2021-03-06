﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CingeRazor.Models;

namespace CingeRazor.Pages.Mascota
{
    public class IndexModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public IndexModel(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

        public IList<Mascotas> Mascotas { get;set; }

        public async Task OnGetAsync()
        {
            Mascotas = await _context.Mascotas
                .Include(m => m.CódigoNavigation).ToListAsync();
        }
    }
}
