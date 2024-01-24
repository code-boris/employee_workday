using EmployeeWorkday.Domain.Common;

namespace EmployeeWorkday.Domain.Entities.Workday;

/// <summary>
/// Рабочий день сотрудника
/// </summary>
public class WorkDay : BaseAuditableEntity
{
    public Guid EmployeeId { get; set; }
    
    public Employee.Employee Employee { get; set; }

    /// <summary>
    /// Момент начала работы
    /// </summary>
    public DateTime StartTime { get; set; }
    
    /// <summary>
    /// Момент окончания работы
    /// </summary>
    public DateTime EndTime { get; set; }
}