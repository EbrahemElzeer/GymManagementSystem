using ClassLibrary1GymManagementPLL.BusinessService.Interface;
using ClassLibrary1GymManagementPLL.ViewModels;
using GymManagementDAL.Repositories.Implementaion;
using GymManagementDAL.Repositories.Interface;
using GymManagementPL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1GymManagementPLL.BusinessService.Implementaion
{
    public class MemberService : IMemberService
    {
        private readonly IGenericRepository<Member> _MemberRepository;

        public MemberService(IGenericRepository<Member> MemberRepository)
        {
            _MemberRepository = MemberRepository;
        }

        public bool CreateMember(CreateMemberViewModel memberViewModel)
        {
            var EmilExists = _MemberRepository.GetAll(m => m.Email == memberViewModel.Email).Any();
            var phoneExists = _MemberRepository.GetAll(m => m.phone == memberViewModel.Phone).Any();
            if (phoneExists|EmilExists) return false;
            var member = new Member
            {
                phone = memberViewModel.Phone,
                Email = memberViewModel.Email,
                Name = memberViewModel.Name,
                DateOfBirth = memberViewModel.DateOfBirth,
                Gender = memberViewModel.Gender,
                Address = new Address
                {
                    City = memberViewModel.City,
                    Street = memberViewModel.Street,
                    BuildingNumber = memberViewModel.BuildNumber,
                },
                HealthRecord=new HealthRecord
                {
                    Height=memberViewModel.HealthRecordViewModel.Height,
                    weight=memberViewModel.HealthRecordViewModel.Weight,
                    BloodType=memberViewModel.HealthRecordViewModel.BloodType,
                    Note=memberViewModel.HealthRecordViewModel.Note
                }


            };
                     return  _MemberRepository.Add(member)>0;
        }

        public IEnumerable<MemberViewModel> GetAllMembers()
        {
            var member = _MemberRepository.GetAll();

            if(member == null || !member.Any()) return Array.Empty<MemberViewModel>();

            var memberviewModel = member.Select(m => new MemberViewModel
            {
                id = m.Id,
                Name = m.Name,
                Phone = m.phone,
                Email = m.Email,
                Photo = m.Photo,
                Gender = m.Gender.ToString()


            });
            return memberviewModel;

        }
        //public IEnumerable<MemberViewModel> GetAllMembers()
        //{
        //    var members = _MemberRepository.GetAll();

        //    if (members == null || !members.Any()) return [];

        //    var ListMember = new List<MemberViewModel>();


        //    foreach (var member in members)
        //    {
        //        var MemberviewModel = new MemberViewModel
        //        {

        //            id = member.Id,
        //            Name = member.Name,
        //            Phone = member.phone,
        //            Email = member.Email,
        //            Photo = member.Photo,
        //            Gender = member.Gender.ToString()



        //        };
        //        ListMember.Add(MemberviewModel);

        //    }
        //    return ListMember;
        //}



    }
}