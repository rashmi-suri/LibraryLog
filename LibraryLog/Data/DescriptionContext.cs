using LibraryLog.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryLog.Data
{
    public class DescriptionContext : DbContext
    {
        public DescriptionContext(DbContextOptions<DescriptionContext> options) : base(options)
        {
        }
        public DbSet<BookDescription> BookDescriptions { get; set; }
    }

}
