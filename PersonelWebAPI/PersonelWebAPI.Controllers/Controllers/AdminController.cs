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
    public class AdminController : ControllerBase, IAdminController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost]
        public AdminResponse AddAdmin([FromBody] AdminCreateRequest adminCreateRequest)
        {
            var response = _unitOfWork.AdminRepository.AddAdmin(adminCreateRequest);
            _unitOfWork.Commit();
            return response;
        }
        [HttpDelete("{id}")]

        public void DeleteAdmin(int id)
        {
            _unitOfWork.AdminRepository.DeleteAdmin(id);
            _unitOfWork.Commit();
        }

        [HttpGet("{id}")]
        public AdminResponse GetAdminById(int id)
        {
            return _unitOfWork.AdminRepository.GetAdminById(id);
        }
        [HttpGet]
        public List<AdminResponse> GetAllAdmins([FromQuery] string? email = null, [FromQuery] string? password = null)
        {
            return _unitOfWork.AdminRepository.GetAllAdmins(email, password);
        }
        [HttpPatch("{id}")]
        public void PartialUpdateAdmin(int id, [FromBody] Dictionary<string, object> updates)
        {
            _unitOfWork.AdminRepository.PartialUpdateAdmin(id, updates);
            _unitOfWork.Commit();
        }
    }
}
