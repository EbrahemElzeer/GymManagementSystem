using ClassLibrary1GymManagementPLL.ViewModels.SessionVM;
using GymManagementSystemBLL.View_Models.SessionVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1GymManagementPLL.BusinessService.Interface
{
    public interface ISessionService
    {
        IEnumerable<SessionViewModel> GetAllSessions();

        SessionViewModel? GetSessionDetails(int id);
      bool CreateSession(CreateSessionViewModel CreateSessionViewModel);
        UpdateSessionViewModel? GetSessionDetailsToUpdate(int id);
        bool UpdateSession(int id ,UpdateSessionViewModel UpdateSessionViewModel);  
        bool RemoveSession(int id);


    }
}
