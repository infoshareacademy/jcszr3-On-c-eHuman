using TimeTrackingSystem.Application.ViewModels.TimeSheet;

namespace TimeTrackingSystem.Application.Interfaces
{
    public interface ITimeSheetService
    {
        ListOfTimeSheetsViewModel GetAll(string Id);
        int Add(NewTimeSheetViewModel model);
        void Delete(int id);
        TimeSheetDetailsViewModel Get(int id);
        NewTimeSheetViewModel Edit(int id);
        void Update(NewTimeSheetViewModel model);
        
    }
}
