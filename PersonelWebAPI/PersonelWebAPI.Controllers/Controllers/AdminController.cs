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
        public AdminResponse addAdmin([FromBody] AdminCreateRequest adminCreateRequest)
        {
            return _adminManager.addAdmin(adminCreateRequest);
        }
        [HttpDelete("{id}")]

        public void deleteAdmin(int id)
        {
            _adminManager.deleteAdmin(id);
        }

        [HttpGet("{id}")]
        public AdminResponse GetAdminById(int id)
        {
            return _adminManager.GetAdminById(id);
        }
        [HttpGet]
        public List<AdminResponse> getAllAdmins([FromQuery] string? email = null, [FromQuery] string? password = null)
        {
            return _adminManager.getAllAdmins(email, password);
        }
        [HttpPatch("{id}")]
        public void partialUpdateAdmin(int id, [FromBody] Dictionary<string, object> updates)
        {
            _adminManager.partialUpdateAdmin(id, updates);
        }
    }
}
