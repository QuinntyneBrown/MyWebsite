using QuinntyneBrown.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuinntyneBrown.Api.Data.EntityConfigurations
{
    public class VideoConfiguration : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder
                .ToContainer(nameof(Video))
                .HasNoDiscriminator();
        }
    }
}
