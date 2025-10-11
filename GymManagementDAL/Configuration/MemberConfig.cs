using GymManagementPL.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Configuration
{
    public class MemberConfig : GymUserConfig<Member>,IEntityTypeConfiguration<Member>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Member> builder)
        {
            builder.Property(x=>x.CreatedAt)
                .HasColumnName("JoinDate")
                .HasDefaultValueSql("getdate()");


            base.Configure(builder);


        }
    }
}
