using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;

namespace PersonelWebAPI.Controllers.Abstract
{
    public interface IAddresController
    {
        List<AddresResponse> getAllAddres(int? personelId = null);
        AddresResponse getAddresById(int id);
        AddresResponse addAddres(AddresCreateRequest addresCreateRequest);
        void partialUpdateAddres(int id, Dictionary<string, object> updates);
        void deleteAddres(int id);
    }
}
