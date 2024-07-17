using AutoMapper;
using GoodReadersClone.Application.DTOs.Books;
using GoodReadersClone.Domain.Entities;

namespace GoodReadersClone.Api.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserRegisterRequest, ApplicationUser>().ReverseMap();
        CreateMap<UserInfoModel, ApplicationUser>().ReverseMap();

        CreateMap<Book, BookModel>().ReverseMap();
        CreateMap<Book, CreateBookRequest>().ForMember(x => x.Genres, f => f.Ignore());
        CreateMap<CreateBookRequest, Book>().ForMember(x => x.Genres, f => f.Ignore());

        CreateMap<ApplicationUser, UserFullInfoResponse>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ProfilePectureURL))
            .ReverseMap();

        CreateMap<ApplicationUser, UserResponse>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ProfilePectureURL))
            .ReverseMap();
    }
}
