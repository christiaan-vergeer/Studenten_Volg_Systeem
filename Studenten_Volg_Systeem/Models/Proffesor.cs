using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studenten_Volg_Systeem.Models
{
    public class Proffesor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
