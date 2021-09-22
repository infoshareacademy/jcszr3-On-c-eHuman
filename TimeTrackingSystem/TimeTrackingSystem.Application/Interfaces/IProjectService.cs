using TimeTrackingSystem.Application.ViewModels.Project;

namespace TimeTrackingSystem.Application.Interfaces
{
    public interface IProjectService
    {
        ListOfProjectsViewModel GetAll(string Id);
        int Add(ProjectDetailsViewModel model);
        void Delete(int id);
        ProjectDetailsViewModel Get(int id);
        ProjectDetailsViewModel Edit(int id);
        void Update(ProjectDetailsViewModel model);
        
    }
}
