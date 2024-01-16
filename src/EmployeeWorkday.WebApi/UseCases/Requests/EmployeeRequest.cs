using EmployeeWorkday.Domain.Entities.Workday;

namespace EmployeeWorkday.WebApi.UseCases.Requests;

internal class EmployeeRequest
{
    internal Guid Id { get; set; }
}

internal class CreateEmployeeRequest
{
    internal string Name { get; set; } 
    
    internal int EmployeeNumber { get; set; }

    internal List<WorkDay> WorkDays { get; set; } = new List<WorkDay>();
}

internal class UpdateEmployeeRequest
{
    internal string Name { get; set; } 
    
    internal int EmployeeNumber { get; set; }
    
    internal List<WorkDay> WorkDays { get; set; }
}

internal class DeleteEmployeeRequest
{
    internal Guid Id { get; set; }
}