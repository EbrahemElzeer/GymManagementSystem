using GymManagementPL.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Configuration
{
    public class SessionConfig : IEntityTypeConfiguration<Session>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Session> builder)
        {

            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint("CapacityConstrin", "Capacity between 1 and 25");
                tb.HasCheckConstraint("StartEndTimeConstraint", "EndTime > StartTime");
            });



            builder.HasOne(builder => builder.Trainer)
                .WithMany(trainer => trainer.Sessions)
                .HasForeignKey(builder => builder.TrainerId);
               
        }
    }
}
