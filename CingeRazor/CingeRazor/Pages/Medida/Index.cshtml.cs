﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CingeRazor.Models;

namespace CingeRazor.Pages.Medida
{
    public class IndexModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public IndexModel(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

        public IList<Medidas> Medidas { get;set; }

        public async Task OnGetAsync()
        {
            Medidas = await _context.Medidas.ToListAsync();
        }
    }
}
