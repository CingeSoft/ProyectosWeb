using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CingeRazor.Models;
using CingeRazor.Pages.Mascota;


namespace CingeRazor.Pages.Cliente
{
    public class IndexModel : PageModel
    {
        private readonly CingeRazor.Models.CingeWebContext _context;

        public IndexModel(CingeRazor.Models.CingeWebContext context)
        {
            _context = context;
        }
        
        public ClienteMascotas Clientes { get; set; }
        public string ClienteCodigo { get; set; }

        public async Task OnGetAsync(string id)
        {
            Clientes = new ClienteMascotas();
            Clientes.Clientes = await _context.Clientes
                  .Include(c => c.CódigoCédulaNavigation)
                  .Include(c => c.CódigoZonaNavigation)
                  .Include(c => c.Mascotas)
                  .AsNoTracking()
                  .OrderBy(i => i.Código)
                  .ToListAsync();

            if (id != null)
            {
                ClienteCodigo = id;
                Models.Clientes clientes = Clientes.Clientes.Where(
                    i => i.Código == id).Single();
                Clientes.Mascotas = clientes.Mascotas.Where(x => x.Código == id);
            }
                 
        }
       


    }
}   
