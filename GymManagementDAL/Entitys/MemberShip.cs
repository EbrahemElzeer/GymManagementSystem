using GymManagementPL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entitys
{
    public class MemberShip:BaseEntity
    {
        public int memberId { get; set; }   
        public Member Member { get; set; }

        public int PlanId { get; set; }
        public Plan Plan { get; set; }

        public DateTime EndDate { get; set; }

        public string Status { get {

                if(DateTime.Now > EndDate) return "Expired";
                else return "Active";   

            } }
    }
}
