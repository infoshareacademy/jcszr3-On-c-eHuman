using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TimeTrackingSystem.Application.Interfaces;
using TimeTrackingSystem.Application.ViewModels.TimeSheet;
using TimeTrackingSystem.Domain.Interfaces;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Application.Services
{
    public class GenericService<T, Y> : IGenericService<T> where T: class
    where Y: class
    {
        private readonly IGenericRepository<Y> _timeSheetRepo;
        private readonly IMapper _mapper;
        public GenericService(IGenericRepository<Y> timeSheetRepo, IMapper mapper)
        {
            _timeSheetRepo = timeSheetRepo;
            _mapper = mapper;
        }

        public int Add(T timesheet)
        {
            var timeSh = _mapper.Map<Y>(timesheet);
            var id = _timeSheetRepo.Add(timeSh);
            return id;
        }
        public void AddList(List<T> timesheet)
        {
            foreach (var tm in timesheet)
            {
                var timeSh = _mapper.Map<Y>(tm);
                var id = _timeSheetRepo.Add(timeSh);
            }
        }
        public T Edit(int id)
        {
            var timesheet = _timeSheetRepo.Get(id);
            var timesheetVM = _mapper.Map<T>(timesheet);
            return timesheetVM;
        }
        public void Update(T model)
        {
            var timesheet = _mapper.Map<Y>(model);
            _timeSheetRepo.Update(timesheet);
        }

        public T Get(int timesheetId)
        {
            var timesheet = _timeSheetRepo.Get(timesheetId);
            var timesheetVM = _mapper.Map<T>(timesheet);
            return timesheetVM;
        }

        public void Delete(int id)
        {
            _timeSheetRepo.Delete(id);
        }
    }
}
