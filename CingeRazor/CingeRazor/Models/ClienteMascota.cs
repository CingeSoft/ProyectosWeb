using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CingeRazor.Models
{
   
    public class ClienteMascota
    {
        public class ClientesViewModel
        {
            public int CódigoMascota { get; set; }
            public string Nombre { get; set; }
            public int Peso { get; set; }
            public string Sexo { get; set; }
            public int Edad { get; set; }
            public string Especie { get; set; }
            public Clientes Código { get; set; }

        }
        public IList<ClientesViewModel> ClientesVM { get; set; }

        //public async Task OnGetAsync()
        //{
        //    ClientesVM = await _context.Clientes
        //            .Select(p => new ClientesViewModel
        //            {
        //                CódigoMascota = p.CourseID,
        //                Nombre = p.Nombre,
        //                Peso = p.Peso,
        //                Sexo = p.Department.Name
        //            }).ToListAsync();
        //}


    }
    

}
