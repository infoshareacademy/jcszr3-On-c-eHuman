using System.Linq;
using TimeTrackingSystem.Domain.Interfaces;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly Context _context;

        public ProjectRepository(Context context)
        {
            _context = context;
        }

        public void Delete(int projectId)
        {
            var project = _context.Projects.Find(projectId);
            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }
        }

        public int Add(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
            return project.Id;
        }


        public Project Get(int projectId)
        {
            var project = _context.Projects.FirstOrDefault(i => i.Id == projectId);
            return project;
        }
    }
}
