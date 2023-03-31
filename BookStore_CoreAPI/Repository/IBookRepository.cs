using BookStore_CoreAPI.Data;
using BookStore_CoreAPI.Model;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore_CoreAPI.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBookById(int bookid);
        Task<Book> AddBook(BookModel bookModel);
        Task<Book> UpdateBook(int id, BookModel bookModel);
        Task<Book> UpdateBookPatch(int id, JsonPatchDocument bookModel);
        Task DeleteBook(int id);
    }
}
