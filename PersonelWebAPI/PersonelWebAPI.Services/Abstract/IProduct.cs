using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;

namespace PersonelWebAPI.Services.Abstract;

public interface IProduct
{
    List<ProductResponse> GetAllProducts(string? name = null);
    ProductResponse GetProductById(int id);
    ProductResponse AddProduct(ProductCreateRequest productCreateRequest);
    void PartialUpdateProduct(int id,Dictionary<string, object> updates);
    void DeleteProduct(int id);
}