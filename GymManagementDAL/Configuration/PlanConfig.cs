using GymManagementPL.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Configuration
{
    public class PlanConfig : IEntityTypeConfiguration<Plan>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Plan> builder)
        {
           builder.Property(x=>x.Name)
                .HasColumnType("varchar(50)");

            builder.Property(x=>x.Description)
                .HasColumnType("varchar(200)");

            builder.Property(x=>x.Price)
                .HasColumnType("decimal(10,2)");
            builder.ToTable(tb=>tb.HasCheckConstraint("DurationDaysConstraint","DurationDays between 1 and 365"));


        }
    }
}
