using GymManagementDAL.Configuration;
using GymManagementDAL.Context;
using GymManagementDAL.Repositories.Interface;
using GymManagementPL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repositories.Implementaion
{
    public class PlanRepository:IPlanRepository
    {
        private readonly GymdbContext _dbcontext;

        public PlanRepository( GymdbContext gymdbContext)
        {
            _dbcontext = gymdbContext;
        }
        public IEnumerable<Plan> GetAllMembers()=>_dbcontext.Plans.ToList();
       

        public Plan? GetMemberById(int id) => _dbcontext.Plans.Find(id);


        public int UpdateMember(Plan Plan)
        {
           _dbcontext.Plans.Update(Plan);
            return _dbcontext.SaveChanges();
        }

      
    }
}
