using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuinntyneBrown.Core.Models;

namespace QuinntyneBrown.Api.Data
{
    public class ContactRequestConfiguration: IEntityTypeConfiguration<ContactRequest>
    {
        public void Configure(EntityTypeBuilder<ContactRequest> builder)
        {
            builder
            .ToContainer(nameof(ContactRequest))
            .HasNoDiscriminator();
        }
        
    }
}
