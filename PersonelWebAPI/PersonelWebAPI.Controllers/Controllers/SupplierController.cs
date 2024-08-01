using Microsoft.AspNetCore.Mvc;
using PersonelWebAPI.Controllers.Abstract;
using PersonelWebAPI.Managers.Concretes;
using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;
using PersonelWebAPI.Services.Abstract;

namespace PersonelWebAPI.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase, ISupplierController
    {
        SupplierManager _supplierManager;
        public SupplierController(SupplierManager supplierManager)
        {
            _supplierManager = supplierManager;
        }
        [HttpPost]
        public SupplierResponse AddSupplier([FromBody] SupplierCreateRequest supplierCreateRequest)
        {
            return _supplierManager.addSupplier(supplierCreateRequest);
        }

        [HttpDelete("{id}")]
        public void DeleteSupplier(int id)
        {
            _supplierManager.deleteSuplier(id);
        }
        [HttpGet]
        public List<SupplierResponse> GetAllSuppliers([FromQuery] string? email = null,[FromQuery] string? password = null)
        {
           return _supplierManager.getAllSuppliers(email, password);
        }
        [HttpGet("{id}")]
        public SupplierResponse GetSupplierById(int id)
        {
            return _supplierManager.getSupplierById(id);
        }
        [HttpPatch("{id}")]
        public void PartialUpdateSupplier(int id,[FromBody] Dictionary<string, object> updates)
        {
            throw new NotImplementedException();
        }
    }
}
