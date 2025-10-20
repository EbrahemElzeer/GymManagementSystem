using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1GymManagementPLL.ViewModels.PlanVM
{
    public class PlanToUpdateViewModel
    {
        public string Name { get; set; } = null!;
        [Required( ErrorMessage = "Description is required")]
        [StringLength(50,MinimumLength =5, ErrorMessage = "Description must be between 5 and 50 characters")]

        public string Description { get; set; } = null!;
        [Required (ErrorMessage = "DurationDays is required")]
        [Range(1,365, ErrorMessage = "DurationDays must be between 1 and 365 days")]
        public int DurationDays { get; set; }
        [Required (ErrorMessage = "Price is required")]
        [Range(0.1, 10000.00, ErrorMessage = "Price must be between 0.1 and 10000.00")]
        public decimal Price { get; set; }
        
    }
}
