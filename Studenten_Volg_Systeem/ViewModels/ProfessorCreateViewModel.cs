using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Studenten_Volg_Systeem.Models;

namespace Studenten_Volg_Systeem.ViewModels
{
    public class ProfessorCreateViewModel
    {
        public Proffesor Proffesor { get; set; }
        public List<Course> Courses { get; set; }
        public int CourseID { get; set; }
    }
}
