using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCodeFirstEDM.Models
{
    public class Specialization
    {
        public Specialization()
        {
            Students = new HashSet<Student>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }

    }
}
