using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using TimeTrackingSystem.Application.Interfaces;
using TimeTrackingSystem.Application.ViewModels.Activity;
using TimeTrackingSystem.Domain.Interfaces;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Application.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _ActivityRepo;
        private readonly IMapper _mapper;
        public ActivityService(IActivityRepository ActivityRepo, IMapper mapper)
        {
            _ActivityRepo = ActivityRepo;
            _mapper = mapper;
        }

        public int Add(ActivityDetailsViewModel Activity)
        {
            var timeSh = _mapper.Map<Activity>(Activity);
            var id = _ActivityRepo.Add(timeSh);
            return id;
        }
        public ActivityDetailsViewModel Edit(int id)
        {
            var Activity = _ActivityRepo.Get(id);
            var ActivityVM = _mapper.Map<ActivityDetailsViewModel>(Activity);
            return ActivityVM;
        }
        public void Update(ActivityDetailsViewModel model)
        {
            var Activity = _mapper.Map<Activity>(model);
            _ActivityRepo.Update(Activity);
        }

        public ListOfActivitiesViewModel GetAll()
        {
            var Activities = _ActivityRepo.GetAll()//searching
                .ProjectTo<ActivityProjectViewModel>(_mapper.ConfigurationProvider).ToList(); //list of objects

            var employeesList = new ListOfActivitiesViewModel()
            {
                Activities = Activities,
            };
            return employeesList;
        }
        public ListOfActivitiesViewModel GetAll(int id)
        {
            var Activities = _ActivityRepo.GetAll(id)//searching
                .ProjectTo<ActivityProjectViewModel>(_mapper.ConfigurationProvider).ToList(); //list of objects

            var employeesList = new ListOfActivitiesViewModel()
            {
                Id = id,
                Activities = Activities,
            };
            return employeesList;
        }
        
        public ActivityDetailsViewModel Get(int ActivityId)
        {
            var Activity = _ActivityRepo.Get(ActivityId);
            var ActivityVM = _mapper.Map<ActivityDetailsViewModel>(Activity);
            return ActivityVM;
        }

        public void Delete(int id)
        {
            _ActivityRepo.Delete(id);
        }
    }
}
