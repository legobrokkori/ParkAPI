using AutoMapper;
using ParkyAPI.Models;
using ParkyAPI.Models.Dtos;
using System.Collections.Generic;

namespace ParkyAPI.Mapper
{
    public class ParkyMappings : Profile
    {
        public ParkyMappings()
        {
            CreateMap<NationalPark, NationalParkDto>().ReverseMap();
            CreateMap<ICollection<NationalPark>, NationalParkDto>();
        }
    }
}