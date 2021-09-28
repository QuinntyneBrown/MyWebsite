using QuinntyneBrown.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuinntyneBrown.Infrastructure.Data.EntityConfigurations
{
    public class DigitalAssetConfiguration : IEntityTypeConfiguration<DigitalAsset>
    {
        public void Configure(EntityTypeBuilder<DigitalAsset> builder)
        {
            builder
                .ToContainer(nameof(DigitalAsset))
                .HasNoDiscriminator();
        }
    }
}
