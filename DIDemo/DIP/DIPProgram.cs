using DIDemo.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo.DIP
{
    public class DIPProgram
    {
        public void Run()
        {
            // Sử dụng EmailService
            var emailService = new EmailService();
            var notificationWithEmail = new NotificationService(emailService);
            notificationWithEmail.NotifyUser("Hello, email!");

            // Sử dụng SMSService
            var smsService = new SMSService();
            var notificationWithSMS = new NotificationService(smsService);
            notificationWithSMS.NotifyUser("Hello, SMS!");
            Console.Read();
        }
    }
}
