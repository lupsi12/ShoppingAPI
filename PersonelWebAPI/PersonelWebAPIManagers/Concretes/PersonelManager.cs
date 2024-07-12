using PersonelWebAPI.DataAccess;
using PersonelWebAPI.Entities;
using PersonelWebAPI.Enums;
using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;
using PersonelWebAPI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelWebAPIManagers.Concretes
{
    public class PersonelManager : IPersonel
    {
        public List<PersonelResponse> getAllPersonels(string? email = null, string? password = null)
        {
            using (var context = new WebAPIDbContext())
            {
                IQueryable<Personel> query = context.Personels;
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
        }
        public PersonelResponse getPersonelById(int personelId)
        {
            using (var context = new WebAPIDbContext())
            {
                Personel personel = context.Personels.Find(personelId);
                PersonelResponse personelResponse = new PersonelResponse(personel);
                return personelResponse;
            }
        }
        public PersonelResponse addPersonel(PersonelCreateRequest personelCreateRequest)
        {
            using(var context = new WebAPIDbContext())
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
                context.Personels.Add(personel);
                context.SaveChanges();
                PersonelResponse personelResponse = new PersonelResponse(personel);
                return personelResponse;
            }
        }
        public void partialUpdatePersonel(int id, Dictionary<string, object> updates)
        {
            using (var context = new WebAPIDbContext())
            {
                var personel = context.Personels.FirstOrDefault(p => p.Id == id);

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
                    context.SaveChanges();
                }
            }
        }

        public void deleteAllPersonels()
        {
            using (var context = new WebAPIDbContext())
            {
                var personels = context.Personels.ToList();
                context.Personels.RemoveRange(personels);
                context.SaveChanges();
            }
        }

        public void deletePersonel(int id)
        {
            using (var context = new WebAPIDbContext())
            {
                var deletePersonel = context.Personels.Find(id);
                context.Personels.RemoveRange(deletePersonel);
                context.SaveChanges();
            }
        }
    }
}
