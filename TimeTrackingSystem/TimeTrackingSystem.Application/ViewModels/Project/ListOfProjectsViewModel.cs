using System;
using System.Collections.Generic;

namespace TimeTrackingSystem.Application.ViewModels.Project
{
    public class ListOfProjectsViewModel
    {
        public List<ProjectAccountViewModel> Projects { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public DateTime SearchByDate { get; set; }
        public int Count { get; set; }
    }
}
