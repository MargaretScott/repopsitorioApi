using AutoMapper;
using CursoDotNet.Application.BusinessModels.Models;
using CursoDotNet.Application.BusinessModels.Requests;
using CursoDotNet.DataAccess.Contracts.Dtos;
using CursoDotNet.DataAccess.Contracts.Entities;
using System.Collections.Generic;

namespace CursoDotNet.CrossCutting.Services
{
    public class AutoMapperService : Profile
    {
        public AutoMapperService()
        {
            CreateMap<CreateCarRequest, CarModel>();
            CreateMap<CarModel, CarDto>();
            CreateMap<List<CarModel>, List<CarDto>>();
            CreateMap<CarDto, CarModel>();
            CreateMap<UserModel, User>();
            CreateMap<User, UserModel>();
        }
    }
}
