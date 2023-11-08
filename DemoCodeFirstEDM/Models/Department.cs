using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCodeFirstEDM.Models
{
    public class Department
    {
        public Department()
        {
            this.Teachers = new HashSet<Teacher>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Office { get; set; }
        [Required]
        public virtual School School { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }

    }
}
