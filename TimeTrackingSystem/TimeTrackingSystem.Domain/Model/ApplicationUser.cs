using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TimeTrackingSystem.Domain.Model
{
    public class ApplicationUser : IdentityUser
    {
        
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Full_Name { get; set; }
        public string Status { get; set; }
        public byte[] PhotoProfile { get; set; }
        public virtual ICollection<Leave> Leaves { get; set; }
        public virtual ICollection<TimeSheet> TimeSheets { get; set; }
        public virtual ICollection<Project> Projects { get; set; }

        public ApplicationUser() : base()
        {

        }
    }
}
