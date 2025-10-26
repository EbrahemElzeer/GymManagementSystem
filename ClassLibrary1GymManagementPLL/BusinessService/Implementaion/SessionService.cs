using AutoMapper;
using ClassLibrary1GymManagementPLL.BusinessService.Interface;
using ClassLibrary1GymManagementPLL.ViewModels.SessionVM;
using GymManagementDAL.UnitOfWork;
using GymManagementPL.Entitys;
using GymManagementSystemBLL.View_Models.SessionVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1GymManagementPLL.BusinessService.Implementaion
{
    public class SessionService : ISessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SessionService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool CreateSession(CreateSessionViewModel CreateSessionViewModel)
        {
           if(CreateSessionViewModel == null) return false;

             if(!isTainerExist(CreateSessionViewModel.TrainerId) || !isCategoryExist(CreateSessionViewModel.CategoryId)||isdateTimeValid(CreateSessionViewModel.StartDate,CreateSessionViewModel.EndDate))
                 return false;
             if(CreateSessionViewModel.Capacity>25||CreateSessionViewModel.Capacity <= 0)
                 return false;
            try
            {
                var sessionToCreate = _mapper.Map<CreateSessionViewModel, Session>(CreateSessionViewModel);
                sessionToCreate.CreatedAt = DateTime.Now;
                _unitOfWork.GetRepository<Session>().Add(sessionToCreate);
                return _unitOfWork.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public IEnumerable<SessionViewModel> GetAllSessions()
        {
            var Session = _unitOfWork.SessionsRepositiry.GetAllWithCategoryAndTrainer();

            if(Session == null || !Session.Any())
                return Enumerable.Empty<SessionViewModel>();
            var sessionMapped = _mapper.Map<IEnumerable<Session>, IEnumerable<SessionViewModel>>(Session);
            foreach (var Item in sessionMapped)
            {
                Item.AvailableSlots = Item.Capacity - _unitOfWork.SessionsRepositiry.GetCountOfBookedSlots(Item.Id);
            }
            return sessionMapped;
        }

        public SessionViewModel? GetSessionDetails(int id)
        {
          if(id == 0) return null;
          var session=_unitOfWork.SessionsRepositiry.GetByIdCategoryAndTrainer(id);
            if(session == null) return null;
            var sessionMapped = _mapper.Map<Session, SessionViewModel>(session);

            sessionMapped.AvailableSlots = session.Capacity - _unitOfWork.SessionsRepositiry.GetCountOfBookedSlots(session.Id);

            return sessionMapped;
        }


        public UpdateSessionViewModel? GetSessionDetailsToUpdate(int id)
        {
           
            var session = _unitOfWork.GetRepository<Session>().GetById(id);
           if(!isSessionAvailable(session!)) return null;
            return _mapper.Map<Session, UpdateSessionViewModel>(session);
        }



        public bool UpdateSession(int id, UpdateSessionViewModel UpdateSessionViewModel)
        {
            var session = _unitOfWork.GetRepository<Session>().GetById(id);
            if(!isSessionAvailable(session!)) return false;

            if (!isTainerExist(UpdateSessionViewModel.TrainerId) ||  isdateTimeValid(UpdateSessionViewModel.StartDate, UpdateSessionViewModel.EndDate))
                return false;
            _mapper.Map(UpdateSessionViewModel, session);
            session!.UpdatedAt = DateTime.Now;
            try
            {
                _unitOfWork.GetRepository<Session>().Update(session);
                return _unitOfWork.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }


        }


        public bool RemoveSession(int id)
        {
           var session =_unitOfWork.GetRepository<Session>().GetById(id);
            if(!isSessionAvailableForRemove(session!)) return false;
            try
            {
                _unitOfWork.GetRepository<Session>().Delete(session!);
                return _unitOfWork.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }


        #region Helper
        private bool isTainerExist(int trainerId)
        {
            var trainer = _unitOfWork.GetRepository<Trainer>().GetById(trainerId);
            return trainer != null;
        }

        private bool isCategoryExist(int categoryId)
        {
            var category = _unitOfWork.GetRepository<Category>().GetById(categoryId);
            return category != null;
        }

        private bool isdateTimeValid(DateTime stratdate ,DateTime endDate)
        {
            return stratdate < endDate;
        }

     
        private bool isSessionAvailable(Session session)
        {
            if (session == null) return false;
           if(session.EndDate<DateTime.Now||session.StartDate< DateTime.Now)
                return false;
         var hasActiveBooking= _unitOfWork.SessionsRepositiry.GetCountOfBookedSlots(session.Id)>0;
            if (hasActiveBooking)
                return false;
            return true;
        }

        private bool isSessionAvailableForRemove(Session session)
        {
            if (session == null) return false;
            if (session.EndDate < DateTime.Now&&session.EndDate>DateTime.Now || session.StartDate > DateTime.Now)
                return false;
            var hasActiveBooking = _unitOfWork.SessionsRepositiry.GetCountOfBookedSlots(session.Id) > 0;
            if (hasActiveBooking)
                return false;
            return true;
        }

        #endregion
    }
}
