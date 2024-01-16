using Ardalis.GuardClauses;
using EmployeeWorkday.Domain.Interfaces;
using MediatR;

namespace EmployeeWorkday.Domain.Entities.Workday.Commands.UpdateWorkday;

public abstract record UpdateWorkdayCommand(Employee.Employee Employee) : IRequest
{
    public Guid Id { get; set; }

    public Employee.Employee Employee { get; set; } = Employee;

    public DateTime StartTime { get; set; }
    
    public DateTime EndTime { get; set; }
}

public class UpdateWorkdayCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateWorkdayCommand>
{
    public async Task Handle(UpdateWorkdayCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Workdays
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.StartTime = request.StartTime;
        entity.EndTime = request.EndTime;

        await context.SaveChangesAsync(cancellationToken);
    }
}
