using FluentValidation;

namespace EmployeeWorkday.Domain.Entities.Workday.Commands.CreateWorkday;

public class CreateWorkdayCommandValidator : AbstractValidator<CreateWorkdayCommand>
{
    public CreateWorkdayCommandValidator()
    {
        RuleFor(v => v.Employee)
            .NotEmpty();
        
        RuleFor(v => v.StartTime)
            .NotEmpty();
        
        RuleFor(v => v.EndTime)
            .NotEmpty();
    }
}
