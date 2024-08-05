using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;

namespace PersonelWebAPI.Controllers.Abstract
{
    public interface ICartController
    {
        List<CartResponse> GetAllCart(int? personelId = null);
        CartResponse GetCartById(int id);
        CartResponse AddCart(CartCreateRequest cartCreateRequest);
        void PartialUpdateCart(int id, Dictionary<string, object> updates);
        void DeleteCart(int id);
    }
}