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
    public class GenericRepository<T>: IGenericRepository<T> where T : BaseEntity, new()

    {
        private readonly GymdbContext _dbContext;

        public GenericRepository(GymdbContext gymdbContext)
        {
            _dbContext = gymdbContext;
        }
        public int Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(T entity)
        {

            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChanges();
        }


        public IEnumerable<T> GetAll(Func<T, bool>? Condition = null)
        {
            if (Condition == null) return _dbContext.Set<T>().AsNoTracking().ToList();
            return _dbContext.Set<T>().AsNoTracking().Where(Condition).ToList();
        }

        public T? GetById(int id)=> _dbContext.Set<T>().Find(id);


        public int Update(T entity)
        {
           _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges();
        }
    }
}
