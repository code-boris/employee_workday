using FluentValidation;

namespace EmployeeWorkday.Domain.Entities.Employee.Queries.GetEmployeesWithPagination;

public class GetEmployeesWithPaginationQueryValidator : AbstractValidator<GetEmployeesWithPaginationQuery>
{
    public GetEmployeesWithPaginationQueryValidator()
    {
        RuleFor(x => x.EmployeeId)
            .NotEmpty().WithMessage("EmployeeId is required.");

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}
