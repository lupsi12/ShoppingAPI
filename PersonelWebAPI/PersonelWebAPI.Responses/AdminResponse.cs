using PersonelWebAPI.Entities;
using PersonelWebAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelWebAPI.Responses
{
    public class AdminResponse
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public Roles Role { get; set; }
        public AdminResponse(Admin admin) 
        {
            this.Email = admin.Email;    
            this.Password = admin.Password;
            this.Role = admin.Role;
        }
    }
}
