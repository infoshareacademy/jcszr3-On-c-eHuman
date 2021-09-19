using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TimeTrackingSystem.Application.Mapping;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Application.ViewModels
{
    public class EmployeeDetailsViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }
        public string Full_Name { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }
        public byte[] PhotoProfile { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ApplicationUser, EmployeeDetailsViewModel>()
                .ForMember(s => s.Full_Name, opt => opt.MapFrom(d => d.First_Name + " " + d.Last_Name));   
        }
    }
}
