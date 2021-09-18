
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;


using Microsoft.AspNetCore.Identity;

namespace TimeTrackingSystem.Domain.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Status { get; set; }
        public byte[] PhotoProfile { get; set; }
        public virtual ICollection<TimeSheet> TimeSheets { get; set; }
        public virtual ICollection<Project> Projects { get; set; }

        public ApplicationUser() : base()
        {

        }

    }
}
