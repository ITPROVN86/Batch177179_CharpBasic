using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCodeFirst
{
    public class Email
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
