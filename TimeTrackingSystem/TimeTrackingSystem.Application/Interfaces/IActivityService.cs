using TimeTrackingSystem.Application.ViewModels.Activity;

namespace TimeTrackingSystem.Application.Interfaces
{
    public interface IActivityService
    {
        ListOfActivitiesViewModel GetAll(int Id);
        int Add(ActivityDetailsViewModel model);
        void Delete(int id);
        ActivityDetailsViewModel Get(int id);
        ActivityDetailsViewModel Edit(int id);
        void Update(ActivityDetailsViewModel model);
        
    }
}
