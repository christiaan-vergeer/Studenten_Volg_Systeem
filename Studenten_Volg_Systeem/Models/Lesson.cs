using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Studenten_Volg_Systeem.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public Course Course { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }
        public ICollection<Attendance> Attendances { get; set; }

    }
}
