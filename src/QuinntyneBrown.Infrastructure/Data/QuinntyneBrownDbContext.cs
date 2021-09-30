using Microsoft.EntityFrameworkCore;
using QuinntyneBrown.Core.Interfaces;
using QuinntyneBrown.Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace QuinntyneBrown.Infrastructure.Data
{
    public class QuinntyneBrownDbContext: DbContext, IQuinntyneBrownDbContext
    {
        public DbSet<Profile> Profiles { get; private set; }
        public DbSet<Talk> Talks { get; private set; }
        public DbSet<BlogPost> BlogPosts { get; private set; }
        public DbSet<Video> Videos { get; private set; }
        public DbSet<DigitalAsset> DigitalAssets { get; private set; }
        public DbSet<User> Users { get; private set; }
        public DbSet<Account> Accounts { get; private set; }
        public DbSet<StoredEvent> StoredEvents { get; private set; }
        public DbSet<JsonContent> JsonContents { get; private set; }

        public QuinntyneBrownDbContext(DbContextOptions options)
            :base(options) {
            SavingChanges += QuinntyneBrownDbContext_SavingChanges;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuinntyneBrownDbContext).Assembly);
        }

        private void QuinntyneBrownDbContext_SavingChanges(object sender, SavingChangesEventArgs e)
        {
            var entries = ChangeTracker.Entries<QuinntyneBrown.Core.AggregateRoot>()
                .Where(
                    e => e.State == EntityState.Added ||
                    e.State == EntityState.Modified)
                .Select(e => e.Entity)
                .ToList();

            foreach (var aggregate in entries)
            {
                foreach (var storedEvent in aggregate.StoredEvents)
                {
                    StoredEvents.Add(storedEvent);
                }
            }
        }

        public override void Dispose()
        {
            SavingChanges -= QuinntyneBrownDbContext_SavingChanges;
            base.Dispose();
        }

        public override ValueTask DisposeAsync()
        {
            SavingChanges -= QuinntyneBrownDbContext_SavingChanges;
            return base.DisposeAsync();
        }

    }
}
