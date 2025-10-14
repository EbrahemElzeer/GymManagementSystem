using GymManagementPL.Entitys.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1GymManagementPLL.ViewModels
{
    public class CreateMemberViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50,MinimumLength =2,ErrorMessage ="Name must be between 2 and 50 characters")]
        [RegularExpression(@"^[a-zA-Z]\s+$", ErrorMessage = "Name can only contain letters and spaces")]
        public string Name { get; set; }= null!;

        [Required(ErrorMessage =" Email is required")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        [DataType(DataType.EmailAddress)]
        [StringLength(100,MinimumLength =5,ErrorMessage ="Email must be between 5 and 100 characters")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage ="Phone number is required")]
        [Phone(ErrorMessage ="Invalid Phone Number")]
        [RegularExpression(@"^(010|011\015)\d{8}$", ErrorMessage = "Phone number must start with 010, 011, or 015 and be 11 digits long")]
        public string Phone { get; set; }= null!;

        [Required (ErrorMessage ="Date of Birth is required")]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }

        [Required (ErrorMessage= "Gender is Required")]

        public Gender Gender { get; set; }

        [Required(ErrorMessage = "BuildNumber Type is required")]
        public int BuildNumber { get; set; }

        [Required (ErrorMessage = "City is required")]
        [StringLength(30,MinimumLength =5,ErrorMessage ="City must be between 5 and 30 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "City can only contain letters and spaces")]
        public string City { get; set; } = null!;

        [Required (ErrorMessage = "Street is required")]
        public string Street { get; set; } = null!;

        [Required (ErrorMessage = "HealthRecord is required")]
        public HealthRecordViewModel HealthRecordViewModel { get; set; } = null!;
    }
}
