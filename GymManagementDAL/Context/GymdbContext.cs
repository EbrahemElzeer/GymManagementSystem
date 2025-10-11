using GymManagementDAL.Entitys;
using GymManagementPL.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Context
{
    public class GymdbContext:DbContext
    {


        public DbSet<Member> Members { get; set; }
        public DbSet<Plan> Plans { get; set; }
        
        public DbSet<Category> categories { get; set; }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<Trainer> Trainers { get; set; }

        public DbSet<HealthRecord> healthRecords { get; set; }
        public DbSet<MemberSession> MemberSessions { get; set; }
        public DbSet<MemberShip> MemberShips { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Gym;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
