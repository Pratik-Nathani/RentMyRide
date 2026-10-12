using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RentMyRide.Api.Models;
[Table("payment")]
public class Payment {
 [Key, Column("payment_id")] public long PaymentId {get;set;} [Column("customer_id")] public long CustomerId {get;set;} [Column("reservation_id")] public long? ReservationId {get;set;} [Column("amount")] public decimal Amount {get;set;} [MaxLength(30), Column("payment_status")] public string PaymentStatus {get;set;}="PENDING"; [MaxLength(100), Column("razorpay_order_id")] public string? RazorpayOrderId {get;set;} [MaxLength(100), Column("razorpay_payment_id")] public string? RazorpayPaymentId {get;set;} [Column("created_at")] public DateTime CreatedAt {get;set;}=DateTime.UtcNow;
}
