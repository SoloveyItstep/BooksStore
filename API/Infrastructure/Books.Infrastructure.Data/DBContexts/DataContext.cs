using Books.Domain.Core.Account;
using Books.Domain.Core.DbEntities;
using Books.Domain.Core.DbEntities.PromotionsModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Books.Infrastructure.Data.DBContexts
{
    public class DataContext: IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Languages> Languages { get; set; }
        public DbSet<Promotions> Promotions { get; set; }
    }
}
