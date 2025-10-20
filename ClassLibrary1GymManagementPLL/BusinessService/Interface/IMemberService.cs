using ClassLibrary1GymManagementPLL.ViewModels.MemberVM;
using GymManagementPL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1GymManagementPLL.BusinessService.Interface
{
    public interface IMemberService
    {
        IEnumerable<MemberViewModel> GetAllMembers();

        bool CreateMember(CreateMemberViewModel memberViewModel);

        MemberDetailsViewModel?  GetMemberDetails (int id);

        //Member? GetMemberById(int id);
        HealthRecordViewModel? GetMemberHealthRecord(int id);

        UpdateMemberViewModel? GetMemberDetailsToUpdate(int id);

        bool UpdateMember(int id, UpdateMemberViewModel updateMemberViewModel);

        bool RemoveMemeer(int id);  


        //Member Up
    }
}
