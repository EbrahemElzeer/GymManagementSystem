using GymManagementPL.Entitys;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repositories.Interface
{
    public interface IGenericRepository<T> where T : BaseEntity,new()
    {
        IEnumerable<T> GetAll(Func<T,bool>? Condition=null);

        T? GetById(int id);

        int Add(T entity);

        int Update(T entity);
        int Delete(T entity);
    }
}
