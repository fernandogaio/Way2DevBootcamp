using MediatR;
using Way2DevBootcamp.Application.Core.Notifications;

namespace Way2DevBootcamp.Application.Core.NotificationHandlers;
public class ErrorNotificationHandler : INotificationHandler<ErrorNotification> {
    public Task Handle(ErrorNotification notification, CancellationToken cancellationToken) {
        return Task.Run(() => {
            Console.WriteLine("ERRO (s):");
            foreach (var error in notification.Errors)
                Console.WriteLine($"-- {error}");
        }, cancellationToken);
    }
}