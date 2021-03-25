using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Studenten_Volg_Systeem.Models;

namespace Studenten_Volg_Systeem.ViewModels
{
    public class LessonListItem
    {
       public int Id { get; set; }
       [DataType(DataType.Date)]
       [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Date { get; set; }
       public DayOfWeek Day { get; set; }
       public int Week { get; set; }
    }
}
