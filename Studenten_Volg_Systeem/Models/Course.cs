using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studenten_Volg_Systeem.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } //andere invulling (opleidingsnaam)
        public virtual ICollection<Proffesor> Proffesors { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }

    }
}
