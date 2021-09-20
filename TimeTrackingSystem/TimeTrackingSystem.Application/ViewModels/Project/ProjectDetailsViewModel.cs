using AutoMapper;
using FluentValidation;
using System;
using TimeTrackingSystem.Application.Mapping;

namespace TimeTrackingSystem.Application.ViewModels.Project
{
    public class ProjectDetailsViewModel : IMapFrom<Domain.Model.Project>
    {
        public int Id { get; set; }
        public int Project_code { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }
        public string Other_details { get; set; }
        public string ApplicationUserId { get; set; }
        public void Mapping(Profile profile)
        {
            //<source, destination>
            profile.CreateMap<ProjectDetailsViewModel, Domain.Model.Project>().ReverseMap();
        }
    }
    public class NewProjectValidation : AbstractValidator<ProjectDetailsViewModel>
    {
        public NewProjectValidation()
        {
            RuleFor(x => x.Other_details).Length(3, 100);
        }
    }
}
