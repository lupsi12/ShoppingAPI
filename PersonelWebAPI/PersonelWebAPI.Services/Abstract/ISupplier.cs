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
        List<SupplierResponse> getAllSuppliers(string? email = null, string? password = null);
        SupplierResponse getSupplierById(int id);
        SupplierResponse addSupplier(SupplierCreateRequest supplierCreateRequest);
        void partialUpdateSupplier(int id,Dictionary<string, object> updates);
        void deleteSuplier(int id);

    }
}
