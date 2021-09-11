using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TimeTrackingSystem.Domain.Model
{
    public class Account
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string Status { get; set; }
        public bool IsEnable { get; set; }
        public byte[] PhotoProfile { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<Project> Projects{ get; set; }
        public virtual ICollection<TimeSheet> TimeSheets { get; set; }
    }
}
