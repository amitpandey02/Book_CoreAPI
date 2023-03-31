using AutoMapper;
using BookStore_CoreAPI.Data;
using BookStore_CoreAPI.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_CoreAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreContext context,IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            //var records = await _context.books.Select(x => new BookModel
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description,
            //}).ToListAsync();
            //return records;
            var records = await _context.books.ToListAsync();
            return _mapper.Map<List<BookModel>>(records);
        }

        public async Task<BookModel> GetBookById(int bookid)
        {
            //var records = await _context.books.Where(x => x.Id == bookid).Select(x => new BookModel
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description,
            //}).FirstOrDefaultAsync();
            //return records;
            var record = await _context.books.FindAsync(bookid);
            return _mapper.Map<BookModel>(record);
        }

        public async Task<Book> AddBook(BookModel bookModel)
        {
            var book = new Book()
            {
                Title = bookModel.Title,
                Description = bookModel.Description
            };
            _context.books.Add(book);
            await _context.SaveChangesAsync();
            return book;

        }

        public async Task<Book> UpdateBook(int id, BookModel bookModel)
        {
            //var book=await _context.books.FindAsync(id);
            // if (book != null)
            // {
            //     book.Title = bookModel.Title;
            //     book.Description = bookModel.Description;
            //     await _context.SaveChangesAsync();
            // }
            var book = new Book()
            {
                Id = id,
                Title = bookModel.Title,
                Description = bookModel.Description
            };
            _context.books.Update(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<Book> UpdateBookPatch(int id, JsonPatchDocument bookModel)
        {
            var book = await _context.books.FindAsync(id);
            if (book != null)
            {
                bookModel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }

            return book;
        }

        public async Task DeleteBook(int id)
        {
            var book = new Book() { Id = id };
            _context.books.Remove(book);
            await _context.SaveChangesAsync();           
        }
    }
}
