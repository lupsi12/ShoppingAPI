using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelWebAPI.Services.Abstract
{
    public interface IAddres
    {
        List<AddresResponse> GetAllAddres(int? personelId=null);
        AddresResponse GetAddresbyId(int id);
        AddresResponse AddAddres(AddresCreateRequest addresCreateRequest);
        void PartialUpdateAddres(int id, Dictionary<string, object> updates);
        void DeleteAddres(int id);

    }
}
