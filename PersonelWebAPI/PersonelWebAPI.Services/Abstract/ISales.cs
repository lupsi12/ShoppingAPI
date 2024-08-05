using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;

namespace PersonelWebAPI.Services.Abstract;

public interface ISales
{
    List<SaleResponse> GetAllSales(int? cartId = null);
    SaleResponse GetSaleById(int id);
    SaleResponse AddSale(SaleCreateRequest saleCreateRequest);
    void PartialUpdateSale(int id,Dictionary<string, object> updates);
    void DeleteSale(int id);
}