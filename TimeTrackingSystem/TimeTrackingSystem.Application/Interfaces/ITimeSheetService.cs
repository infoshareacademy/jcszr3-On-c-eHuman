using System;
using System.Collections.Generic;
using System.Linq;
using TimeTrackingSystem.Application.ViewModels.TimeSheet;

namespace TimeTrackingSystem.Application.Interfaces
{
    public interface ITimeSheetService : IGenericService<TimeSheetDetailsViewModel>
    {
        ListOfTimeSheetsViewModel GetAll(string Id);
        ILookup<string, TimeSheetAccountViewModel> GetAllForCallendar();

    }
}
