namespace GymManagementPL.Entitys
{
    public class HealthRecord: BaseEntity
    {
        public decimal weight { get; set; }
        public decimal Height { get; set; }

        public string BloodType { get; set; }
        public string Note { get; set; }

        // lastupdate  == UpdatedAt

      
    }
}
