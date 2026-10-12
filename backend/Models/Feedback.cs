using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RentMyRide.Api.Models;
[Table("feedback")]
public class Feedback {
 [Key, Column("feedback_id")] public long FeedbackId {get;set;} [Column("customer_id")] public long CustomerId {get;set;} [Column("reservation_id")] public long? ReservationId {get;set;} [Range(1,5)] public int Rating {get;set;} [MaxLength(1000)] public string? Comment {get;set;} [Column("created_at")] public DateTime CreatedAt {get;set;}=DateTime.UtcNow;
}
