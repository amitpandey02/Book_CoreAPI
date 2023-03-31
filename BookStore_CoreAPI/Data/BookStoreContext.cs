using BookStore_CoreAPI.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore_CoreAPI.Data
{
    public class BookStoreContext:IdentityDbContext<ApplicationUser>
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }
        public DbSet<Book> books { get; set; }

        //we can write connection string like this

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-AB9EJKT;Database=BookStoreAPI;Integrated Security=true");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
