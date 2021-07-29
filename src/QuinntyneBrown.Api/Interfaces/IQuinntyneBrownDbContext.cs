using QuinntyneBrown.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace QuinntyneBrown.Api.Interfaces
{
    public interface IQuinntyneBrownDbContext
    {
        DbSet<Profile> Profiles { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
