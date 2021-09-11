using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TimeTrackingSystem.Application.Mapping;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Application.ViewModels.TimeSheet
{
    public class TimeSheetDetailsViewModel : IMapFrom<Domain.Model.TimeSheet>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time_from { get; set; }
        public DateTime Time_to { get; set; }
        public string Comments { get; set; }
        public DateTime Date_submitted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Model.TimeSheet, TimeSheetDetailsViewModel>();
        }
    }
}
