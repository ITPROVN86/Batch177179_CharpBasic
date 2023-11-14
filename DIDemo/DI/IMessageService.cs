using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo.DI
{
    // Interface định nghĩa dịch vụ
    public interface IMessageService
    {
        void SendMessage(string message);
    }
}
