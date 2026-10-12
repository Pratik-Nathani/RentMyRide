using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RentMyRide.Api.Models;
[Table("reservation")]
public class Reservation {
 [Key, Column("reservation_id")] public long ReservationId {get;set;} [Column("customer_id")] public long CustomerId {get;set;} [Column("car_id")] public long CarId {get;set;} [Column("assigned_driver_id")] public long? AssignedDriverId {get;set;} [Column("pickup_date")] public DateTime PickupDate {get;set;} [Column("return_date")] public DateTime ReturnDate {get;set;} [Column("total_days")] public int TotalDays {get;set;} [MaxLength(30), Column("trip_type")] public string TripType {get;set;}="LOCAL"; [MaxLength(200), Column("pickup_location")] public string PickupLocation {get;set;}=""; [MaxLength(200), Column("drop_location")] public string DropLocation {get;set;}=""; [Column("estimated_amount")] public decimal EstimatedAmount {get;set;} [MaxLength(30), Column("reservation_status")] public string ReservationStatus {get;set;}="PENDING"; [MaxLength(30), Column("payment_status")] public string PaymentStatus {get;set;}="UNPAID"; [Column("amount_paid")] public decimal AmountPaid {get;set;} [Column("created_at")] public DateTime CreatedAt {get;set;}=DateTime.UtcNow;
}
