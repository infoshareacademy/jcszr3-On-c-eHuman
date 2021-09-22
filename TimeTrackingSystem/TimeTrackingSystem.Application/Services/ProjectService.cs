using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using TimeTrackingSystem.Application.Interfaces;
using TimeTrackingSystem.Application.ViewModels.Project;
using TimeTrackingSystem.Domain.Interfaces;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepo;
        private readonly IMapper _mapper;
        public ProjectService(IProjectRepository ProjectRepo, IMapper mapper)
        {
            _projectRepo = ProjectRepo;
            _mapper = mapper;
        }

        public int Add(ProjectDetailsViewModel Project)
        {
            var timeSh = _mapper.Map<Project>(Project);
            var id = _projectRepo.Add(timeSh);
            return id;
        }
        public ProjectDetailsViewModel Edit(int id)
        {
            var Project = _projectRepo.Get(id);
            var ProjectVM = _mapper.Map<ProjectDetailsViewModel>(Project);
            return ProjectVM;
        }
        public void Update(ProjectDetailsViewModel model)
        {
            var Project = _mapper.Map<Project>(model);
            _projectRepo.Update(Project);
        }

        public ListOfProjectsViewModel GetAll(string Id)
        {
            var Projects = _projectRepo.GetAll(Id)//searching
                .ProjectTo<ProjectAccountViewModel>(_mapper.ConfigurationProvider).ToList(); //list of objects

            var employeesList = new ListOfProjectsViewModel()
            {
                Projects = Projects,
            };
            return employeesList;
        }
        
        public ProjectDetailsViewModel Get(int ProjectId)
        {
            var project = _projectRepo.Get(ProjectId);
            var projectVM = _mapper.Map<ProjectDetailsViewModel>(project);
            return projectVM;
        }

        public void Delete(int id)
        {
            _projectRepo.Delete(id);
        }
    }
}
