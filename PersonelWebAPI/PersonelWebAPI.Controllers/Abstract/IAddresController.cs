using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;

namespace PersonelWebAPI.Controllers.Abstract
{
    public interface IAddresController
    {
        List<AddresResponse> GetAllAddres(int? personelId = null);
        AddresResponse GetAddresById(int id);
        AddresResponse AddAddres(AddresCreateRequest addresCreateRequest);
        void PartialUpdateAddres(int id, Dictionary<string, object> updates);
        void DeleteAddres(int id);
    }
}
