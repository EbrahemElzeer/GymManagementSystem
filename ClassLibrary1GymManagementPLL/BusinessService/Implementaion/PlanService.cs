using ClassLibrary1GymManagementPLL.BusinessService.Interface;
using ClassLibrary1GymManagementPLL.ViewModels.PlanVM;
using GymManagementDAL.Entitys;
using GymManagementDAL.UnitOfWork;
using GymManagementPL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1GymManagementPLL.BusinessService.Implementaion
{
    public class PlanService : IPlanService
    {
        private readonly IUnitOfWork _unitOfWor;

        public PlanService(IUnitOfWork unitOfWor)
        {
            _unitOfWor = unitOfWor;
        }
        public IEnumerable<PlanViewModel> GetAllPlans()
        {
          var plan=  _unitOfWor.GetRepository<Plan>().GetAll();
            if(plan is null || !plan.Any()) return [];  
            return plan.Select(p=> new PlanViewModel
            {
                id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                DurationDays = p.DurationDays,
                IsActive= p.IsActive
            });
        }

        public PlanViewModel? GetPlanDetails(int id)
        {
            var plan= _unitOfWor.GetRepository<Plan>().GetById(id);
            if(plan is null) return null;
            return new PlanViewModel
            {
                id = plan.Id,
                Name = plan.Name,
                Description = plan.Description,
                Price = plan.Price,
                DurationDays = plan.DurationDays,
                IsActive= plan.IsActive
            };

        }

        public PlanToUpdateViewModel? GetPlanToUpdate(int id)
        {
           
            var plan= _unitOfWor.GetRepository<Plan>().GetById(id);
            if(plan is null || plan.IsActive==false||HasActiveMemberships(id)) return null;
            return new PlanToUpdateViewModel
            {
                Name = plan.Name,
                Description = plan.Description,
                Price = plan.Price,
                DurationDays = plan.DurationDays
            };
        }

        public bool ToggoleStatus(int id)
        {
            var plan=_unitOfWor.GetRepository<Plan>().GetById(id);
            if(plan is null || !HasActiveMemberships(id) ) return false;
            plan.IsActive= !plan.IsActive==true? false:true;
            plan.UpdatedAt= DateTime.UtcNow;
            _unitOfWor.GetRepository<Plan>().Update(plan);
            return _unitOfWor.SaveChanges() > 0;
        }

        public bool UpdatePlan(int id, PlanToUpdateViewModel planToUpdateViewModel)
        {
            var plan= _unitOfWor.GetRepository<Plan>().GetById(id);
            if(plan is null || planToUpdateViewModel is null) return false;
          
            plan.Description= planToUpdateViewModel.Description;
            plan.Price= planToUpdateViewModel.Price;
            plan.DurationDays= planToUpdateViewModel.DurationDays;
            plan.UpdatedAt= DateTime.UtcNow;
            try
            {
                _unitOfWor.GetRepository<Plan>().Update(plan);
                return _unitOfWor.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }



        #region Helper

        private bool HasActiveMemberships(int planId)
        {
            var ActiveMemberships = _unitOfWor.GetRepository<MemberShip>().GetAll(m => m.PlanId == planId && m.Status=="Active");
            return   ActiveMemberships.Any();
        }
        #endregion
    }
}
