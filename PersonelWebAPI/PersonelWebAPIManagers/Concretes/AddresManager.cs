using PersonelWebAPI.DataAccess;
using PersonelWebAPI.Entities;
using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;
using PersonelWebAPI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelWebAPI.Managers.Concretes
{
    public class AddresManager : IAddres
    {
        private readonly WebAPIDbContext _context;
        public AddresManager(WebAPIDbContext context)
        {
            _context = context;
        }
        public AddresResponse addAddres(AddresCreateRequest addresCreateRequest)
        {
            Addres addres = new Addres();
            addres.Address = addresCreateRequest.Addres;
            addres.CreatedDate = addresCreateRequest.CreatedDate;
            addres.PersonelId = addresCreateRequest.PersonelId;
            _context.Addresses.Add(addres);
            _context.SaveChanges();
            AddresResponse addresResponse = new AddresResponse(addres);
            return addresResponse;
        }

        public void deleteAddres(int id)
        {
            var deleteAddres = _context.Addresses.Find(id);
            _context.Addresses.RemoveRange(deleteAddres);
            _context.SaveChanges();
        }

        public AddresResponse getAddresbyId(int id)
        {
            var addres = _context.Addresses.Find(id);
            AddresResponse addresResponse = new AddresResponse(addres);
            return addresResponse;
        }

        public List<AddresResponse> getAllAddres(int? personelId = null)
        {
            IQueryable<Addres> query = _context.Addresses.AsQueryable();
            if (personelId != null)
            {
                query = query.Where(p => p.PersonelId == personelId);
            }
            List<AddresResponse> addresResponses = query.
                Select(p => new AddresResponse(p))
                .ToList();
            return addresResponses;
        }

        public void partialUpdateAddres(int id, Dictionary<string, object> updates)
        {
            var addres = _context.Addresses.FirstOrDefault(x => x.Id == id);
            if (addres != null)
            {
                foreach (var update in updates)
                { 
                    switch (update.Key.ToLower())
                    {
                        case "address":
                            addres.Address = update.Value.ToString();
                            break;
                        default:
                            break;

                    }
                }
                _context.SaveChanges();
            }
        }
    }
}
