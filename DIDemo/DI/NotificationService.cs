using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo.DI
{
    // Sử dụng dịch vụ thông qua DI
    public class NotificationService
    {
        private readonly IMessageService _messageService;

        // Constructor nhận IMessageService thông qua DI
        public NotificationService(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public void NotifyUser(string message)
        {
            _messageService.SendMessage(message);
        }
    }
}
