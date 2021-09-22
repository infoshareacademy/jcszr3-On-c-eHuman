using TimeTrackingSystem.Application.ViewModels.TimeSheet;

namespace TimeTrackingSystem.Application.Interfaces
{
    public interface ITimeSheetService
    {
        ListOfTimeSheetsViewModel GetAll(string Id);
        int Add(TimeSheetDetailsViewModel model);
        void Delete(int id);
        TimeSheetDetailsViewModel Get(int id);
        TimeSheetDetailsViewModel Edit(int id);
        void Update(TimeSheetDetailsViewModel model);
        
    }
}
