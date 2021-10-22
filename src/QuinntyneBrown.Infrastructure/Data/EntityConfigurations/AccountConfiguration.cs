using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuinntyneBrown.Core.Models;

namespace QuinntyneBrown.Infrastructure.Data.EntityConfigurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder
                .ToContainer(nameof(Account))
                .HasMany(x => x.Profiles);
        }
    }
}
