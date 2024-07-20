using GoodReadersClone.Application.DTOs.Books;
using GoodReadersClone.Application.DTOs.Genre;
using GoodReadersClone.Application.DTOs.Quote;
using GoodReadersClone.Application.DTOs.Review;

namespace GoodReadersClone.Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserRegisterRequest, ApplicationUser>().ReverseMap();
        CreateMap<UserInfoModel, ApplicationUser>().ReverseMap();

        CreateMap<Book, BookResponse>().ReverseMap();
        CreateMap<Book, CreateBookRequest>().ForMember(x => x.Genres, f => f.Ignore());
        CreateMap<Book, EditBookRequest>().ForMember(x => x.Genres, f => f.Ignore());
        CreateMap<CreateBookRequest, Book>().ForMember(x => x.Genres, f => f.Ignore());
        CreateMap<EditBookRequest, Book>().ForMember(x => x.Genres, f => f.Ignore());

        CreateMap<ApplicationUser, UserFullInfoResponse>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ProfilePectureURL))
            .ReverseMap();

        CreateMap<ApplicationUser, UserResponse>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ProfilePectureURL))
            .ReverseMap();

        CreateMap<Review, CreateReviewRequest>().ReverseMap();

        CreateMap<Genre, GenreDto>().ReverseMap();

        CreateMap<Quote, QuoteDto>().ReverseMap();
    }
}
