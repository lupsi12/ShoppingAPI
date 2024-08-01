using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelWebAPI.Services.Abstract
{
    public interface ISupplier
    {
        List<SupplierResponse> GetAllSuppliers(string? email = null, string? password = null);
        SupplierResponse GetSupplierById(int id);
        SupplierResponse AddSupplier(SupplierCreateRequest supplierCreateRequest);
        void PartialUpdateSupplier(int id,Dictionary<string, object> updates);
        void DeleteSuplier(int id);

    }
}
