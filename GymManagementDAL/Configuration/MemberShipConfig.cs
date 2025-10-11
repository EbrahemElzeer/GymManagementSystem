using GymManagementDAL.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Configuration
{
    public class MemberShipConfig : IEntityTypeConfiguration<MemberShip>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MemberShip> builder)
        {
          builder.Property(x=>x.CreatedAt)
                .HasColumnName("StartDate")
                .HasDefaultValueSql("getdate()");

            builder.HasKey(x => new
            {
                x.memberId,
                x.PlanId
            });

          builder.Ignore(x=>x.Id);
          builder.Ignore(x=>x.Status);

        }
    }
}
