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
    public class ProductController : ControllerBase, IProductController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost]
        public ProductResponse AddProduct([FromBody] ProductCreateRequest productCreateRequest)
        {
            var response = _unitOfWork.ProductRepository.AddProduct(productCreateRequest);
            _unitOfWork.Commit();
            return response;
        }
        [HttpDelete("{id}")]

        public void DeleteProduct(int id)
        {
            _unitOfWork.ProductRepository.DeleteProduct(id);
            _unitOfWork.Commit();
        }


        [HttpGet("{id}")]
        public ProductResponse GetProductById(int id)
        {
            return _unitOfWork.ProductRepository.GetProductById(id);
        }
        [HttpGet]
        public List<ProductResponse> GetAllProduct([FromQuery] string? name = null)
        {
            return _unitOfWork.ProductRepository.GetAllProducts(name);
        }
        [HttpPatch("{id}")]
        public void PartialUpdateProduct(int id, [FromBody] Dictionary<string, object> updates)
        {
            _unitOfWork.ProductRepository.PartialUpdateProduct(id, updates);
            _unitOfWork.Commit();
        }
    }
}