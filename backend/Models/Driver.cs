using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RentMyRide.Api.Models;
[Table("driver")]
public class Driver {
 [Key, Column("driver_id")] public long DriverId {get;set;} [Required, MaxLength(50), Column("first_name")] public string FirstName {get;set;}=""; [Required, MaxLength(50), Column("last_name")] public string LastName {get;set;}=""; [Required, MaxLength(100)] public string Email {get;set;}=""; [Required, MaxLength(255)] public string Password {get;set;}=""; [Required, MaxLength(15), Column("mobile_number")] public string MobileNumber {get;set;}=""; [MaxLength(30), Column("license_number")] public string? LicenseNumber {get;set;} [MaxLength(30)] public string Status {get;set;}="ACTIVE"; [Column("date_of_joining")] public DateTime DateOfJoining {get;set;}=DateTime.UtcNow;
}
