using GymManagementDAL.Entitys;

namespace GymManagementPL.Entitys
{
    public class Member:GymUser
    {
        //joinDate=-CreatedAt

        public string Photo  { get; set; }


        #region Member has health

        public HealthRecord HealthRecord { get; set; }
        #endregion

        #region MemberHasMemberShips
         public ICollection<MemberShip> MemberShips { get; set; }
        #endregion

        #region MemberHasMemberSeccion
        public ICollection<MemberSession> memberSessions { get; set; }
        #endregion
    }
}
