using DIDemo.DI;
using DIDemo.DIP;
using DIDemo.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new DIProgram().Run();
            new IOCProgram().Run();
            new DIPProgram().Run();
        }
    }
}
