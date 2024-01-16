using EmployeeWorkday.Domain.Events;
using EmployeeWorkday.Domain.Interfaces;
using MediatR;

namespace EmployeeWorkday.Domain.Entities.Workday.Commands.CreateWorkday;

public abstract record CreateWorkdayCommand(Employee.Employee Employee) : IRequest<Guid>
{
    public DateTime StartTime { get; init; }
    
    public DateTime EndTime { get; init; }
}

public class CreateWorkdayCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateWorkdayCommand, Guid>
{
    public async Task<Guid> Handle(CreateWorkdayCommand request, CancellationToken cancellationToken)
    {
        var entity = new WorkDay()
        {
            Employee = request.Employee,
            StartTime = request.StartTime,
            EndTime = request.EndTime
        };

        entity.AddDomainEvent(new WorkdayCreatedEvent(entity));

        context.Workdays.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
