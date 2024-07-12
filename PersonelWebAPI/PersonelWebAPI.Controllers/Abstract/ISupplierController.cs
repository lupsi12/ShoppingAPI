using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;
using PersonelWebAPI.Services.Abstract;

namespace PersonelWebAPI.Controllers.Abstract
{
    public interface ISupplierController
    {
        List<SupplierResponse> getAllSuppliers(string? email = null, string? password = null);
        SupplierResponse getSupplierById(int id);
        SupplierResponse addSupplier(SupplierCreateRequest supplierCreateRequest);
        void partialUpdateSupplier(int id, Dictionary<string, object> updates);
        void deleteSupplier(int id);
    }
}
