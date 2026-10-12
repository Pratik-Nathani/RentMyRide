using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RentMyRide.Api.Models;
[Table("car")]
public class Car {
 [Key, Column("car_id")] public long CarId {get;set;}
 [Required, MaxLength(50)] public string Brand {get;set;} = "";
 [Required, MaxLength(50)] public string Model {get;set;} = "";
 [Required] public int Year {get;set;}
 [Required, MaxLength(20), Column("registration_number")] public string RegistrationNumber {get;set;} = "";
 [MaxLength(30)] public string? Color {get;set;}
 [Required, MaxLength(30), Column("fuel_type")] public string FuelType {get;set;} = "PETROL";
 [Required, MaxLength(30), Column("transmission_type")] public string TransmissionType {get;set;} = "MANUAL";
 [Required, MaxLength(30), Column("car_category")] public string CarCategory {get;set;} = "HATCHBACK";
 [Required, Column("seating_capacity")] public int SeatingCapacity {get;set;} = 5;
 [Required, Column("rent_per_day")] public decimal RentPerDay {get;set;}
 [Column("rate_per_km")] public decimal? RatePerKm {get;set;}
 [Column("night_charge_per_night")] public decimal? NightChargePerNight {get;set;}
 [Column("mileage_kmpl")] public decimal? MileageKmpl {get;set;}
 [Required, MaxLength(40), Column("availability_status")] public string AvailabilityStatus {get;set;} = "AVAILABLE";
 [MaxLength(500), Column("image_url")] public string? ImageUrl {get;set;}
 [MaxLength(1000)] public string? Description {get;set;}
 [Column("created_at")] public DateTime CreatedAt {get;set;} = DateTime.UtcNow;
 [Column("updated_at")] public DateTime UpdatedAt {get;set;} = DateTime.UtcNow;
}
