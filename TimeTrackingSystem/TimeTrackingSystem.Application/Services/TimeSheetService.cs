using System;
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
    public class TimeSheetService : GenericService<TimeSheetDetailsViewModel, TimeSheet>, ITimeSheetService
    {
        private readonly ITimeSheetRepository _timeSheetRepo;
        private readonly IMapper _mapper;
        public TimeSheetService(ITimeSheetRepository timeSheetRepo, IMapper mapper ) : base(timeSheetRepo, mapper)
        {
            _timeSheetRepo = timeSheetRepo;
            _mapper = mapper;
        }

        public ListOfTimeSheetsViewModel GetAll(string Id)
        {
            var timesheets = _timeSheetRepo.GetAll().Where(x=>x.ApplicationUser.Id == Id)//searching
                .ProjectTo<TimeSheetAccountViewModel>(_mapper.ConfigurationProvider).ToList(); //list of objects
            
            var employeesList = new ListOfTimeSheetsViewModel()
            {
                TimeSheets = timesheets,
            };
            return employeesList;
        }

        //public ILookup<DateTime, TimeSheetDetailsViewModel> GetAllForCallendar()
        //{
        //    var timeToRemap = _timeSheetRepo.GetAll();

        //    //.ProjectTo<TimeSheetDetailsViewModel>(_mapper.ConfigurationProvider).ToList(); //list of objects
        //    foreach (IGrouping<DateTime, TimeSheet> product in timeSheets)
        //    {
        //        var data = product.Key;
        //        foreach (TimeSheet p in product)
        //        {
        //            p.
        //        }
        //    }

        //    return timeSheets;
        //}

        public ILookup<string, TimeSheetAccountViewModel> GetAllForCallendar()
        {
            var timeToRemap = _timeSheetRepo.GetAll()
            .ProjectTo<TimeSheetAccountViewModel>(_mapper.ConfigurationProvider).ToList(); //list of objects
            var timesheetLookUp = timeToRemap.ToLookup(x => x.TimeSheet.ApplicationUserId);

               // .ToLookup(j => j.ApplicationUserId
               return timesheetLookUp;
        }
    }
}
