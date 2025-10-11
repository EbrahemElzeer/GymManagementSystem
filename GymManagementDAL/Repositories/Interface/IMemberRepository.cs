using GymManagementPL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repositories.Interface
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetAllMembers();

        Member? GetMemberById(int id);

        int AddMember(Member member);

        int UpdateMember(Member member);

        int DeleteMember(int id);

     
    }
}
