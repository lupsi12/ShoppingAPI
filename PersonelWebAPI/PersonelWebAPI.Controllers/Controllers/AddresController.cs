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
    public class AddresController : ControllerBase,IAddresController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddresController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost]
        public AddresResponse AddAddres(AddresCreateRequest addresCreateRequest)
        {
            var response = _unitOfWork.AddresRepository.AddAddres(addresCreateRequest);
            _unitOfWork.Commit();
            return response;
        }
        [HttpDelete("{id}")]
        public void DeleteAddres(int id)
        {
            _unitOfWork.AddresRepository.DeleteAddres(id);
            _unitOfWork.Commit();
        }

        [HttpGet]
        public List<AddresResponse> GetAllAddres([FromQuery] int? personelId = null)
        {
            return _unitOfWork.AddresRepository.GetAllAddres(personelId);
        }


        [HttpGet("{id}")]
        public AddresResponse GetAddresById(int id)
        {
            return _unitOfWork.AddresRepository.GetAddresbyId(id);
        }

        [HttpPatch("{id}")]
        public void PartialUpdateAddres(int id, [FromBody] Dictionary<string, object> updates)
        {
            _unitOfWork.AddresRepository.PartialUpdateAddres(id, updates);
            _unitOfWork.Commit();
        }
    }
}
