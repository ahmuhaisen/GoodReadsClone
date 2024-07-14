﻿using AutoMapper;
using GoodReadersClone.Application.DTOs;
using GoodReadersClone.Domain.Entities;

namespace GoodReadersClone.Api.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserRegisterRequest, ApplicationUser>().ReverseMap();
    }
}