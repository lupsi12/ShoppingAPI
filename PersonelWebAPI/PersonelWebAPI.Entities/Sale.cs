using System.ComponentModel.DataAnnotations.Schema;

namespace PersonelWebAPI.Entities;

public class Sale : BaseEntity
{
    [ForeignKey("Cart")]
    public int CartId { get; set; }

    // Navigation property
    public Cart Cart { get; set; } // One-to-one relation
}