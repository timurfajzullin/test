using AutoMapper;
using Contracts.Dto;
using Models;

namespace BooksAndAuthors.Common.Mappings;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Book, BookDto>()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name));

        CreateMap<BookDto, Book>();
        CreateMap<Author, AuthorDto>();
        CreateMap<AuthorDto, Author>()
            .ForMember(dest => dest.Books, opt => opt.Ignore());
    }
}
