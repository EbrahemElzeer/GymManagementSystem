namespace GymManagementPL.Entitys
{
    public class Category:BaseEntity
    {
        public string CategoryName { get; set; }

        #region Relations

        public ICollection<Session> Sessions { get; set; }
        #endregion
    }
}
