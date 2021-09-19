using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using TimeTrackingSystem.Application.Interfaces;
using TimeTrackingSystem.Application.ViewModels;
using TimeTrackingSystem.Application.ViewModels.TimeSheet;
using TimeTrackingSystem.Domain.Interfaces;
using TimeTrackingSystem.Domain.Model;
using TimeTrackingSystem.Infrastructure.Repositories;

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

        public int AddTimeSheet(NewTimeSheetViewModel timesheet)
        {
            var timeSh = _mapper.Map<TimeSheet>(timesheet);
            var id = _timeSheetRepo.AddTimeSheet(timeSh);
            return id;
        }
        public NewTimeSheetViewModel TimeSheetForEdit(int id)
        {
            var timesheet = _timeSheetRepo.GetTimeSheetDetails(id);
            var timesheetVM = _mapper.Map<NewTimeSheetViewModel>(timesheet);
            return timesheetVM;
        }
        public void UpdateTimeSheet(NewTimeSheetViewModel model)
        {
            var timesheet = _mapper.Map<TimeSheet>(model);
            _timeSheetRepo.UpdateTimeSheet(timesheet);
        }

        public ListOfTimeSheetsViewModel GetAllTimeSheets(string Id)
        {
            var timesheets = _timeSheetRepo.GetAllTimeSheets(Id)//searching
                .ProjectTo<TimeSheetAccountDTOViewModel>(_mapper.ConfigurationProvider).ToList(); //list of objects

            var employeesList = new ListOfTimeSheetsViewModel()
            {
                TimeSheets = timesheets,
            };
            return employeesList;
        }

        public TimeSheetDetailsViewModel GetTimeSheetDetails(int timesheetId)
        {
            var timesheet = _timeSheetRepo.GetTimeSheetDetails(timesheetId);
            var timesheetVM = _mapper.Map<TimeSheetDetailsViewModel>(timesheet);
            return timesheetVM;
        }

        public void RemoveTimeSheet(int id)
        {
            _timeSheetRepo.DeleteTimeSheet(id);
        }
    }
}
