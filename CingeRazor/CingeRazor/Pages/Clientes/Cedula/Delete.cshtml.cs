﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CingeRazor.Models;

namespace CingeRazor.Pages.Cedula
{
    public class DeleteModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public DeleteModel(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cedulas Cedulas { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cedulas = await _context.Cedulas.FirstOrDefaultAsync(m => m.CódigoCédula == id);

            if (Cedulas == null)
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

            Cedulas = await _context.Cedulas.FindAsync(id);

            if (Cedulas != null)
            {
                _context.Cedulas.Remove(Cedulas);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
