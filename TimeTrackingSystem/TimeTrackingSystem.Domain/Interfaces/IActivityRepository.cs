using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Domain.Interfaces
{
    public interface IActivityRepository
    {
        void DeleteActivity(int activityId);
        int AddActivity(Activity activity);
        Activity GetActivityById(int activityId);
    }
}
