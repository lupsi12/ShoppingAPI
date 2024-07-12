using PersonelWebAPI.Entities;

namespace PersonelWebAPI.Responses
{
    public class PersonelResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int IdentityNo { get; set; }
        public PersonelResponse(Personel personelEntities)
        {
            this.Id = personelEntities.Id;
            this.Name = personelEntities.Name;
            this.LastName = personelEntities.LastName;
            this.IdentityNo = personelEntities.IdentityNo;
        }
    }
}
