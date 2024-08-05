using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;

namespace PersonelWebAPI.Services.Abstract;

public interface ICartDetail
{
    List<CartDetailResponse> GetAllCartDetails(int? cartId = null, int? productId = null);
    CartDetailResponse GetCartDetailById(int id);
    CartDetailResponse AddCartDetail(CartDetailCreateRequest cartDetailCreateRequest);
    void PartialUpdateCartDetail(int id,Dictionary<string, object> updates);
    void DeleteCartDetail(int id);
}