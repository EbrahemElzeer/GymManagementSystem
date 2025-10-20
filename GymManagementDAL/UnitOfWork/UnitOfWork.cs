using GymManagementDAL.Context;
using GymManagementDAL.Repositories.Implementaion;
using GymManagementDAL.Repositories.Interface;
using GymManagementPL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type,object> _repositories = new ();
        private readonly GymdbContext _gymdbContext;

        public UnitOfWork(GymdbContext gymdbContext)
        {
            _gymdbContext = gymdbContext;
        }
        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity, new()
        {
            var entityType = typeof(TEntity);

            if(_repositories.TryGetValue(entityType,out var repository))
            {
                return (IGenericRepository<TEntity>)repository;
            }

            var newRepository = new GenericRepository<TEntity>(_gymdbContext);

            _repositories[entityType] = newRepository;
            return (IGenericRepository<TEntity>)_repositories[entityType];
        }

        public int SaveChanges()
        {
       return     _gymdbContext.SaveChanges();
        }
    }
}
