using PersonelWebAPI.Entities;

namespace PersonelWebAPI.Responses;

public class CartDetailResponse
{
    public int CartId { get; set; }
    public int ProductId { get; set; } 
    public int InstantPrice { get; set; }

    public CartDetailResponse(CartDetail entity)
    {
        this.CartId = entity.CartId;
        this.ProductId = entity.ProductId;
        this.InstantPrice = entity.InstantPrice;
    }
}