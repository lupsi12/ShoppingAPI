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
        public AddresResponse addAddres(AddresCreateRequest addresCreateRequest)
        {
            return _addresManager.addAddres(addresCreateRequest);
        }
        [HttpDelete("{id}")]
        public void deleteAddres(int id)
        {
            _addresManager.deleteAddres(id);
        }

        [HttpGet]
        public List<AddresResponse> getAllAddres([FromQuery] int? personelId = null)
        {
            return _addresManager.getAllAddres(personelId);
        }


        [HttpGet("{id}")]
        public AddresResponse getAddresById(int id)
        {
            return _addresManager.getAddresbyId(id);
        }

        [HttpPatch("{id}")]
        public void partialUpdateAddres(int id, [FromBody] Dictionary<string, object> updates)
        {
            _addresManager.partialUpdateAddres(id, updates);
        }
    }
}
