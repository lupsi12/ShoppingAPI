using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelWebAPI.Services.Abstract
{
    public interface IAdmin
    {
        List<AdminResponse> getAllAdmins(string? email = null, string? password = null);
        AdminResponse GetAdminById(int id);
        AdminResponse addAdmin(AdminCreateRequest adminCreateRequest);
        void partialUpdateAdmin(int id, Dictionary<string, object> updates);
        void deleteAdmin(int id);

    }
}
