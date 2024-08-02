using Microsoft.AspNetCore.Mvc;
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
        AddresManager _addresManager;
        public AddresController(AddresManager addresManager)
        {
            _addresManager = addresManager;
        }
        [HttpPost]
        public AddresResponse AddAddres(AddresCreateRequest addresCreateRequest)
        {
            return _addresManager.AddAddres(addresCreateRequest);
        }
        [HttpDelete("{id}")]
        public void DeleteAddres(int id)
        {
            _addresManager.DeleteAddres(id);
        }

        [HttpGet]
        public List<AddresResponse> GetAllAddres([FromQuery] int? personelId = null)
        {
            return _addresManager.GetAllAddres(personelId);
        }


        [HttpGet("{id}")]
        public AddresResponse GetAddresById(int id)
        {
            return _addresManager.GetAddresbyId(id);
        }

        [HttpPatch("{id}")]
        public void PartialUpdateAddres(int id, [FromBody] Dictionary<string, object> updates)
        {
            _addresManager.PartialUpdateAddres(id, updates);
        }
    }
}
