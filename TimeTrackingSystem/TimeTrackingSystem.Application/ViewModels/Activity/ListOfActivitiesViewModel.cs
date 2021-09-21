using System;
using System.Collections.Generic;

namespace TimeTrackingSystem.Application.ViewModels.Activity
{
    public class ListOfActivitiesViewModel
    {
        public List<ActivityProjectViewModel> Activities { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public DateTime SearchByDate { get; set; }
        public int Count { get; set; }
    }
}
