using MediatR;

namespace EmployeeWorkday.Mediator.MediatR;

public class NotificationHandlerAdapter<TNotification> : INotificationHandler<NotificationAdapter<TNotification>>
{
    private readonly IEnumerable<IApplicationNotificationHandler<TNotification>> _myImpl;

    // injected by DI container
    public NotificationHandlerAdapter(IEnumerable<IApplicationNotificationHandler<TNotification>> impl)
    {
        _myImpl = impl ?? throw new ArgumentNullException(nameof(impl));
    }

    public Task Handle(NotificationAdapter<TNotification> notification, CancellationToken cancellationToken)
    {
        var tasks = _myImpl
            .Select(x => x.Handle(notification.Value, cancellationToken));
        return Task.WhenAll(tasks);
    }
}
