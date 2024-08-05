using PersonelWebAPI.DataAccess;
using PersonelWebAPI.Entities;
using PersonelWebAPI.Enums;
using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;
using PersonelWebAPI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonelWebAPI.Managers.Concretes
{
    public class PersonelManager : IPersonel
    {
        private readonly WebAPIDbContext _context;
        public PersonelManager(WebAPIDbContext webApiDbContext)
        {
            _context = webApiDbContext;
        }

        public List<PersonelResponse> GetAllPersonels(string? email = null, string? password = null)
        {
            IQueryable<Personel> query = _context.Personels;
            if (email != null && password != null)
            {
                query = query.Where(p => p.Email == email && p.Password == password);
            }
            else if (email != null)
            {
                query = query.Where(p => p.Email == email);
            }
            List<PersonelResponse> personelResponses = query
                .Select(p => new PersonelResponse(p))
                .ToList();
            return personelResponses;
        }

        public PersonelResponse GetPersonelById(int personelId)
        {
            Personel personel = _context.Personels.Find(personelId);
            PersonelResponse personelResponse = new PersonelResponse(personel);
            return personelResponse;
        }

        public PersonelResponse AddPersonel(PersonelCreateRequest personelCreateRequest)
        {
            Personel personel = new Personel();
            personel.CreatedDate = DateTime.Now;
            personel.Name = personelCreateRequest.Name;
            personel.LastName = personelCreateRequest.LastName;
            personel.Email = personelCreateRequest.Email;
            personel.Password = personelCreateRequest.Password;
            personel.BirthDate = personelCreateRequest.BirthDate;
            //personel.Addresses = personelCreateRequest.Addresses;
            personel.Phone = personelCreateRequest.Phone;
            personel.Role = Roles.PERSONEL;
            personel.Status = Status.APPROVAL_WAIT;
            personel.AdminId = personelCreateRequest.AdminId;

            _context.Personels.Add(personel);

            PersonelResponse personelResponse = new PersonelResponse(personel);
            return personelResponse;
        }

        public void PartialUpdatePersonel(int id, Dictionary<string, object> updates)
        {
            var personel = _context.Personels.FirstOrDefault(p => p.Id == id);

            if (personel != null)
            {
                foreach (var update in updates)
                {
                    switch (update.Key.ToLower())
                    {
                        case "name":
                            personel.Name = update.Value.ToString();
                            break;
                        case "email":
                            personel.Email = update.Value.ToString();
                            break;
                        case "password":
                            personel.Password = update.Value.ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void DeleteAllPersonels()
        {
            var personels = _context.Personels.ToList();
            _context.Personels.RemoveRange(personels);
        }

        public void DeletePersonel(int id)
        {
            var deletePersonel = _context.Personels.Find(id);
            if (deletePersonel != null)
            {
                _context.Personels.Remove(deletePersonel);
            }
        }
    }
}
