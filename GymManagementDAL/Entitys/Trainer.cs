using GymManagementPL.Entitys.Enums;

namespace GymManagementPL.Entitys
{
    public class Trainer:GymUser
    {
        //hireDate==CreatedAt
        public Specialities Speciality { get; set; }
        public Address Address { get; set; }

        #region Relation trainer-session

        public ICollection<Session> Sessions { get; set; }
        #endregion
    }
}
