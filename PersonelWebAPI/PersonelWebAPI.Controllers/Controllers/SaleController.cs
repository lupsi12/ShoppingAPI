using Microsoft.AspNetCore.Mvc;
using PersonelWebAPI.UnitOfWork.UnitOfWork;
using PersonelWebAPI.Controllers.Abstract;
using PersonelWebAPI.Managers.Concretes;
using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;

namespace PersonelWebAPI.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase, ISaleController
    {
        private readonly IUnitOfWork _unitOfWork;

        public SaleController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost]
        public SaleResponse AddSale([FromBody] SaleCreateRequest saleCreateRequest)
        {
            var response = _unitOfWork.SalesRepository.AddSale(saleCreateRequest);
            _unitOfWork.Commit();
            return response;
        }
        [HttpDelete("{id}")]

        public void DeleteSale(int id)
        {
            _unitOfWork.SalesRepository.DeleteSale(id);
            _unitOfWork.Commit();
        }


        [HttpGet("{id}")]
        public SaleResponse GetSaleById(int id)
        {
            return _unitOfWork.SalesRepository.GetSaleById(id);
        }
        [HttpGet]
        public List<SaleResponse> GetAllSale([FromQuery] int? cartId = null)
        {
            return _unitOfWork.SalesRepository.GetAllSales(cartId);
        }
        [HttpPatch("{id}")]
        public void PartialUpdateSale(int id, [FromBody] Dictionary<string, object> updates)
        {
            _unitOfWork.SalesRepository.PartialUpdateSale(id, updates);
            _unitOfWork.Commit();
        }
    }
}