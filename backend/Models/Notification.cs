using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RentMyRide.Api.Models;
[Table("notification")]
public class Notification {
 [Key, Column("notification_id")] public long NotificationId {get;set;} [Column("customer_id")] public long? CustomerId {get;set;} [Column("driver_id")] public long? DriverId {get;set;} [Required, MaxLength(200)] public string Title {get;set;}=""; [MaxLength(2000)] public string? Message {get;set;} [Column("is_read")] public bool IsRead {get;set;} [Column("created_at")] public DateTime CreatedAt {get;set;}=DateTime.UtcNow;
}
