using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuinntyneBrown.Api.Models;

namespace QuinntyneBrown.Api.Data.EntityConfigurations
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder
                .ToContainer(nameof(Account));
        }
    }
}
