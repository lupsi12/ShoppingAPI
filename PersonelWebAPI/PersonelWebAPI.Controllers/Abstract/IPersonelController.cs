using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;

namespace PersonelWebAPI.Controllers.Abstract
{
    public interface IPersonelController
    {
        List<PersonelResponse> getAllPersonels(string? email = null, string? password = null);
        PersonelResponse getPersonelById(int Id);
        PersonelResponse addPersonel(PersonelCreateRequest personelCreateRequest);
        void partialUpdatePersonel(int id, Dictionary<string, object> updates);
        void deletePersonel(int id);
        void deleteAllPersonels();
    }
}
