using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCodeFirstEDM.Models
{
    public class School
    {
        public School()
        {
            this.Departments = new HashSet<Department>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Department> Departments { get; set; }

    }
}
