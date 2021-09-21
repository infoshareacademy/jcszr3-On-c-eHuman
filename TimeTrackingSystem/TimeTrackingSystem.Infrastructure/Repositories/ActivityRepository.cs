using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Manage.Internal;
using Microsoft.Extensions.Logging;
using System.Linq;
using TimeTrackingSystem.Domain.Interfaces;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Infrastructure.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly Context _context;
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public ActivityRepository(Context context)
        {
            _context = context;
        }

        public void Delete(int activityId)
        {
            var activity = _context.Activities.Find(activityId);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
                _context.SaveChanges();
            }
        }

        public int Add(Activity activity)
        {
            _context.Activities.Add(activity);
            _context.SaveChanges();
            return activity.Id;
        }

        public Activity Get(int activityId)
        {
            var activity = _context.Activities.FirstOrDefault(i => i.Id == activityId);
            return activity;
        }

        public IQueryable<Activity> GetByProjectId(int projectId)
        {
            var activity = _context.Activities.Where(i => i.ProjectId == projectId);
            return activity;
        }

        public IQueryable<ActivityProject> GetAll(int projectId)
        {
            var ActivityProject = from v in _context.Activities
                                 join si in _context.Projects on v.ProjectId equals si.Id into loj
                                 from rs in loj.DefaultIfEmpty()
                                 where rs.Id == projectId
                                  select new ActivityProject { Project = rs, Activity = v };
            return ActivityProject;
        }

        public void Update(Activity activity)
        {
            _context.Attach(activity);
            _context.Entry(activity).Property("Activity_code").IsModified = true;
            _context.Entry(activity).Property("Name").IsModified = true;
            _context.Entry(activity).Property("Location").IsModified = true;
            _context.Entry(activity).Property("Start_date").IsModified = true;
            _context.Entry(activity).Property("End_date").IsModified = true;
            _context.Entry(activity).Property("Other_details").IsModified = true;
            _context.SaveChanges();
        }
    }
}