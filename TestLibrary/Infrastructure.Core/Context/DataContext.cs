using Infrastructure.Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Core.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<BookEntity> BookEntity { get; set; }
        public DbSet<EditorialEntity> EditorialEntity { get; set; }
    }
}
