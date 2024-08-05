using Microsoft.EntityFrameworkCore;
using PersonelWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelWebAPI.DataAccess
{
    public class WebAPIDbContext:DbContext
    {
        public DbSet<Addres> Addresses { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Sale> Sales { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Server=ISILKEFAL\\SQLEXPRESS; Database=PersonelWebAPIDb; Integrated Security = true; TrustServerCertificate=true");
            optionsBuilder.UseSqlServer("Server=localhost; Database=PersonelWebAPIDb;User Id=sa;Password=Kefal09sl@; TrustServerCertificate=true");
        }
        
    }
}
