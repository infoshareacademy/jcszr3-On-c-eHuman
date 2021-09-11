using System;
using System.Collections.Generic;
using System.Text;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Domain.Interfaces
{
    public interface IProjectRepository
    {
        public void DeleteProject(int projectId);
        public int AddProject(Project project);
        public Project GetProjectById(int projectId);

    }
}
