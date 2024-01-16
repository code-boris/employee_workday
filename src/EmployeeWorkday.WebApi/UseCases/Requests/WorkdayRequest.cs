using EmployeeWorkday.Domain.Entities.Employee;

namespace EmployeeWorkday.WebApi.UseCases.Requests;

internal class WorkdayRequest
{
    internal Guid Id { get; set; }
}

internal class CreateWorkdayRequest
{
    internal Employee Employee { get; set; }
    internal DateTime StartTime { get; set; }
    internal DateTime EndTime { get; set; }
}

internal class UpdateWorkdayRequest
{
    internal Employee Employee { get; set; }
    internal DateTime StartTime { get; set; }
    internal DateTime EndTime { get; set; }
}

internal class DeleteWorkdayRequest
{
    internal Guid Id { get; set; }
}
