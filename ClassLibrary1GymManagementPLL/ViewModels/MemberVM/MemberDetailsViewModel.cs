using GymManagementDAL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1GymManagementPLL.ViewModels.MemberVM
{
    public class MemberDetailsViewModel:MemberViewModel
    {
        public string  DateOfBitrh { get; set; }=null!;
        public  string Address { get; set; }=null!;

        public string MemberShipStartDate { get; set; }=null!;
        public string MemberShipEndDate { get; set; }=null!;
        public string PlanName { get; set; }=null!;
    }
}
