using Ardalis.GuardClauses;
using EmployeeWorkday.Domain.Interfaces;
using MediatR;

namespace EmployeeWorkday.Domain.Entities.Employee.Commands.UpdateEmployee;

public abstract record UpdateEmployeeCommand(string Name, int EmployeeNumber) : IRequest
{
    public Guid Id { get; set; }

    public string Name { get; set; } = Name;
    
    public int EmployeeNumber { get; set; } = EmployeeNumber;
}

public class UpdateEmployeeCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateEmployeeCommand>
{
    public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = await context
            .Employees
            .FindAsync([request.EmployeeNumber], cancellationToken);

        Guard.Against.NotFound(request.EmployeeNumber, entity);

        entity.Name = request.Name;
        entity.EmployeeNumber = request.EmployeeNumber;
        
        await context.SaveChangesAsync(cancellationToken);
    }
}
