using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;

namespace PersonelWebAPI.Controllers.Abstract
{
    public interface ISaleController
    {
        List<SaleResponse> GetAllSale(int? cartId = null);
        SaleResponse GetSaleById(int id);
        SaleResponse AddSale(SaleCreateRequest saleCreateRequest);
        void PartialUpdateSale(int id, Dictionary<string, object> updates);
        void DeleteSale(int id);
    }
}