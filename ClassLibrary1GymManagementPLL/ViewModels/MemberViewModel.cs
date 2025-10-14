using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1GymManagementPLL.ViewModels
{
        public    class  MemberViewModel
    {
        public int id { get; set; }

        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Photo { get; set; }
        public string Gender { get; set; } = null!;





    }
}
