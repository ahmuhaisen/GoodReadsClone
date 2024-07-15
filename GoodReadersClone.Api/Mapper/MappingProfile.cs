using AutoMapper;
using GoodReadersClone.Application.DTOs.User;
using GoodReadersClone.Domain.Entities;

namespace GoodReadersClone.Api.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserRegisterRequest, ApplicationUser>().ReverseMap();
        CreateMap<UserInfoModel, ApplicationUser>().ReverseMap();
    }
}
