using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void DeleteActivity(int activityId)
        {
            var activity = _context.Activities.Find(activityId);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
                _context.SaveChanges();
            }
        }

        public int AddActivity(Activity activity)
        {
            _context.Activities.Add(activity);
            _context.SaveChanges();
            return activity.Id;
        }


        public Activity GetActivityById(int activityId)
        {
            var activity = _context.Activities.FirstOrDefault(i => i.Id == activityId);
            return activity;
        }
    }
}
