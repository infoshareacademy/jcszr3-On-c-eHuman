using AutoMapper;
using TimeTrackingSystem.Application.Mapping;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Application.ViewModels.TimeSheet
{
    public class TimeSheetAccountViewModel : IMapFrom<TimeSheetAccount>
    {
       public TimeSheetDetailsViewModel TimeSheet{ get; set; }
       public EmployeeDetailsViewModel ApplicationUser { get; set; }

       public void Mapping(Profile profile)
       {
           profile.CreateMap<TimeSheetAccount, TimeSheetAccountViewModel>();
       }
    }
}
