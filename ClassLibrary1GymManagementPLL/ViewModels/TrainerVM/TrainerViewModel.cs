using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1GymManagementPLL.ViewModels.TrainerVM
{
    public class TrainerViewModel
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string phone { get; set; }

        public string Specialities { get; set; }
    }
}
