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
        List<AddresResponse> getAllAddres(int? personelId=null);
        AddresResponse getAddresbyId(int id);
        AddresResponse addAddres(AddresCreateRequest addresCreateRequest);
        void partialUpdateAddres(int id, Dictionary<string, object> updates);
        void deleteAddres(int id);

    }
}
