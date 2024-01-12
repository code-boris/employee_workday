namespace EmployeeWorkday.Domain.Model;

/// <summary>
/// Рабочий день сотрудника
/// </summary>
public class WorkDay
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Сотрудник
    /// </summary>
    public Employee Employee { get; set; }
    
    /// <summary>
    /// Момент начала работы
    /// </summary>
    public DateTime StartTime { get; set; }
    
    /// <summary>
    /// Момент окончания работы
    /// </summary>
    public DateTime EndTime { get; set; }
}