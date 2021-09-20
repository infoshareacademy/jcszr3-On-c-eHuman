using AutoMapper;
using TimeTrackingSystem.Application.Mapping;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Application.ViewModels.Project
{
    public class ProjectAccountViewModel : IMapFrom<ProjectAccount>
    {
       public ProjectDetailsViewModel Project{ get; set; }
       public EmployeeDetailsViewModel ApplicationUser { get; set; }

       public void Mapping(Profile profile)
       {
           profile.CreateMap<ProjectAccount, ProjectAccountViewModel>();
       }
    }
}
