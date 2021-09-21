using AutoMapper;
using TimeTrackingSystem.Application.Mapping;
using TimeTrackingSystem.Application.ViewModels.Project;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Application.ViewModels.Activity
{
    public class ActivityProjectViewModel : IMapFrom<ActivityProject>
    {
       public ActivityDetailsViewModel Activity{ get; set; }
       public ProjectDetailsViewModel Project { get; set; }

       public void Mapping(Profile profile)
       {
           profile.CreateMap<ActivityProject, ActivityProjectViewModel>();
       }
    }
}
