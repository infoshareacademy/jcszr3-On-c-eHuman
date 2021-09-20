using System.Linq;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Domain.Interfaces
{
    public interface IProjectRepository
    {
        public void Delete(int projectId);
        public int Add(Project project);
        public Project Get(int projectId);
        public IQueryable<Project> GetByAccountId(string accountId);
        IQueryable<ProjectAccount> GetAll(string ApplicationUserId);
        void Update(Project project);
    }
}
