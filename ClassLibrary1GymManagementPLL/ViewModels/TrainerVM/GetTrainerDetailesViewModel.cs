using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1GymManagementPLL.ViewModels.TrainerVM
{
    public class GetTrainerDetailesViewModel
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Specialization { get; set; } = null!;
        public string DateOFBirth { get; set; } = null!;
        public string Address { get; set; } = null!;

        public string? Photo { get; set; }

    }
}
