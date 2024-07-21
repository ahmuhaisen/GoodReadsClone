using GoodReadersClone.Application.DTOs.Author;
using GoodReadersClone.Application.DTOs.Books;
using GoodReadersClone.Application.DTOs.Genre;
using GoodReadersClone.Application.DTOs.Quote;
using GoodReadersClone.Application.DTOs.Review;
using GoodReadersClone.Domain.Models;

namespace GoodReadersClone.Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserRegisterRequest, ApplicationUser>().ReverseMap();

        CreateMap<Book, BookResponse>().ReverseMap();
        CreateMap<Book, CreateBookRequest>().ForMember(x => x.Genres, f => f.Ignore());
        CreateMap<Book, EditBookRequest>().ForMember(x => x.Genres, f => f.Ignore());
        CreateMap<CreateBookRequest, Book>().ForMember(x => x.Genres, f => f.Ignore());
        CreateMap<EditBookRequest, Book>().ForMember(x => x.Genres, f => f.Ignore());

        CreateMap<ApplicationUser, UserResponse>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ProfilePectureURL))
            .ReverseMap();

        CreateMap<PaginatedList<UserResponse>, PaginatedList<ApplicationUser>>()
        .ReverseMap();

        CreateMap<ApplicationUser, AuthorResponse>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
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
