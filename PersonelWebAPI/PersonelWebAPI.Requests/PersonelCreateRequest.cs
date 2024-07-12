using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using PersonelWebAPI.Enums;

namespace PersonelWebAPI.Requests
{
    public class PersonelCreateRequest
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        //public List<string> Addresses { get; set; }
        public string Phone { get; set; }
        public Roles Role { get; set; }
        public Status Status { get; set; }
        public int AdminId { get; set; } // foreign key

    }
}
