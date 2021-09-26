using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuinntyneBrown.Api.Models;

namespace QuinntyneBrown.Api.Data.EntityConfigurations
{
    public class StoredEventConfiguration : IEntityTypeConfiguration<StoredEvent>
    {
        public void Configure(EntityTypeBuilder<StoredEvent> builder)
        {
            builder
                .ToContainer("StoredEvents")
                .HasNoDiscriminator();
        }
    }
}
