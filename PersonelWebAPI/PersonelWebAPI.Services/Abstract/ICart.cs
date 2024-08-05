using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;

namespace PersonelWebAPI.Services.Abstract;

public interface ICart
{
    List<CartResponse> GetAllCarts(int? personelId = null);
    CartResponse GetCartById(int id);
    CartResponse AddCart(CartCreateRequest cartCreateRequest);
    void PartialUpdateCart(int id,Dictionary<string, object> updates);
    void DeleteCart(int id);
}