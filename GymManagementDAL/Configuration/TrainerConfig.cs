using GymManagementPL.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Configuration
{
    public class TrainerConfig :GymUserConfig<Trainer> ,IEntityTypeConfiguration<Trainer>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Trainer> builder)
        {
            builder.Property(x=>x.CreatedAt)
                .HasColumnName("HireDate")
                .HasDefaultValueSql("getdate()");
            base.Configure(builder);
        }
    }
}
