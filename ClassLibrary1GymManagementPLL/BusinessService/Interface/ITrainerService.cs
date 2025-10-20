using ClassLibrary1GymManagementPLL.ViewModels.PlanVM.TrainerVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1GymManagementPLL.BusinessService.Interface
{
    public interface ITrainerService
    {
        IEnumerable<TrainerViewModel> GetAllTrainers();
        bool CreateTrainer(TranierCreateViewModel trainerCreateViewModel);

        GetTrainerDetailesViewModel? GetTrainerDetails(int id);


        GetTrainerDetailesViewModel? GetTrainerData(int TrainerId);

        TranierCreateViewModel? GetDataToUpdate(int TrainerId);

        bool UpdateTrainerData(int TrainerId, TranierCreateViewModel updateTrainerData);

        bool DeleteTrainer(int TrainerId);

    }
}
