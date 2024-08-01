using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using PersonelWebAPI.Controllers.Abstract;
using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;
using PersonelWebAPIManagers.Concretes;

namespace PersonelWebAPI.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase, IPersonelController
    {
        PersonelManager _personelManager;
        public PersonelController(PersonelManager personelManager)
        {
            _personelManager = personelManager;
        }
        [HttpPost]
        public PersonelResponse AddPersonel([FromBody]PersonelCreateRequest personelCreateRequest)
        {
            return _personelManager.addPersonel(personelCreateRequest);
        }
        [HttpDelete]
        public void DeleteAllPersonels()
        {
            _personelManager?.deleteAllPersonels();
        }
        [HttpDelete("{id}")]
        public void DeletePersonel(int id)
        {
            _personelManager.deletePersonel(id);
        }
        [HttpGet]
        public List<PersonelResponse> GetAllPersonels([FromQuery]  string? email = null, [FromQuery] string? password = null)
        {
            return _personelManager.getAllPersonels(email, password);
        }
        [HttpGet("{id}")]

        public PersonelResponse GetPersonelById(int id)
        {
            return _personelManager.getPersonelById(id);
        }
        [HttpPatch("{id}")]

        public void PartialUpdatePersonel(int id, [FromBody] Dictionary<string, object> updates)
        {
            _personelManager.partialUpdatePersonel(id, updates);
        }
    }
}
