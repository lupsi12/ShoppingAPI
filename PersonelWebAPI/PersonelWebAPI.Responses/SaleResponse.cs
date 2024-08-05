using PersonelWebAPI.Entities;

namespace PersonelWebAPI.Responses;

public class SaleResponse
{
    public int CartId { get; set; }

    public SaleResponse(Sale entity)
    {
        this.CartId = entity.CartId;
    }
}