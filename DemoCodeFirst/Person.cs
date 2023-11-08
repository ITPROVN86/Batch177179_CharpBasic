using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCodeFirst
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Email> Emails { get; set;}
        public ICollection<Company> Companies { get; set;}
        public virtual Contact Contact { get; set; }
    }
}
