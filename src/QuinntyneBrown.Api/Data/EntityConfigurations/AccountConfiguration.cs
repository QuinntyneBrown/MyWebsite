using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuinntyneBrown.Api.Models;

namespace QuinntyneBrown.Api.Data.EntityConfigurations
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
