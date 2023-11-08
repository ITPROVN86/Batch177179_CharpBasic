using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCodeFirstEDM.Models
{
    public class Teacher: Person
    {
        public Teacher()
        {
            Courses = new HashSet<Course>();
        }
        public string Qualification { get; set; } = "PhD";
        public string Position { get; set; } = "Prof.";
        public bool IsDean { get; set; } = false;
        [Required]
        public virtual Department Department { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

    }
}
