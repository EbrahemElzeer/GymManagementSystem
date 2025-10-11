using GymManagementDAL.Entitys;

namespace GymManagementPL.Entitys
{
    public class Session:BaseEntity
    {
        public string Description { get; set; }
        public int Capacity { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        #region RelationsShips
        #region Relation session-Category

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        #endregion


        #region relation session-trainer


        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
        #endregion

        #region Relation session-MemberSession

        public ICollection<MemberSession>  memberSessions { get; set; }
        #endregion
        #endregion

    }
}
