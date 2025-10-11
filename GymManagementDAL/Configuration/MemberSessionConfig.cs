using GymManagementDAL.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Configuration
{
    internal class MemberSessionConfig : IEntityTypeConfiguration<MemberSession>
    {
        public void Configure(EntityTypeBuilder<MemberSession> builder)
        {
           builder.Property(x=>x.CreatedAt)
                 .HasColumnName("BookingDate")
                 .HasDefaultValueSql("getdate()");
            builder.HasKey(x => new
            {
                x.MemberId,
                x.SessionId
            });

            builder.Ignore(x=>x.Id);
        }
    }
}
