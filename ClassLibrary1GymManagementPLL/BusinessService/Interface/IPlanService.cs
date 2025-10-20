using ClassLibrary1GymManagementPLL.ViewModels.PlanVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1GymManagementPLL.BusinessService.Interface
{
    public interface IPlanService
    {
        IEnumerable<PlanViewModel> GetAllPlans();
        PlanViewModel? GetPlanDetails(int id);

        PlanToUpdateViewModel ? GetPlanToUpdate(int id);

        bool UpdatePlan (int id, PlanToUpdateViewModel planToUpdateViewModel);
        bool ToggoleStatus (int id);

    }
}
