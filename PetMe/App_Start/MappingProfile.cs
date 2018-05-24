using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PetMe.Models;
using PetMe.ViewModels;

namespace PetMe.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<ApplicationUser, UserProfileViewModel>();
            Mapper.CreateMap<UserProfileViewModel, ApplicationUser>();
            Mapper.CreateMap<Pet, Pet>();
        }
    }
}