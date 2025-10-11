using GymManagementDAL.Entitys;

namespace GymManagementPL.Entitys
{
    public class Plan:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DurationDays { get; set; }
        
        public bool IsActive { get; set; }


        #region RelationsShips
        #region PlanHasMemberShips

        public ICollection<MemberShip> MemberShips { get; set; }

        #endregion
        #endregion
    }
}
