using QuinntyneBrown.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace QuinntyneBrown.Core.Interfaces
{
    public interface IQuinntyneBrownDbContext
    {
        DbSet<Profile> Profiles { get; }
        DbSet<Talk> Talks { get; }
        DbSet<BlogPost> BlogPosts { get; }
        DbSet<Video> Videos { get; }
        DbSet<DigitalAsset> DigitalAssets { get; }
        DbSet<JsonContent> JsonContents { get; }
        DbSet<User> Users { get; }
        DbSet<Account> Accounts { get; }
        DbSet<StoredEvent> StoredEvents { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
