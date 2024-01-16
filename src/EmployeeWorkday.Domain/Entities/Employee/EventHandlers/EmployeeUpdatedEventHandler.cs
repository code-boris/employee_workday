using EmployeeWorkday.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EmployeeWorkday.Domain.Entities.Employee.EventHandlers;

public class EmployeeUpdatedEventHandler(ILogger<EmployeeUpdatedEventHandler> logger)
    : INotificationHandler<EmployeeUpdatedEvent>
{
    public Task Handle(EmployeeUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}