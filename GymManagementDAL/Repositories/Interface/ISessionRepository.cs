using GymManagementPL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repositories.Interface
{
    public interface ISessionRepository
    {

        IEnumerable<Session> GetAllWithCategoryAndTrainer();
        int GetCountOfBookedSlots(int id);

        Session? GetByIdCategoryAndTrainer(int id);
    }
}
