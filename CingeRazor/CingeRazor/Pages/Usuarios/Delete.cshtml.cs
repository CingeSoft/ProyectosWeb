﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CingeRazor.Models;

namespace CingeRazor
{
    public class DeleteModelUsuarios : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public DeleteModelUsuarios(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Usuarios Usuarios { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Usuarios = await _context.Usuarios
                .Include(u => u.IdRolNavigation).FirstOrDefaultAsync(m => m.Usuario == id);

            if (Usuarios == null)
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

            Usuarios = await _context.Usuarios.FindAsync(id);

            if (Usuarios != null)
            {
                _context.Usuarios.Remove(Usuarios);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
