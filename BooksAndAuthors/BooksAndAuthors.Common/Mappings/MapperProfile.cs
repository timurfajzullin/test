using AutoMapper;
using Contracts.Dto;
using Models;

namespace BooksAndAuthors.Common.Mappings;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Book, GetBookDto>()
            .ForMember(dest => dest.AuthorName, 
                opt => opt.MapFrom(src => src.Author.Name));

        CreateMap<PostBookDto, Book>()
            .ForPath(dest => dest.Author.Name, 
                opt => opt.MapFrom(src => src.AuthorName));

        CreateMap<Author, GetAuthorDto>()
            .ForMember(dest => dest.Books, 
                opt => opt.MapFrom(src => src.Books));

        CreateMap<PostAuthorDto, Author>()
            .ForMember(dest => dest.Books, 
                opt => opt.Ignore());
    }
}