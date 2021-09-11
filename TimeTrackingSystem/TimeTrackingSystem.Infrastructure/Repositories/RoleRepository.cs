using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTrackingSystem.Domain.Interfaces;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly Context _context;
        public RoleRepository(Context context)
        {
            _context = context;
        }

        public void DeleteRole(int roleId)
        {
            var role = _context.Roles.Find(roleId);
            if (role != null)
            {
                _context.Roles.Remove(role);
                _context.SaveChanges();
            }
        }

        public int AddRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role.Id;
        }

        public IQueryable<Role> GetRolesByRoleId(int roleId)
        {
            var roles = _context.Roles.Where(i => i.Id == roleId);
            return roles;
        }

        public Role GetRoleById(int roleId)
        {
            var role = _context.Roles.FirstOrDefault(i => i.Id == roleId);
            return role;
        }
    }
}