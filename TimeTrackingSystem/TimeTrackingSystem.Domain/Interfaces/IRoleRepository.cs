using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Domain.Interfaces
{
    public interface IRoleRepository
    {
        void DeleteRole(int roleId);
        int AddRole(Role role);
        IQueryable<Role> GetRolesByRoleId(int roleId);
        Role GetRoleById(int roleId);
    }
}
