using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Studenten_Volg_Systeem.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public Lesson Lesson { get; set; }
        //public bool Present { get; set; }

        public AttendanceType AttendanceType { get;set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H-mm}")]
        public DateTime Time { get; set; }
    }
}

public enum AttendanceType
{
    Present,
    Afwezig_zonder_bericht,
    Afwezig_met_bericht,
    Ziek,
    Te_laat,
    Teams
}
