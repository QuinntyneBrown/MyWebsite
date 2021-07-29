using QuinntyneBrown.Api.Models;
using QuinntyneBrown.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace QuinntyneBrown.Api.Data
{
    public class QuinntyneBrownDbContext : DbContext, IQuinntyneBrownDbContext
    {
        public DbSet<Profile> Profiles { get; private set; }
        public DbSet<Talk> Talks { get; private set; }
        public DbSet<BlogPost> BlogPosts { get; private set; }
        public DbSet<Video> Videos { get; private set; }
        public DbSet<DigitalAsset> DigitalAssets { get; private set; }
        public DbSet<User> Users { get; private set; }
        public QuinntyneBrownDbContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuinntyneBrownDbContext).Assembly);
        }

    }
}
