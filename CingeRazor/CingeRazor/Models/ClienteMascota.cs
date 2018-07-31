using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CingeRazor.Models
{
   
    public class ClienteMascota
    {
        public class ClientesIndexModel
        {
            public IEnumerable<Clientes> Clientes { get; set; }
            public IEnumerable<Mascotas> Mascotas { get; set; }

        }
        //public class InstructorIndexData
        //{
        //    public IEnumerable<Instructor> Instructors { get; set; }
        //    public IEnumerable<Course> Courses { get; set; }
        //    public IEnumerable<Enrollment> Enrollments { get; set; }
        //}




    }
    

}
