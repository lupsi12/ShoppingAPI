using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;

namespace PersonelWebAPI.Controllers.Abstract
{
    public interface IAdminController
    {
        List<AdminResponse> GetAllAdmins(string? email = null, string? password = null);
        AdminResponse GetAdminById(int id);
        AdminResponse AddAdmin(AdminCreateRequest adminCreateRequest);
        void PartialUpdateAdmin(int id, Dictionary<string, object> updates);
        void DeleteAdmin(int id);
    }
}
