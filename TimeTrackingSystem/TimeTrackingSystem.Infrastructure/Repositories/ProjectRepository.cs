using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Manage.Internal;
using Microsoft.Extensions.Logging;
using System.Linq;
using TimeTrackingSystem.Domain.Interfaces;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly Context _context;
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;

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

        public IQueryable<Project> GetByAccountId(string accountId)
        {
            var project = _context.Projects.Where(i => i.ApplicationUserId == accountId);
            return project;
        }

        public IQueryable<ProjectAccount> GetAll(string ApplicationUserId)
        {
            var projectAccount = from v in _context.Projects
                join si in _context.ApplicationUsers on v.ApplicationUserId equals si.Id into loj
                from rs in loj.DefaultIfEmpty()
                where rs.Id == ApplicationUserId
                select new ProjectAccount { ApplicationUser = rs, Project = v };
            return projectAccount;
        }

        public void Update(Project project)
        {
            _context.Attach(project);
            _context.Entry(project).Property("Project_code").IsModified = true;
            _context.Entry(project).Property("Name").IsModified = true;
            _context.Entry(project).Property("Location").IsModified = true;
            _context.Entry(project).Property("Start_date").IsModified = true;
            _context.Entry(project).Property("End_date").IsModified = true;
            _context.Entry(project).Property("Other_details").IsModified = true;
            _context.SaveChanges();
        }
    }
}
