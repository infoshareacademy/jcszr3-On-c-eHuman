using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using TimeTrackingSystem.Application.Interfaces;
using TimeTrackingSystem.Application.ViewModels.TimeSheet;
using TimeTrackingSystem.Domain.Interfaces;
using TimeTrackingSystem.Domain.Model;

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

        public int Add(TimeSheetDetailsViewModel timesheet)
        {
            var timeSh = _mapper.Map<TimeSheet>(timesheet);
            var id = _timeSheetRepo.Add(timeSh);
            return id;
        }
        public void AddList(List<TimeSheetDetailsViewModel> timesheet)
        {
            foreach (var tm in timesheet)
            {
                var timeSh = _mapper.Map<TimeSheet>(tm);
                var id = _timeSheetRepo.Add(timeSh);
            }
        }
        public TimeSheetDetailsViewModel Edit(int id)
        {
            var timesheet = _timeSheetRepo.Get(id);
            var timesheetVM = _mapper.Map<TimeSheetDetailsViewModel>(timesheet);
            return timesheetVM;
        }
        public void Update(TimeSheetDetailsViewModel model)
        {
            var timesheet = _mapper.Map<TimeSheet>(model);
            _timeSheetRepo.Update(timesheet);
        }

        public ListOfTimeSheetsViewModel GetAll(string Id)
        {
            var timesheets = _timeSheetRepo.GetAll(Id)//searching
                .ProjectTo<TimeSheetAccountViewModel>(_mapper.ConfigurationProvider).ToList(); //list of objects

            var employeesList = new ListOfTimeSheetsViewModel()
            {
                TimeSheets = timesheets,
            };
            return employeesList;
        }
        
        public TimeSheetDetailsViewModel Get(int timesheetId)
        {
            var timesheet = _timeSheetRepo.Get(timesheetId);
            var timesheetVM = _mapper.Map<TimeSheetDetailsViewModel>(timesheet);
            return timesheetVM;
        }

        public void Delete(int id)
        {
            _timeSheetRepo.Delete(id);
        }
    }
}
