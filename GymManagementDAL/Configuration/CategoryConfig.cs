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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.CategoryName)
               .HasColumnType("varchar(20)");



            builder.HasMany(x => x.Sessions)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
              

        }
    }
}
