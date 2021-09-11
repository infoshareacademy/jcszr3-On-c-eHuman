using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TimeTrackingSystem.Application.Mapping;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Application.ViewModels.Employee
{
    public class NewEmployeeViewModel : IMapFrom<Account>
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }

        public void Mapping(Profile profile)
        {
            //<source, destination>
            profile.CreateMap<Account, NewEmployeeViewModel>();
        }
    }
}
