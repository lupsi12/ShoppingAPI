using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;

namespace PersonelWebAPI.Controllers.Abstract
{
    public interface IPersonelController
    {
        List<PersonelResponse> GetAllPersonels(string? email = null, string? password = null);
        PersonelResponse GetPersonelById(int Id);
        PersonelResponse AddPersonel(PersonelCreateRequest personelCreateRequest);
        void PartialUpdatePersonel(int id, Dictionary<string, object> updates);
        void DeletePersonel(int id);
        void DeleteAllPersonels();
    }
}
