
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentMyRide.Api.Data;

namespace RentMyRide.Api.Controllers;

[ApiController]
[Route("api/promo-codes")]
public class PromoCodesController : ControllerBase
{
    private readonly AppDbContext _db;

    public PromoCodesController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetPromoCodes()
    {
        var promoCodes = await _db.PromoCodes.ToListAsync();
        return Ok(new { data = promoCodes });
    }
}
