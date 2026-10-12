using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RentMyRide.Api.Models;
[Table("promo_code")]
public class PromoCode {
 [Key, Column("promo_code_id")] public long PromoCodeId {get;set;} [Required, MaxLength(30)] public string Code {get;set;}=""; [Column("discount_percentage")] public decimal DiscountPercentage {get;set;} [Column("max_discount")] public decimal? MaxDiscount {get;set;} [Column("is_active")] public bool IsActive {get;set;}=true;
}
