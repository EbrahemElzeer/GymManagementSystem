using AutoMapper;
using ClassLibrary1GymManagementPLL.ViewModels.SessionVM;
using GymManagementPL.Entitys;
using GymManagementSystemBLL.View_Models.SessionVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1GymManagementPLL.Mapping
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            CreateMap<Session, SessionViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.TrainerName, opt => opt.MapFrom(src => src.Trainer.Name))
                .ForMember(dest => dest.AvailableSlots, opt => opt.Ignore());
            CreateMap<CreateSessionViewModel, Session>();

            CreateMap<Session, UpdateSessionViewModel>().ReverseMap();
        }

    }
}
