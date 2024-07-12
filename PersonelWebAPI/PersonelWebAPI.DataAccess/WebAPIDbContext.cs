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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=ISILKEFAL\\SQLEXPRESS; Database=PersonelWebAPIDb; Integrated Security = true; TrustServerCertificate=true");
        }
        public DbSet<Personel> Personels { get; set; }

    }
}
