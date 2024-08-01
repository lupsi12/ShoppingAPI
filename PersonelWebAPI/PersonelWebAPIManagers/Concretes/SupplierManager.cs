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
    public class SupplierManager : ISupplier
    {
        private readonly WebAPIDbContext _context;
        public SupplierManager(WebAPIDbContext context)
        {
            _context = context;
        }
        public SupplierResponse AddSupplier(SupplierCreateRequest supplierCreateRequest)
        {
            Supplier supplier = new Supplier();
            supplier.CreatedDate = DateTime.Now;
            supplier.Name = supplierCreateRequest.Name;
            supplier.Description = supplierCreateRequest.Description;
            supplier.Email = supplierCreateRequest.Email;
            supplier.Password = supplierCreateRequest.Password;
            supplier.Role = Enums.Roles.SUPPLIER;
            supplier.Status = supplierCreateRequest.Status;
            supplier.AdminId = supplierCreateRequest.AdminId;
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            SupplierResponse supplierResponse = new SupplierResponse(supplier);
            return supplierResponse;
        }
        public void DeleteSuplier(int id)
        {
            var deleteSupplier = _context.Suppliers.Find(id);

            if (deleteSupplier != null)
            {
                _context.Suppliers.Remove(deleteSupplier);
                _context.SaveChanges();
            }
        }
        public List<SupplierResponse> GetAllSuppliers(string? email = null, string? password = null)
        {
            IQueryable<Supplier> query = _context.Suppliers;
            if (email != null && password != null)
            {
                query = query.Where(p => p.Password == password && p.Email == email);
            }
            else if (email != null)
            {
                query = query.Where(query => query.Email == email);
            }
            List<SupplierResponse> supplierResponses = query.Select(p => new SupplierResponse(p))
               .ToList();
            return supplierResponses;
        }

        public SupplierResponse GetSupplierById(int id)
        {
            Supplier supplier = _context.Suppliers.Find(id);
            if (supplier == null) 
            {
                return null;
            }
            SupplierResponse supplierResponse = new SupplierResponse(supplier);
            return supplierResponse;
        }

        public void PartialUpdateSupplier(int id, Dictionary<string, object> updates)
        {
            
            var supplier = _context.Suppliers.FirstOrDefault(x => x.Id == id);
            if (supplier != null)
            {
                foreach (var update in updates)
                {
                    switch (update.Key.ToLower())
                    {
                        case "description":
                            supplier.Description = update.Value.ToString();
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
