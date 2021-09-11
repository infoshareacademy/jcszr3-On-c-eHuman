using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void DeleteProject(int projectId)
        {
            var project = _context.Projects.Find(projectId);
            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }
        }

        public int AddProject(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
            return project.Id;
        }


        public Project GetProjectById(int projectId)
        {
            var project = _context.Projects.FirstOrDefault(i => i.Id == projectId);
            return project;
        }
    }
}
