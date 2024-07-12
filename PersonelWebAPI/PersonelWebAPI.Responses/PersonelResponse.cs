using PersonelWebAPI.Entities;
using PersonelWebAPI.Enums;

namespace PersonelWebAPI.Responses
{
    public class PersonelResponse
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public List<string> Addresses { get; set; }
        public Roles Role { get; set; }
        public int AdminId { get; set; } // foreign key
        public Admin admin { get; set; }
        public PersonelResponse(Personel personelEntities)
        {
            this.Id = personelEntities.Id;
            this.Name = personelEntities.Name;
            this.CreatedDate = personelEntities.CreatedDate;
            this.UpdatedDate = personelEntities.UpdatedDate;
            this.Email = personelEntities.Email;
            this.Password = personelEntities.Password;
            //this.Addresses = personelEntities.Addresses;
            this.Role = personelEntities.Role;  
            this.AdminId = personelEntities.AdminId;
            this.admin = personelEntities.Admin;
        }
    }
}
