using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TimeTrackingSystem.Application.Interfaces;
using TimeTrackingSystem.Application.ViewModels;
using TimeTrackingSystem.Application.ViewModels.TimeSheet;
using TimeTrackingSystem.Domain.Interfaces;

namespace TimeTrackingSystem.Application.Services
{
    public class TimeSheetService : ITimeSheetService
    {
        private readonly ITimeSheetRepository _timeSheetRepo;
        private readonly IMapper _mapper;
        public TimeSheetService(ITimeSheetRepository timeSheetRepo, IMapper mapper)
        {
            _timeSheetRepo = timeSheetRepo;
            _mapper = mapper;
        }

        public int AddTimeSheet(NewTimeSheetViewModel model)
        {
            throw new NotImplementedException();
        }

        public ListOfTimeSheetsViewModel GetAllTimeSheets()
        {
            throw new NotImplementedException();
        }

        public TimeSheetDetailsViewModel GetTimeSheetDetails(int timesheetId)
        {
            var timesheet = _timeSheetRepo.GetTimeSheetById(timesheetId);
            var timesheetVM = _mapper.Map<TimeSheetDetailsViewModel>(timesheet);
            throw new NotImplementedException();
        }

        public int RemoveTimeSheet(TimeSheetDetailsViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
