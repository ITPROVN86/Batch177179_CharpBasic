using Autofac;
using DIDemo.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo.IOC
{
    public class IOCProgram
    {
        public void Run()
        {
            // Tạo và cấu hình container Autofac
            var builder = new ContainerBuilder();
            builder.RegisterType<EmailService>().As<IMessageService>();
            builder.RegisterType<NotificationService>();
            var container = builder.Build();

            // Giải phóng dịch vụ từ container
            using (var scope = container.BeginLifetimeScope())
            {
                // Lấy một thể hiện của NotificationService từ container
                var notificationService = scope.Resolve<NotificationService>();

                // Sử dụng dịch vụ để gửi thông báo
                notificationService.NotifyUser("Hello, world!");
            }
        }
    }
}
