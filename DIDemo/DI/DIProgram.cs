using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo.DI
{
    public class DIProgram
    {
        public void Run()
        {
            // Tạo và cấu hình DI container (ở đây sử dụng .NET Core DI)
            var serviceProvider = new ServiceCollection()
                .AddScoped<IMessageService, EmailService>()
                .AddScoped<NotificationService>()
                .BuildServiceProvider();

            // Giải phóng dịch vụ từ DI container
            using (var scope = serviceProvider.CreateScope())
            {
                // Lấy một thể hiện của NotificationService từ DI container
                var notificationService = scope.ServiceProvider.GetRequiredService<NotificationService>();

                // Sử dụng dịch vụ để gửi thông báo
                notificationService.NotifyUser("Hello, world!");
            }
        }
    }
}
