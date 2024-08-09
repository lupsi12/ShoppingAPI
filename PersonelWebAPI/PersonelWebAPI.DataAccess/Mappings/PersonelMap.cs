using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonelWebAPI.Entities;

namespace PersonelWebAPI.DataAccess.Mappings;

public class PersonelMap : IEntityTypeConfiguration<Personel>
{
    public void Configure(EntityTypeBuilder<Personel> builder)
    {
        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(20);
    }
}