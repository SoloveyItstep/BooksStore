using Books.Domain.Core.DbEntities;
using Books.Domain.Core.DbEntities.Books;
using Books.Domain.Core.DbEntities.PromotionsModels;
using Books.Domain.Core.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Books.Infrastructure.Data.DBContexts
{
    public class DataContext: IdentityDbContext<ApplicationUser, StoreRole, Guid>
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Languages> Languages { get; set; }
        public DbSet<Promotions> Promotions { get; set; }
    }
}
