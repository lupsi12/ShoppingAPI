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
        
        List<PersonelResponse> GetAllPersonels(string? email = null, string? password = null);
        PersonelResponse GetPersonelById(int id);
        PersonelResponse AddPersonel(PersonelCreateRequest personelCreateRequest);
        void PartialUpdatePersonel(int id,Dictionary<string, object> updates);
        void DeletePersonel(int id);
        void DeleteAllPersonels();
    }
}
