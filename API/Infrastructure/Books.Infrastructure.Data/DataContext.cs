using Books.Domain.Core.Account;
using Books.Domain.Core.DbEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Books.Infrastructure.Data
{
    public class DataContext: IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
