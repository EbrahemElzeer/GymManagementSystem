using GymManagementPL.Entitys.Enums;
using Microsoft.EntityFrameworkCore;

namespace GymManagementPL.Entitys
{
    public  abstract class GymUser: BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string phone { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public Address Address { get; set; }
    }

    [Owned]
   public  class Address
    {

        public string Street { get; set; }
        public string City { get; set; }
        public int BuildingNumber { get; set; }
       
    }
}
