using Microsoft.AspNetCore.Mvc;
using PersonelWebAPI.Business.UnitOfWork;
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
        private readonly IUnitOfWork _unitOfWork;

        public SupplierController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost]
        public SupplierResponse AddSupplier([FromBody] SupplierCreateRequest supplierCreateRequest)
        {
            var response = _unitOfWork.SupplierRepository.AddSupplier(supplierCreateRequest);
            _unitOfWork.Commit();
            return response;
        }

        [HttpDelete("{id}")]
        public void DeleteSupplier(int id)
        {
            _unitOfWork.SupplierRepository.DeleteSuplier(id);
            _unitOfWork.Commit();
        }
        [HttpGet]
        public List<SupplierResponse> GetAllSuppliers([FromQuery] string? email = null,[FromQuery] string? password = null)
        {
           return _unitOfWork.SupplierRepository.GetAllSuppliers(email, password);
        }
        [HttpGet("{id}")]
        public SupplierResponse GetSupplierById(int id)
        {
            return _unitOfWork.SupplierRepository.GetSupplierById(id);
        }
        [HttpPatch("{id}")]
        public void PartialUpdateSupplier(int id,[FromBody] Dictionary<string, object> updates)
        {
            _unitOfWork.SupplierRepository.PartialUpdateSupplier(id, updates);
            _unitOfWork.Commit();
        }
    }
}
