
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
    public class CartController : ControllerBase, ICartController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost]
        public CartResponse AddCart([FromBody] CartCreateRequest cartCreateRequest)
        {
            var response = _unitOfWork.CartRepository.AddCart(cartCreateRequest);
            _unitOfWork.Commit();
            return response;
        }
        [HttpDelete("{id}")]

        public void DeleteCart(int id)
        {
            _unitOfWork.CartRepository.DeleteCart(id);
            _unitOfWork.Commit();
        }


        [HttpGet("{id}")]
        public CartResponse GetCartById(int id)
        {
            return _unitOfWork.CartRepository.GetCartById(id);
        }
        [HttpGet]
        public List<CartResponse> GetAllCart([FromQuery] int? personelId = null)
        {
            return _unitOfWork.CartRepository.GetAllCarts(personelId);
        }
        [HttpPatch("{id}")]
        public void PartialUpdateCart(int id, [FromBody] Dictionary<string, object> updates)
        {
            _unitOfWork.CartRepository.PartialUpdateCart(id, updates);
            _unitOfWork.Commit();
        }
    }
}
