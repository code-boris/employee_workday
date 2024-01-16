using EmployeeWorkday.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EmployeeWorkday.Domain.Entities.Workday.EventHandlers;

public class WorkdayCreatedEventHandler(ILogger<WorkdayCreatedEventHandler> logger)
    : INotificationHandler<WorkdayCreatedEvent>
{
    public Task Handle(WorkdayCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
