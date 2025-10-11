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
    public class MemberRepository:IMemberRepository
    {
        private readonly GymdbContext _dbcontext = new GymdbContext();

        public int AddMember(Member member)
        {
            throw new NotImplementedException();
        }

        public int DeleteMember(int id)
        {
            var member = _dbcontext.Members.Find(id);
            if(member == null) return 0;
            _dbcontext.Members.Remove(member);
            return _dbcontext.SaveChanges();
        }


        public IEnumerable<Member> GetAllMembers()=>_dbcontext.Members.ToList();
       

        public Member? GetMemberById(int id) => _dbcontext.Members.Find(id);
      

        public int UpdateMember(Member member)
        {
           _dbcontext.Members.Update(member);
            return _dbcontext.SaveChanges();
        }

      
    }
}
