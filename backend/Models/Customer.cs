using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RentMyRide.Api.Models;
[Table("customer")]
public class Customer {
 [Key, Column("customer_id")] public long CustomerId {get;set;} [Required, MaxLength(50), Column("first_name")] public string FirstName {get;set;}=""; [Required, MaxLength(50), Column("last_name")] public string LastName {get;set;}=""; [Required, MaxLength(100)] public string Email {get;set;}=""; [Required, MaxLength(255)] public string Password {get;set;}=""; [Required, MaxLength(15), Column("mobile_number")] public string MobileNumber {get;set;}=""; [MaxLength(300)] public string? Address {get;set;} [MaxLength(50)] public string? City {get;set;} [MaxLength(50)] public string? State {get;set;} [Column("wallet_balance")] public decimal WalletBalance {get;set;} [Column("trust_score")] public int TrustScore {get;set;} [MaxLength(30), Column("account_status")] public string AccountStatus {get;set;}="ACTIVE"; [MaxLength(20)] public string Role {get;set;}="CUSTOMER"; [Column("created_at")] public DateTime CreatedAt {get;set;}=DateTime.UtcNow;
}
