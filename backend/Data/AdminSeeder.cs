
using Microsoft.EntityFrameworkCore;
using RentMyRide.Api.Models;

namespace RentMyRide.Api.Data;

public static class AdminSeeder
{
    public static async Task SeedAsync(AppDbContext db)
    {
        bool exists = await db.Admins.AnyAsync(
            a => a.Email == "admin@rentmyride.in");

        if (exists)
            return;

        var admin = new Admin
        {
            Email = "admin@rentmyride.in",
            Password = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
            FirstName = "Admin",
            LastName = "RentMyRide"
        };

        db.Admins.Add(admin);
        await db.SaveChangesAsync();
    }
}
