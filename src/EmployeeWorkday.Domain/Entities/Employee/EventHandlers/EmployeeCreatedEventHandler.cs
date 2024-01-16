using EmployeeWorkday.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EmployeeWorkday.Domain.Entities.Employee.EventHandlers;

public class EmployeeCreatedEventHandler(ILogger<EmployeeCreatedEventHandler> logger)
    : INotificationHandler<EmployeeCreatedEvent>
{
    public Task Handle(EmployeeCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
