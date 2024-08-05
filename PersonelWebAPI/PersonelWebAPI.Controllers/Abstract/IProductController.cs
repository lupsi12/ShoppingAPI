using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;

namespace PersonelWebAPI.Controllers.Abstract
{
    public interface IProductController
    {
        List<ProductResponse> GetAllProduct(string? name = null);
        ProductResponse GetProductById(int id);
        ProductResponse AddProduct(ProductCreateRequest productCreateRequest);
        void PartialUpdateProduct(int id, Dictionary<string, object> updates);
        void DeleteProduct(int id);
    }
}