using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuinntyneBrown.Core.Models;

namespace QuinntyneBrown.Api.Data
{
    public class JsonContentConfiguration: IEntityTypeConfiguration<JsonContent>
    {
        public void Configure(EntityTypeBuilder<JsonContent> builder)
        {
            builder
                .ToContainer(nameof(JsonContent))
                .HasNoDiscriminator();
        }        
    }
}
