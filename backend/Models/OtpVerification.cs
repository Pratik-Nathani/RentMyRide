using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RentMyRide.Api.Models;
[Table("otp_verification")]
public class OtpVerification {
 [Key, Column("otp_id")] public long OtpId {get;set;} [Required, MaxLength(100)] public string Email {get;set;}=""; [Required, MaxLength(10)] public string Otp {get;set;}=""; [Column("expires_at")] public DateTime ExpiresAt {get;set;} [Column("is_used")] public bool IsUsed {get;set;}
}
