using Microsoft.AspNetCore.Mvc;
using PersonelWebAPI.Controllers.Abstract;
using PersonelWebAPI.Managers.Concretes;
using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;

namespace PersonelWebAPI.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase, IAdminController
    {
        AdminManager _adminManager;
        public AdminController(AdminManager adminManager)
        {
            _adminManager = adminManager;
        }
        [HttpPost]
        public AdminResponse AddAdmin([FromBody] AdminCreateRequest adminCreateRequest)
        {
            return _adminManager.AddAdmin(adminCreateRequest);
        }
        [HttpDelete("{id}")]

        public void DeleteAdmin(int id)
        {
            _adminManager.DeleteAdmin(id);
        }

        [HttpGet("{id}")]
        public AdminResponse GetAdminById(int id)
        {
            return _adminManager.GetAdminById(id);
        }
        [HttpGet]
        public List<AdminResponse> GetAllAdmins([FromQuery] string? email = null, [FromQuery] string? password = null)
        {
            return _adminManager.GetAllAdmins(email, password);
        }
        [HttpPatch("{id}")]
        public void PartialUpdateAdmin(int id, [FromBody] Dictionary<string, object> updates)
        {
            _adminManager.PartialUpdateAdmin(id, updates);
        }
    }
}
