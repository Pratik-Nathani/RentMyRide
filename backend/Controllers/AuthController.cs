
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentMyRide.Api.Data;
using BCrypt.Net;

namespace RentMyRide.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _db;

    public AuthController(AppDbContext db)
    {
        _db = db;
    }

    public class AdminLoginRequest
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }

    [HttpPost("admin/login")]
    public async Task<IActionResult> AdminLogin(
        [FromBody] AdminLoginRequest request)
    {
        var admin = await _db.Admins.FirstOrDefaultAsync(
            a => a.Email == request.Email);

        if (admin == null ||
            !BCrypt.Net.BCrypt.Verify(request.Password, admin.Password))
        {
            return Unauthorized(new
            {
                message = "Invalid email or password"
            });
        }

        return Ok(new
        {
            success = true,
            token = "dev-admin-token",
            role = "ADMIN",
            userId = admin.AdminId,
            name = $"{admin.FirstName} {admin.LastName}",
            email = admin.Email,
            message = "Admin login successful"
        });
    }


    public class CustomerLoginRequest
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }

    [HttpPost("customer/login")]
    public async Task<IActionResult> CustomerLogin(
        [FromBody] CustomerLoginRequest request)
    {
        var customer = await _db.Customers.FirstOrDefaultAsync(
            c => c.Email == request.Email);

        if (customer == null ||
            !BCrypt.Net.BCrypt.Verify(request.Password, customer.Password))
        {
            return Unauthorized(new
            {
                success = false,
                message = "Invalid email or password"
            });
        }

        if (customer.AccountStatus != "ACTIVE")
        {
            return Unauthorized(new
            {
                success = false,
                message = "Your account is not active."
            });
        }

        return Ok(new
        {
            success = true,
            token = "dev-customer-token",
            role = "CUSTOMER",
            userId = customer.CustomerId,
            name = $"{customer.FirstName} {customer.LastName}",
            email = customer.Email,
            message = "Customer login successful"
        });
    }
}
