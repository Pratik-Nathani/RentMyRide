using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RentMyRide.Api.Models;
[Table("admin")]
public class Admin {
 [Key, Column("admin_id")] public long AdminId {get;set;} [Required, MaxLength(100)] public string Email {get;set;}=""; [Required, MaxLength(255)] public string Password {get;set;}=""; [MaxLength(50), Column("first_name")] public string? FirstName {get;set;} [MaxLength(50), Column("last_name")] public string? LastName {get;set;}
}
