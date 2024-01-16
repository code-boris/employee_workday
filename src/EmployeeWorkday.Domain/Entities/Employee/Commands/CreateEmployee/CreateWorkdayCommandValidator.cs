using FluentValidation;

namespace EmployeeWorkday.Domain.Entities.Employee.Commands.CreateEmployee;

public class CreateWorkdayCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateWorkdayCommandValidator()
    {
        RuleFor(v => v.Name)
            .NotEmpty();
    }
}
