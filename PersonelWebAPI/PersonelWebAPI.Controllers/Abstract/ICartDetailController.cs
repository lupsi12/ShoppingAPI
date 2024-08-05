using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;

namespace PersonelWebAPI.Controllers.Abstract
{
    public interface ICartDetailController
    {
        List<CartDetailResponse> GetAllCartDetail(int? cartId = null, int? productId = null);
        CartDetailResponse GetCartDetailById(int id);
        CartDetailResponse AddCartDetail(CartDetailCreateRequest cartDetailCreateRequest);
        void PartialUpdateCartDetail(int id, Dictionary<string, object> updates);
        void DeleteCartDetail(int id);
    }
}