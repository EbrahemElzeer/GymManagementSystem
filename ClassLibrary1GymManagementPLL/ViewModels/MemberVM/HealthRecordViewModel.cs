using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1GymManagementPLL.ViewModels.MemberVM
{
    public class HealthRecordViewModel

    {
        [Required(ErrorMessage ="Height Is Required") ]
        [Range(20,300,ErrorMessage ="Height must be between 50 cm and 300 cm")]
        public decimal Height { get; set; }

        [Required(ErrorMessage = "Weight Is Required")]
        [Range(20, 500, ErrorMessage = "Weight must be between 20 kg and 500 kg")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "BloodType Is Required")]

        public string BloodType { get; set; } =null!;

        public string Note { get; set; }

    }
}
