using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;
using PersonelWebAPI.Services.Abstract;

namespace PersonelWebAPI.Controllers.Abstract
{
    public interface ISupplierController
    {
        List<SupplierResponse> GetAllSuppliers(string? email = null, string? password = null);
        SupplierResponse GetSupplierById(int id);
        SupplierResponse AddSupplier(SupplierCreateRequest supplierCreateRequest);
        void PartialUpdateSupplier(int id, Dictionary<string, object> updates);
        void DeleteSupplier(int id);
    }
}
