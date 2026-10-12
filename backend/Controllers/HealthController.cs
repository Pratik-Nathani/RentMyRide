using Microsoft.AspNetCore.Mvc;
namespace RentMyRide.Api.Controllers;
[ApiController, Route("api/health")]
public class HealthController : ControllerBase { [HttpGet] public IActionResult Get() => Ok(new { status="ok", application="RentMyRide .NET API" }); }
