using QuinntyneBrown.Api.Models;
using QuinntyneBrown.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace QuinntyneBrown.Api.Data
{
    public class QuinntyneBrownDbContext: DbContext, IQuinntyneBrownDbContext
    {
        public DbSet<Profile> Profiles { get; private set; }
        public QuinntyneBrownDbContext(DbContextOptions options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuinntyneBrownDbContext).Assembly);
        }
        
    }
}
