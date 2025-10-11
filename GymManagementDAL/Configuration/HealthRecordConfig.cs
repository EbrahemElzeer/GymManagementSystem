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
    public class HealthRecordConfig : IEntityTypeConfiguration<HealthRecord>
    {
        public void Configure(EntityTypeBuilder<HealthRecord> builder)
        {
           builder.ToTable("Members").HasKey(x=>x.Id);

            builder.HasOne<Member>()
                .WithOne(m => m.HealthRecord)
                .HasForeignKey<HealthRecord>(hr => hr.Id);  

            builder.Ignore(x=>x.CreatedAt);
        }
    }
}
