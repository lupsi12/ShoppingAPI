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
    public class CartDetailController : ControllerBase, ICartDetailController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartDetailController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost]
        public CartDetailResponse AddCartDetail([FromBody] CartDetailCreateRequest cartDetailCreateRequest)
        {
            var response = _unitOfWork.CartDetailRepository.AddCartDetail(cartDetailCreateRequest);
            _unitOfWork.Commit();
            return response;
        }
        [HttpDelete("{id}")]

        public void DeleteCartDetail(int id)
        {
            _unitOfWork.CartDetailRepository.DeleteCartDetail(id);
            _unitOfWork.Commit();
        }


        [HttpGet("{id}")]
        public CartDetailResponse GetCartDetailById(int id)
        {
            return _unitOfWork.CartDetailRepository.GetCartDetailById(id);
        }
        [HttpGet]
        public List<CartDetailResponse> GetAllCartDetail([FromQuery] int? cartId = null,[FromQuery] int? productId = null)
        {
            return _unitOfWork.CartDetailRepository.GetAllCartDetails(cartId, productId);
        }
        [HttpPatch("{id}")]
        public void PartialUpdateCartDetail(int id, [FromBody] Dictionary<string, object> updates)
        {
            _unitOfWork.CartDetailRepository.PartialUpdateCartDetail(id, updates);
            _unitOfWork.Commit();
        }
    }
}