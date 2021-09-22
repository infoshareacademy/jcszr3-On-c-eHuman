using AutoMapper;
using FluentValidation;
using System;
using TimeTrackingSystem.Application.Mapping;

namespace TimeTrackingSystem.Application.ViewModels.Activity
{
    public class ActivityDetailsViewModel : IMapFrom<Domain.Model.Activity>
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public int ProjectId { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }
        public string Other_details { get; set; }
        public void Mapping(Profile profile)
        {
            //<source, destination>
            profile.CreateMap<ActivityDetailsViewModel, Domain.Model.Activity>().ReverseMap();
        }
    }
    public class NewActivityValidation : AbstractValidator<ActivityDetailsViewModel>
    {
        public NewActivityValidation()
        {
            RuleFor(x => x.Other_details).Length(3, 100);
        }
    }
}
