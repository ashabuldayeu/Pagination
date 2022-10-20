using Microsoft.EntityFrameworkCore;
using Pagination.Web.Entities;

namespace Pagination.Web
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<SampleEntity> SampleEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SampleEntity>()
                .HasKey(t => t.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
