using MediatR;

namespace EmployeeWorkday.Mediator.MediatR;

public class NotificationAdapter<TNotification> : INotification
{
    public NotificationAdapter(TNotification value)
    {
        Value = value;
    }

    public TNotification Value {get;}
}