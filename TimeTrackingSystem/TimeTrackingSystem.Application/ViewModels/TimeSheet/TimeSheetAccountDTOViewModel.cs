using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TimeTrackingSystem.Application.Mapping;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Application.ViewModels.TimeSheet
{
    public class TimeSheetAccountDTOViewModel : IMapFrom<TimeSheetAccountDTO>
    {
       public TimeSheetDetailsViewModel TimeSheet{ get; set; }
       public EmployeeDetailsViewModel Employee { get; set; }

       public void Mapping(Profile profile)
       {
           profile.CreateMap<TimeSheetAccountDTO, TimeSheetAccountDTOViewModel>();
       }
    }
}
