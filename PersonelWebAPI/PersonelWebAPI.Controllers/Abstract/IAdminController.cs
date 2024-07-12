using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;

namespace PersonelWebAPI.Controllers.Abstract
{
    public interface IAdminController
    {
        List<AdminResponse> getAllAdmins(string? email = null, string? password = null);
        AdminResponse GetAdminById(int id);
        AdminResponse addAdmin(AdminCreateRequest adminCreateRequest);
        void partialUpdateAdmin(int id, Dictionary<string, object> updates);
        void deleteAdmin(int id);
    }
}
