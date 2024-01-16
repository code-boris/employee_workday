using FluentValidation;

namespace EmployeeWorkday.Domain.Entities.Workday.Commands.UpdateWorkday;

public class UpdateWorkdayCommandValidator : AbstractValidator<UpdateWorkdayCommand>
{
    public UpdateWorkdayCommandValidator()
    {
        RuleFor(v => v.Employee)
            .NotEmpty();
        
        RuleFor(v => v.StartTime)
            .NotEmpty();
        
        RuleFor(v => v.EndTime)
            .NotEmpty();
    }
}
