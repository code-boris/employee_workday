using FluentValidation;

namespace EmployeeWorkday.Domain.Entities.Employee.Commands.UpdateEmployee;

public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(v => v.Name)
            .NotEmpty();
    }
}
