using PersonelWebAPI.Entities;

namespace PersonelWebAPI.Responses;

public class CartResponse
{
    public int PersonelId { get; set; }

    public CartResponse(Cart entity)
    {
        this.PersonelId = entity.PersonelId;
    }
}