using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RentMyRide.Api.Models;
[Table("rental")]
public class Rental {
 [Key, Column("rental_id")] public long RentalId {get;set;} [Column("reservation_id")] public long ReservationId {get;set;} [Column("customer_id")] public long CustomerId {get;set;} [Column("car_id")] public long CarId {get;set;} [Column("driver_id")] public long? DriverId {get;set;} [Column("actual_pickup_at")] public DateTime? ActualPickupAt {get;set;} [Column("actual_return_at")] public DateTime? ActualReturnAt {get;set;} [MaxLength(30)] public string Status {get;set;}="PENDING";
}
