using System.Linq;
using TimeTrackingSystem.Domain.Interfaces;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Infrastructure.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly Context _context;

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
    }
}
