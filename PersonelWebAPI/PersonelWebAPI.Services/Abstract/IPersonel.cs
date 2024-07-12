using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;

namespace PersonelWebAPI.Services.Abstract
{
    public interface IPersonel
    {
        List<PersonelResponse> getAllPersonels(string? email = null, string? password = null);
        PersonelResponse getPersonelById(int personelId);
        PersonelResponse addPersonel(PersonelCreateRequest personelCreateRequest);
        void partialUpdatePersonel(int id,Dictionary<string, object> updates);
        void deletePersonel(int id);
        void deleteAllPersonels();
    }
}
