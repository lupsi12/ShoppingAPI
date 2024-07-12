using PersonelWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelWebAPI.Responses
{
    public class AddresResponse
    {
        public DateTime UpdatedDate { get; set; }
        public int PersonelId { get; set; }
        public string Addres { get; set; }
        public AddresResponse(Addres addres)
        {
            this.UpdatedDate = addres.UpdatedDate;
            this.PersonelId = addres.PersonelId;
            this.Addres = addres.Address;


        }
    }
}
