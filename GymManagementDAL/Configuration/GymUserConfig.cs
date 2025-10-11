using GymManagementPL.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Configuration
{
    public class GymUserConfig<T> : IEntityTypeConfiguration<T> where T : GymUser
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x=>x.Name)
              
               .HasColumnType("varchar(100)");

            builder.Property(x => x.Email)

               .HasColumnType("varchar(100)");
            builder.ToTable(tb => tb.HasCheckConstraint("EmailValidFormatConstraint",
                "Email Like '_%@_%._%'"));

            builder.HasIndex(builder => builder.Email).IsUnique();

            builder.Property(x => x.phone)
               .HasColumnType("varchar (11)");

            builder.ToTable(tb => tb.HasCheckConstraint("PhoneValidFormatConstraint",
              "Phone LIKE '01[0,1,2,5]%' AND LEN(Phone) = 11 AND Phone NOT LIKE '%[^0-9]%'"));

            builder.OwnsOne(x=>x.Address, Addressbulder =>
            {
               Addressbulder.Property(x => x.Street)
                .HasColumnType("varchar(100)")
                .HasColumnName("Street");

                Addressbulder.Property(x => x.City)
                .HasColumnType("varchar(100)")
                .HasColumnName("City");

                Addressbulder.Property(x => x.BuildingNumber)
                .HasColumnName("BuildingNumber");
            });

        }
    }


}
