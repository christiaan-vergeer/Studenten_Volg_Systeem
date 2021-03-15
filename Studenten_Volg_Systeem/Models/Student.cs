using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studenten_Volg_Systeem.Models
{
    public class Student // : identity User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Middelname { get; set; }
        public string Lastname { get; set; }
        public string Adress { get; set; }
        public Course Course { get; set; }
        public ICollection<Absentie> Absenties { get; set; }

    }
}
