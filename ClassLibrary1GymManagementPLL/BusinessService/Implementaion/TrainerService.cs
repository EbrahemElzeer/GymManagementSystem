using ClassLibrary1GymManagementPLL.BusinessService.Interface;
using ClassLibrary1GymManagementPLL.ViewModels.TrainerVM;
using GymManagementDAL.UnitOfWork;
using GymManagementPL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1GymManagementPLL.BusinessService.Implementaion
{
    public class TrainerService : ITrainerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CreateTrainer(TranierCreateViewModel trainerCreateViewModel)
        {
            if(IsEmailExist(trainerCreateViewModel.Email) || IsPhoneExist(trainerCreateViewModel.Phone)) return false;

            var trainer = new Trainer
            {
                Name = trainerCreateViewModel.Name,
                Email = trainerCreateViewModel.Email,
                phone = trainerCreateViewModel.Phone,
                Speciality = trainerCreateViewModel.Speciality,
                DateOfBirth = trainerCreateViewModel.DateOfBirth,
                Address = new Address
                {
                    City = trainerCreateViewModel.City,
                    Street = trainerCreateViewModel.Street,
                    BuildingNumber = trainerCreateViewModel.BuildNumber
                }
            };
            try
            {
                _unitOfWork.GetRepository<Trainer>().Add(trainer);
                return _unitOfWork.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<TrainerViewModel> GetAllTrainers()
        {
            var trainers= _unitOfWork.GetRepository<Trainer>().GetAll;

            if (trainers == null) return [];

            var trainerVMs = trainers().Select(t => new TrainerViewModel
            {
                Name = t.Name,
                Email = t.Email,
                phone = t.phone,
                Specialities = t.Speciality.ToString()
            });

            return trainerVMs;
        }

        public GetTrainerDetailesViewModel? GetTrainerDetails(int id)
        {
           if(id <= 0) return null;
            var trainer = _unitOfWork.GetRepository<Trainer>().GetById(id);
            if (trainer == null) return null;
            var trainerDetailsVM = new GetTrainerDetailesViewModel
            {
                Name = trainer.Name,
                Email = trainer.Email,
                Phone = trainer.phone,
                Specialization = trainer.Speciality.ToString(),
                DateOFBirth = trainer.DateOfBirth.ToString("yyyy-MM-dd"),
                Address = $"{trainer.Address.BuildingNumber}, {trainer.Address.Street}, {trainer.Address.City}",
                Photo = trainer.Photo
            };
            return trainerDetailsVM;
        }



        public TranierCreateViewModel? GetDataToUpdate(int TrainerId)
        {
            var trainerData = _unitOfWork.GetRepository<Trainer>().GetById(TrainerId);
            if (trainerData is null) return null;

            return new TranierCreateViewModel()
            {
                Name = trainerData.Name,
                Email = trainerData.Email,
                Phone = trainerData.phone,
                BuildNumber = trainerData.Address.BuildingNumber,
                Street = trainerData.Address.Street,
                City = trainerData.Address.City,
                Speciality = trainerData.Speciality,

            };
        }


        public bool UpdateTrainerData(int TrainerId, TranierCreateViewModel updateTrainerData)
        {
            var EmailExists = _unitOfWork.GetRepository<Trainer>().GetAll(t => t.Email == updateTrainerData.Email && t.Id != TrainerId).Any();
            var phoneExists=_unitOfWork.GetRepository<Trainer>().GetAll(t=>t.phone==updateTrainerData.Phone&&t.Id != TrainerId).Any();
            if (EmailExists || phoneExists) return false;
            var Trainer = _unitOfWork.GetRepository<Trainer>().GetById(TrainerId);
            if (Trainer is null) return false;

            Trainer.Name = updateTrainerData.Name;
            Trainer.Email = updateTrainerData.Email;
            Trainer.phone = updateTrainerData.Phone;
            Trainer.Address.BuildingNumber = updateTrainerData.BuildNumber;
            Trainer.Address.Street = updateTrainerData.Street;
            Trainer.Address.City = updateTrainerData.City;
            Trainer.Speciality = updateTrainerData.Speciality;
            Trainer.UpdatedAt = DateTime.Now;

            try
            {
                _unitOfWork.GetRepository<Trainer>().Update(Trainer);
                return _unitOfWork.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteTrainer(int TrainerId)
        {
           
            if(TrainerId <= 0) return false;
            var trainer = _unitOfWork.GetRepository<Trainer>().GetById(TrainerId);
            if (trainer == null) return false;
            var session=_unitOfWork.GetRepository<Session>().GetAll(s=>s.TrainerId== TrainerId);

            if(session.Any()) return false;
            try
            {
                _unitOfWork.GetRepository<Trainer>().Delete(trainer);
                return _unitOfWork.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }



        #region Helper


        private bool IsEmailExist(string email)
        {
          return  _unitOfWork.GetRepository<Trainer>().GetAll(t => t.Email == email).Any();
           
        }

        private bool IsPhoneExist(string phone)
        {
           return  _unitOfWork.GetRepository<Trainer>().GetAll(t => t.phone == phone).Any();
        }

        public GetTrainerDetailesViewModel? GetTrainerData(int TrainerId)
        {
            throw new NotImplementedException();
        }

      

        #endregion

    }
}
