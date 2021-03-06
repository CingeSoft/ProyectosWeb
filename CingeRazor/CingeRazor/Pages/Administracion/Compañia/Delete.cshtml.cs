﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CingeRazor.Models;

namespace CingeRazor.Pages.Compañia
{
    public class DeleteModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public DeleteModel(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Compañias Compañias { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Compañias = await _context.Compañias.FirstOrDefaultAsync(m => m.IdCompañia == id);

            if (Compañias == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Compañias = await _context.Compañias.FindAsync(id);

            if (Compañias != null)
            {
                _context.Compañias.Remove(Compañias);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
