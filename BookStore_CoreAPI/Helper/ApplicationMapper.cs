using AutoMapper;
using BookStore_CoreAPI.Data;
using BookStore_CoreAPI.Model;

namespace BookStore_CoreAPI.Helper
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper() 
        {
            // CreateMap<Book, BookModel>();
            // CreateMap<BookModel,Book>();
            CreateMap<Book, BookModel>().ReverseMap();
        }

        
    }
}
