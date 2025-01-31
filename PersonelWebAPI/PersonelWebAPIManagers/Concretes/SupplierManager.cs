﻿using PersonelWebAPI.DataAccess;
using PersonelWebAPI.Entities;
using PersonelWebAPI.Requests;
using PersonelWebAPI.Responses;
using PersonelWebAPI.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonelWebAPI.Enums;

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
            supplier.Status = Status.APPROVAL_WAIT;
            supplier.AdminId = supplierCreateRequest.AdminId;
            _context.Suppliers.Add(supplier);
            SupplierResponse supplierResponse = new SupplierResponse(supplier);
            return supplierResponse;
        }
        public void DeleteSuplier(int id)
        {
            var deleteSupplier = _context.Suppliers.Find(id);

            if (deleteSupplier != null)
            {
                _context.Suppliers.Remove(deleteSupplier);
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
                        case "name":
                            supplier.Name = update.Value.ToString();
                            break;
                        case "description":
                            supplier.Description = update.Value.ToString();
                            break;
                        case "email":
                            supplier.Email = update.Value.ToString();
                            break;
                        case "password":
                            supplier.Password = update.Value.ToString();
                            break;
                        case "role":
                            if (Enum.TryParse(typeof(Enums.Roles), update.Value.ToString(), out var role))
                            {
                                supplier.Role = (Enums.Roles)role;
                            }
                            break;
                        case "status":
                            if (Enum.TryParse(typeof(Status), update.Value.ToString(), out var status))
                            {
                                supplier.Status = (Status)status;
                            }
                            break;
                        case "updateddate":
                            if (DateTime.TryParse(update.Value.ToString(), out DateTime updateddate))
                            {
                                supplier.UpdatedDate = updateddate;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
