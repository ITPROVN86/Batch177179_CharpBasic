using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCodeFirstEDM.Models
{
    public class Student:Person
    {
      /*  public Student()
        {
            Courses = new HashSet<Course>();
        }*/
        public string Group { get; set; }
       /* [ForeignKey(nameof(Courses))]
        public int CourseID { get; set; }*/
        public virtual Specialization Specialization { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

    }
}
