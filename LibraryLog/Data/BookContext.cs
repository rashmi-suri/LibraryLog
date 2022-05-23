//refering to class in a different namespace
//therefore need using clause to reference models folder
using LibraryLog.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryLog.Data
{
    public class BookContext : DbContext
    {
        //constructor which does not return anything
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }
        //gets items to and from a table in the database
        //DbSet = collection of items named "Books"
        public DbSet<Book> Books { get; set; }
    }

}
