using QuinntyneBrown.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuinntyneBrown.Infrastructure.Data.EntityConfigurations
{
    public class TalkConfiguration : IEntityTypeConfiguration<Talk>
    {
        public void Configure(EntityTypeBuilder<Talk> builder)
        {
            builder
                .ToContainer(nameof(Talk))
                .HasNoDiscriminator();
        }
    }
}
