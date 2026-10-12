
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentMyRide.Api.Data;
using RentMyRide.Api.Models;

namespace RentMyRide.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly AppDbContext _db;

    public CustomersController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await _db.Customers.ToListAsync();
        return Ok(customers);
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterCustomer(
        [FromBody] Customer customer)
    {
        var existingCustomer = await _db.Customers
            .AnyAsync(c => c.Email == customer.Email);

        if (existingCustomer)
        {
            return BadRequest(new
            {
                success = false,
                message = "An account with this email already exists."
            });
        }

        customer.Password = BCrypt.Net.BCrypt.HashPassword(customer.Password);
        _db.Customers.Add(customer);
        await _db.SaveChangesAsync();

        return Ok(new
        {
            success = true,
            message = "Customer registered successfully."
        });
    }
}
