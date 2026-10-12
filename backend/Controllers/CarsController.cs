using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentMyRide.Api.Data;
using RentMyRide.Api.Models;
namespace RentMyRide.Api.Controllers;
[ApiController, Route("api/cars")]
public class CarsController(AppDbContext db) : ControllerBase {
 [HttpGet] public async Task<ActionResult<IEnumerable<Car>>> GetAll() => Ok(await db.Cars.AsNoTracking().ToListAsync());
 [HttpGet("available")] public async Task<ActionResult<IEnumerable<Car>>> GetAvailable() => Ok(await db.Cars.AsNoTracking().Where(c=>c.AvailabilityStatus=="AVAILABLE").ToListAsync());
 [HttpGet("search")] public async Task<ActionResult<IEnumerable<Car>>> Search([FromQuery]string keyword) => Ok(await db.Cars.AsNoTracking().Where(c=>c.Brand.Contains(keyword)||c.Model.Contains(keyword)||c.CarCategory.Contains(keyword)).ToListAsync());
 [HttpGet("{id:long}")] public async Task<ActionResult<Car>> Get(long id) { var car=await db.Cars.FindAsync(id); return car is null?NotFound(new {message="Car not found"}):Ok(car); }
 [HttpPost] public async Task<ActionResult<Car>> Create(Car car) { if(await db.Cars.AnyAsync(c=>c.RegistrationNumber==car.RegistrationNumber)) return Conflict(new {message="Registration number already exists"}); car.CreatedAt=car.UpdatedAt=DateTime.UtcNow; if(string.IsNullOrWhiteSpace(car.AvailabilityStatus))car.AvailabilityStatus="AVAILABLE"; db.Cars.Add(car); await db.SaveChangesAsync(); return CreatedAtAction(nameof(Get),new{id=car.CarId},car); }
 [HttpPut("{id:long}")] public async Task<IActionResult> Update(long id, Car input) { var car=await db.Cars.FindAsync(id); if(car is null)return NotFound(); car.Brand=input.Brand;car.Model=input.Model;car.Year=input.Year;car.RegistrationNumber=input.RegistrationNumber;car.Color=input.Color;car.FuelType=input.FuelType;car.TransmissionType=input.TransmissionType;car.CarCategory=input.CarCategory;car.SeatingCapacity=input.SeatingCapacity;car.RentPerDay=input.RentPerDay;car.RatePerKm=input.RatePerKm;car.NightChargePerNight=input.NightChargePerNight;car.MileageKmpl=input.MileageKmpl;car.AvailabilityStatus=input.AvailabilityStatus;car.ImageUrl=input.ImageUrl;car.Description=input.Description;car.UpdatedAt=DateTime.UtcNow; await db.SaveChangesAsync(); return Ok(car); }
 [HttpPatch("{id:long}/status")] public async Task<IActionResult> Status(long id,[FromQuery]string status) { var car=await db.Cars.FindAsync(id);if(car is null)return NotFound();car.AvailabilityStatus=status.ToUpperInvariant();car.UpdatedAt=DateTime.UtcNow;await db.SaveChangesAsync();return Ok(car); }
 [HttpDelete("{id:long}")] public async Task<IActionResult> Delete(long id) { var car=await db.Cars.FindAsync(id);if(car is null)return NotFound();car.AvailabilityStatus="RETIRED";car.UpdatedAt=DateTime.UtcNow;await db.SaveChangesAsync();return NoContent(); }
}
