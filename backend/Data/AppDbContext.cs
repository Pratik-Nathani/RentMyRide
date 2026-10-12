using Microsoft.EntityFrameworkCore;
using RentMyRide.Api.Models;
namespace RentMyRide.Api.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) {
 public DbSet<Car> Cars => Set<Car>(); public DbSet<Customer> Customers => Set<Customer>(); public DbSet<Driver> Drivers => Set<Driver>(); public DbSet<Admin> Admins => Set<Admin>(); public DbSet<Reservation> Reservations => Set<Reservation>(); public DbSet<Rental> Rentals => Set<Rental>(); public DbSet<Payment> Payments => Set<Payment>(); public DbSet<PromoCode> PromoCodes => Set<PromoCode>(); public DbSet<Feedback> Feedback => Set<Feedback>(); public DbSet<Notification> Notifications => Set<Notification>(); public DbSet<OtpVerification> OtpVerifications => Set<OtpVerification>();
 protected override void OnModelCreating(ModelBuilder modelBuilder) { base.OnModelCreating(modelBuilder); modelBuilder.Entity<Car>().HasIndex(x=>x.RegistrationNumber).IsUnique(); modelBuilder.Entity<Customer>().HasIndex(x=>x.Email).IsUnique(); modelBuilder.Entity<Driver>().HasIndex(x=>x.Email).IsUnique(); }
}
