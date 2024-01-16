using Microsoft.AspNetCore.Mvc;

namespace EmployeeWorkday.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthCheckController : ControllerBase
{
    [HttpGet]
    public ActionResult Check()
    {
        return Ok("2.0");
    }
}
