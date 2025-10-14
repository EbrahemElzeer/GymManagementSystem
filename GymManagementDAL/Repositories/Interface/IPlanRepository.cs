using GymManagementPL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repositories.Interface
{
    public interface IPlanRepository
    {
        IEnumerable<Plan> GetAllMembers();

        Plan? GetMemberById(int id);

   

        int UpdateMember(Plan plan);

     

     
    }
}
