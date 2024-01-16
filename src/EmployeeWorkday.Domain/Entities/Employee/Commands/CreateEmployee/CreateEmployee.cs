using EmployeeWorkday.Domain.Events;
using EmployeeWorkday.Domain.Interfaces;
using MediatR;

namespace EmployeeWorkday.Domain.Entities.Employee.Commands.CreateEmployee;

public abstract record CreateEmployeeCommand(string Name, int EmployeeNumber) : IRequest<Guid>
{
    public string Name { get; init; } = Name;

    public int EmployeeNumber { get; init; } = EmployeeNumber;
}

public class CreateEmployeeCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateEmployeeCommand, Guid>
{
    public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = new Employee(request.Name);

        entity.AddDomainEvent(new EmployeeCreatedEvent(entity));

        context.Employees.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
