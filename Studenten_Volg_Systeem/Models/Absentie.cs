using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studenten_Volg_Systeem.Models
{
    public class Absentie
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public Lesson Lesson { get; set; }
        public bool Present { get; set; }
    }
}
