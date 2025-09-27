

using AutoMapper;
using BAUST_Book_Store.Models.Domain;
using BAUST_Book_Store.Models.Dtos;

namespace BAUST_Book_Store.Mappings;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Book, BookDto>().ReverseMap();
        CreateMap<Book, CreateBookDto>().ReverseMap();
        CreateMap<Book, UpdateBookDto>().ReverseMap();
        CreateMap<UploadImageRequestDto, Image>();
    }
}
