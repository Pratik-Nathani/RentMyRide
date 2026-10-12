
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentMyRide.Api.Data;

namespace RentMyRide.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeedbackController : ControllerBase
{
    private readonly AppDbContext _db;

    public FeedbackController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetFeedback()
    {
        var feedback = await _db.Feedback.ToListAsync();
        return Ok(new { data = feedback });
    }
}
