using EmployeeWorkday.Domain.Entities.Workday;
using EmployeeWorkday.Mediator;
using EmployeeWorkday.WebApi.UseCases.Requests;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWorkday.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkdayController(IApplicationMediator mediator) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllWorkdays()
    {
        var workdays = mediator.Send<WorkdayRequest, IReadOnlyCollection<WorkDay>>(new WorkdayRequest());
        return Ok(workdays);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetWorkdayById(Guid id)
    {
        var workdayRequest = new WorkdayRequest { Id = id };
        var workday = mediator.Send<WorkdayRequest, WorkDay>(workdayRequest);

        if (workday == null)
        {
            return NotFound();
        }
        
        return Ok(workday);
    }

    [HttpPost]
    public IActionResult CreateWorkday([FromBody] WorkDay? workday)
    {
        if (workday == null)
        {
            return BadRequest("Invalid workday data");
        }
        
        var createWorkdayRequest = new CreateWorkdayRequest
        {
            StartTime = workday.StartTime,
            EndTime = workday.EndTime,
            Employee = workday.Employee
        };

        var createdWorkday = mediator.Send<CreateWorkdayRequest, WorkDay>(createWorkdayRequest);

        return CreatedAtAction(nameof(GetWorkdayById), new { id = createdWorkday.Id }, createdWorkday);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateWorkday(Guid id, [FromBody] WorkDay? updatedWorkday)
    {
        if (updatedWorkday == null)
        {
            return BadRequest("Invalid workday data");
        }

        var existingWorkdayRequest = new WorkdayRequest { Id = id };
        var existingWorkday = await mediator.Send<WorkdayRequest, WorkDay>(existingWorkdayRequest);

        if (existingWorkday == null)
        {
            return NotFound();
        }

        existingWorkday.StartTime = updatedWorkday.StartTime;
        existingWorkday.EndTime = updatedWorkday.EndTime;
        existingWorkday.Employee = updatedWorkday.Employee;

        var updateWorkdayRequest = new UpdateWorkdayRequest
        {
            Employee = existingWorkday.Employee,
            StartTime = existingWorkday.StartTime,
            EndTime = existingWorkday.EndTime
        };

        await mediator.Send<UpdateWorkdayRequest, Unit>(updateWorkdayRequest);

        return Ok(existingWorkday);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteWorkday(Guid id)
    {
        var workdayRequest = new WorkdayRequest { Id = id };
        var existingWorkday = await mediator.Send<WorkdayRequest, WorkDay>(workdayRequest);

        if (existingWorkday == null)
        {
            return NotFound();
        }

        var deleteWorkdayRequest = new DeleteWorkdayRequest { Id = existingWorkday.Id };

        await mediator.Send<DeleteWorkdayRequest, Unit>(deleteWorkdayRequest);

        return NoContent();
    }
}
