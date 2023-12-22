using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4.Core.DTOs;
using Week4.Core.Models;

namespace Week4.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<User,GetUserDto>().ReverseMap();
            CreateMap<User, PostUserDto>().ReverseMap();
            CreateMap<User, PutUserDto>();

            CreateMap<Pet, GetPetDto>().ReverseMap();
            CreateMap<Pet, PostPetDto>().ReverseMap();
            CreateMap<Pet, PetDto>().ReverseMap();

            CreateMap<HealthStatus, GetHealthStatusDto>().ReverseMap();
            CreateMap<HealthStatus,PutHealthStatusDto>().ReverseMap();

            CreateMap<Foods,GetFoodDto>().ReverseMap();
            CreateMap<Foods,PostFoodDto>().ReverseMap();

            CreateMap<Activities,GetActivitiesDto>().ReverseMap();
            CreateMap<Activities,PostActivitiesDto>().ReverseMap();

            CreateMap<Pet, PetWithStatusDto>();
  
        }
    }
}
