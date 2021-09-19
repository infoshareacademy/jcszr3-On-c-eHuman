using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTrackingSystem.Domain.Model
{
    public class Role
    {
        public int Id { get; set; }
        public string Role_name { get; set; }

        public virtual ICollection<ApplicationUser> Employees { get; set; }
    }
}
