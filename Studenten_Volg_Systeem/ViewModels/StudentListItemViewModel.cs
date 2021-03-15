using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Studenten_Volg_Systeem.Models;

namespace Studenten_Volg_Systeem.ViewModels
{
    public class StudentListItemViewModel
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Course { get; set; }



        //public Student Student { get; set; }
        //public List<Course> Courses { get; set; }
        //public string CourseId { get; set; }
    }
}
