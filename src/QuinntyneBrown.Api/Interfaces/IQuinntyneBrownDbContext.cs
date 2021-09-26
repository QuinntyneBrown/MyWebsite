using QuinntyneBrown.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace QuinntyneBrown.Api.Interfaces
{
    public interface IQuinntyneBrownDbContext
    {
        DbSet<Profile> Profiles { get; }
        DbSet<Talk> Talks { get; }
        DbSet<BlogPost> BlogPosts { get; }
        DbSet<Video> Videos { get; }
        DbSet<DigitalAsset> DigitalAssets { get; }
        DbSet<User> Users { get; }
        DbSet<Account> Accounts { get; }
        DbSet<StoredEvent> StoredEvents { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
