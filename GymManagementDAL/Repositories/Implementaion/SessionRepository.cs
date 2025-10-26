using GymManagementDAL.Context;
using GymManagementDAL.Repositories.Interface;
using GymManagementPL.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repositories.Implementaion
{
    public class SessionRepository:GenericRepository<Session>,ISessionRepository
    {
        private readonly GymdbContext _gymdbContext;

        public SessionRepository(GymdbContext gymdbContext): base(gymdbContext) {
        
            _gymdbContext = gymdbContext;
        }

        public Session? GetByIdCategoryAndTrainer(int id)
        {
            return _gymdbContext.Sessions.Include(s => s.Capacity)
                .Include(s => s.Trainer).FirstOrDefault();
        }

        public IEnumerable<Session> GetAllWithCategoryAndTrainer()
        {
            return _gymdbContext.Sessions.Include(s => s.Category)
                .Include(s => s.Trainer).ToList();
        }

        public int GetCountOfBookedSlots(int id)
        {
            return _gymdbContext.MemberSessions.Count(s=>s.SessionId==id);
        }
    }
}
