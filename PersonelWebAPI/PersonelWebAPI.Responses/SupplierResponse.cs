using PersonelWebAPI.Entities;
using PersonelWebAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelWebAPI.Responses
{
    public class SupplierResponse
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
        public Status Status { get; set; }
        public int AdminId { get; set; } // foreign key
        public SupplierResponse(Supplier supplier)
        {
            this.Id = supplier.Id;
            this.CreatedDate = supplier.CreatedDate;
            this.UpdatedDate = supplier.UpdatedDate;
            this.Name = supplier.Name;
            this.Description = supplier.Description;
            this.Email = supplier.Email;
            this.Password = supplier.Password;
            this.Role = supplier.Role;
            this.Status = supplier.Status;
            this.AdminId = supplier.AdminId;
            
        }
    }
}
