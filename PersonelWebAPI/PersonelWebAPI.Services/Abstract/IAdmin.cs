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
        List<AdminResponse> GetAllAdmins(string? email = null, string? password = null);
        AdminResponse GetAdminById(int id);
        AdminResponse AddAdmin(AdminCreateRequest adminCreateRequest);
        void PartialUpdateAdmin(int id, Dictionary<string, object> updates);
        void DeleteAdmin(int id);

    }
}
