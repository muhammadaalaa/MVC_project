using AutoMapper;
using DAL.Models;
using DemoOnePresentation.ViewModels;

namespace DemoOnePresentation.Profiles
{
    public class employeeProfile : Profile
    {
        public employeeProfile()
        {
            CreateMap<employeeViewModel, Employee>().ReverseMap(); // simple mao 
            //CreateMap<employeeViewModel, Employee>().ForMember(d => d.Name, O => O.MapFrom(S => S.Name)); // if you want to change the name in the view model
        }
    }
}
