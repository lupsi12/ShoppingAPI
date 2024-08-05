using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelWebAPI.Requests
{
    public class AddresCreateRequest
    {
        public int PersonelId { get; set; } 
        public string Addres { get; set; }
    }
}
