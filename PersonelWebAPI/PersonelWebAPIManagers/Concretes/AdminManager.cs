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

namespace PersonelWebAPI.Managers.Concretes
{
    public class AdminManager : IAdmin
    {
        private readonly WebAPIDbContext _context;

        public AdminManager(WebAPIDbContext context)
        {
            _context = context;
        }
        public AdminResponse AddAdmin(AdminCreateRequest adminCreateRequest)
        {
            Admin admin = new Admin();
            admin.CreatedDate = DateTime.Now;
            admin.Email = adminCreateRequest.Email;
            admin.Password = adminCreateRequest.Password;
            admin.Role = Enums.Roles.ADMIN;
            _context.Admins.Add(admin);
            AdminResponse adminResponse = new AdminResponse(admin);
            return adminResponse;
        }

        public void DeleteAdmin(int id)
        {
            var deleteAdmin = _context.Admins.Find(id);
            _context.Admins.RemoveRange(deleteAdmin);
        }

        public AdminResponse GetAdminById(int id)
        {
            Admin admin = _context.Admins.Find(id);
            AdminResponse adminResponse = new AdminResponse(admin);
            return adminResponse;
        }

        public List<AdminResponse> GetAllAdmins(string? email = null, string? password = null)
        {
            IQueryable<Admin> query = _context.Admins;
            if (email != null && password != null)
            {
                query = query.Where(p => p.Password == password && p.Email == email);
            }
            else if (email != null)
            {
                query = query.Where(p => p.Email == email);
            }
            
            List<AdminResponse> adminResponses = query.Select(p => new AdminResponse(p))
                .ToList();
            return adminResponses;
        }

        public void PartialUpdateAdmin(int id, Dictionary<string, object> updates)
        {
            var admin = _context.Admins.FirstOrDefault(p => p.Id == id);
            if (admin != null) 
            {
                foreach (var update in updates)
                {
                    switch (update.Key.ToLower()) 
                    {
                        case "password":
                            admin.Password = update.Value.ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
