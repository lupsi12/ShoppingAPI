using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using PersonelWebAPI.Controllers.Abstract;
using PersonelWebAPI.Business.UnitOfWork;
using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;
using PersonelWebAPI.Managers.Concretes;

namespace PersonelWebAPI.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase, IPersonelController
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonelController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost]
        public PersonelResponse AddPersonel([FromBody]PersonelCreateRequest personelCreateRequest)
        {
            var response = _unitOfWork.PersonelRepository.AddPersonel(personelCreateRequest);
            _unitOfWork.Commit();
            return response;
        }
        [HttpDelete]
        public void DeleteAllPersonels()
        {
            _unitOfWork?.PersonelRepository.DeleteAllPersonels();
            _unitOfWork.Commit();
        }
        [HttpDelete("{id}")]
        public void DeletePersonel(int id)
        {
            _unitOfWork.PersonelRepository.DeletePersonel(id);
            _unitOfWork.Commit();
        }
        [HttpGet]
        public List<PersonelResponse> GetAllPersonels([FromQuery]  string? email = null, [FromQuery] string? password = null)
        {
            return _unitOfWork.PersonelRepository.GetAllPersonels(email, password);
        }
        [HttpGet("{id}")]

        public PersonelResponse GetPersonelById(int id)
        {
            return _unitOfWork.PersonelRepository.GetPersonelById(id);
        }
        [HttpPatch("{id}")]

        public void PartialUpdatePersonel(int id, [FromBody] Dictionary<string, object> updates)
        {
            _unitOfWork.PersonelRepository.PartialUpdatePersonel(id, updates);
            _unitOfWork.Commit();
        }
    }
}
