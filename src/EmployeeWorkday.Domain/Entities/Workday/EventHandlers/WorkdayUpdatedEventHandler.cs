using EmployeeWorkday.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EmployeeWorkday.Domain.Entities.Workday.EventHandlers;

public class WorkdayUpdatedEventHandler(ILogger<WorkdayUpdatedEventHandler> logger)
    : INotificationHandler<WorkdayUpdatedEvent>
{
    public Task Handle(WorkdayUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}