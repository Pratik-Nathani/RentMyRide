
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentMyRide.Api.Data;

namespace RentMyRide.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DriversController : ControllerBase
{
    private readonly AppDbContext _db;

    public DriversController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetDrivers()
    {
        var drivers = await _db.Drivers.ToListAsync();
        return Ok(drivers);
    }

    [HttpGet("status/{status}")]
    public async Task<IActionResult> GetDriversByStatus(string status)
    {
        var drivers = await _db.Drivers
            .Where(d => d.Status == status)
            .ToListAsync();

        return Ok(new { data = drivers });
    }
}
