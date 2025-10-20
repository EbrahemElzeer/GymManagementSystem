using ClassLibrary1GymManagementPLL.BusinessService.Interface;
using ClassLibrary1GymManagementPLL.ViewModels.MemberVM;
using GymManagementDAL.Entitys;
using GymManagementDAL.Repositories.Implementaion;
using GymManagementDAL.Repositories.Interface;
using GymManagementDAL.UnitOfWork;
using GymManagementPL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1GymManagementPLL.BusinessService.Implementaion
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CreateMember(CreateMemberViewModel memberViewModel)
        {
            if (IsEmailExist(memberViewModel.Email) || IsPhoneExist(memberViewModel.Phone)) return false;
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
                     _unitOfWork.GetRepository<Member>().Add(member);
                return      _unitOfWork.SaveChanges()>0;
        }

        public IEnumerable<MemberViewModel> GetAllMembers()
        {
            var member = _unitOfWork.GetRepository<Member>().GetAll();

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

        public MemberDetailsViewModel? GetMemberDetails(int id)
        {
            var member = _unitOfWork.GetRepository<Member>().GetById(id);

            if (member  is null) return null;

            var MemberDetailsViewModel = new MemberDetailsViewModel
            {
               
              Name=member.Name,
              Email=member.Email,
                Phone=member.phone,
                Gender=member.Gender.ToString(),
                DateOfBitrh=member.DateOfBirth.ToShortDateString(),
                Address=$"{member.Address.BuildingNumber} , {member.Address.Street} , {member.Address.City}",
            };

            var membership=_unitOfWork.GetRepository<MemberShip>().GetAll(m=>m.Id==id&&m.Status=="Active").FirstOrDefault();
     

            if ( membership != null)
            {
               MemberDetailsViewModel.MemberShipStartDate=membership.CreatedAt.ToShortDateString();
               MemberDetailsViewModel.MemberShipEndDate=membership.EndDate.ToShortDateString();
              var plan=_unitOfWork.GetRepository<Plan>().GetById(membership.PlanId);

                MemberDetailsViewModel.PlanName=plan?.Name;

            }
            return MemberDetailsViewModel;
        }

        public UpdateMemberViewModel? GetMemberDetailsToUpdate(int id)
        {
            var member = _unitOfWork.GetRepository<Member>().GetById(id);
            if (member is null) return null;
            var UpdateMemberViewModel = new UpdateMemberViewModel
            {
                Name = member.Name,
                Phone = member.phone,
                Email = member.Email,
               BuildNumber = member.Address.BuildingNumber,
                City = member.Address.City,
                 Street = member.Address.Street,
                 photo=member.Photo
            };
            return UpdateMemberViewModel;
        }

        public HealthRecordViewModel? GetMemberHealthRecord(int id)
        {
            var HealthRecord = _unitOfWork.GetRepository<HealthRecord>().GetById(id);
            if(HealthRecord is null) return null;   


            var HealthRecordviewmodel = new HealthRecordViewModel
            {
                Height = HealthRecord.Height,
                Weight = HealthRecord.weight,
                BloodType = HealthRecord.BloodType,
                Note = HealthRecord.Note
            };
            return HealthRecordviewmodel;
        }

        public bool RemoveMemeer(int id)
        {
            try
            {
                var member = _unitOfWork.GetRepository<Member>().GetById(id);
                if (member is null) return false;

                var hasActiveMembership = _unitOfWork.GetRepository<MemberSession>().GetAll(ms => ms.MemberId == id).Select(x => x.SessionId);
                var hasSession = _unitOfWork.GetRepository<Session>().GetAll(s => hasActiveMembership.Contains(s.Id) && s.StartTime > DateTime.Now).Any();
                if (hasSession) return false;

                var membership = _unitOfWork.GetRepository<MemberShip>().GetAll(m => m.memberId == id);
                if (membership != null && membership.Any())
                {
                    foreach (var mem in membership)
                    {
                        _unitOfWork.GetRepository<MemberShip>().Delete(mem);
                    }
                }



                 _unitOfWork.GetRepository<Member>().Delete(member) ;
                return _unitOfWork.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateMember(int id, UpdateMemberViewModel updateMemberViewModel)
        {
            try
            {
               
                if (IsEmailExist(updateMemberViewModel.Email) || IsPhoneExist(updateMemberViewModel.Phone)) return false;

                var member = _unitOfWork.GetRepository<Member>().GetById(id);
                if (member is null) return false;


                member.Email = updateMemberViewModel.Email;
                member.phone = updateMemberViewModel.Phone;

                member.Address.BuildingNumber = updateMemberViewModel.BuildNumber;
                member.Address.City = updateMemberViewModel.City;
                member.Address.Street = updateMemberViewModel.Street;
                member.UpdatedAt = DateTime.Now;
                 _unitOfWork.GetRepository<Member>().Update(member);
                return _unitOfWork.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        #region Helper Method
        private bool IsEmailExist(string email)
        {
            return _unitOfWork.GetRepository<Member>().GetAll(m => m.Email == email).Any();
        }

        private bool IsPhoneExist(string phone)
        {
            return _unitOfWork.GetRepository<Member>().GetAll(m => m.phone == phone).Any();
        }
        #endregion





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