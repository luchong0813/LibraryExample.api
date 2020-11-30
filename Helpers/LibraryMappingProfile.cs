using AutoMapper;
using LibraryExample.api.Entities;
using LibraryExample.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryExample.api.Helpers
{
    public class LibraryMappingProfile : Profile
    {
        public LibraryMappingProfile()
        {
            CreateMap<Author, AuthorDto>().ForMember(dest => dest.Age, config => config.MapFrom(src => src.BirthData));
            CreateMap<Book, BookDto>();
            CreateMap<AuthorForCreationDto, Author>();
            CreateMap<BookForCreationDto, Book>();
            CreateMap<BookForUpdateDto, Book>();
        }
    }
}
