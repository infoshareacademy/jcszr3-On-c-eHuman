using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Application.ViewModels
{
    public class ListOfEmployeesViewModel
    {
        public List<EmployeeDetailsViewModel> Employees { get; set; }
        public int Count { get; set; }
    }
}
