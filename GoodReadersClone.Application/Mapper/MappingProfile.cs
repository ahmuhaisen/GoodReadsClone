using GoodReadsClone.Application.DTOs.Author;
using GoodReadsClone.Application.DTOs.Books;
using GoodReadsClone.Application.DTOs.Genre;
using GoodReadsClone.Application.DTOs.Quote;
using GoodReadsClone.Application.DTOs.Review;
using GoodReadsClone.Domain.Models;

namespace GoodReadsClone.Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserRegisterRequest, ApplicationUser>().ReverseMap();

        CreateMap<ApplicationUser, UserResponse>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ProfilePectureURL))
                .ReverseMap();

        CreateMap<ApplicationUser, AuthorResponse>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ReverseMap();

        CreateMap<ApplicationUser, UserResponse>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ProfilePectureURL))
            .ReverseMap();

        CreateMap<PaginatedList<UserResponse>, PaginatedList<ApplicationUser>>()
            .ReverseMap();



        CreateMap<Book, BookResponse>()
                 .ForMember(dest => dest.Author, opt => opt.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}"));

        CreateMap<Book, CreateBookRequest>()
            .ForMember(x => x.Genres, f => f.Ignore());

        CreateMap<Book, EditBookRequest>()
            .ForMember(x => x.Genres, f => f.Ignore());

        CreateMap<CreateBookRequest, Book>()
            .ForMember(x => x.Genres, f => f.Ignore());

        CreateMap<EditBookRequest, Book>()
            .ForMember(x => x.Genres, f => f.Ignore());

        CreateMap<PaginatedList<BookResponse>, PaginatedList<Book>>()
                    .ReverseMap();



        CreateMap<Review, CreateReviewRequest>().ReverseMap();

        CreateMap<Genre, GenreDto>().ReverseMap();

        CreateMap<Quote, QuoteDto>().ReverseMap();
    }
}
