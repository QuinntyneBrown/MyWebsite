using System;

namespace QuinntyneBrown.Core.DomainEvents
{
    public class CreateProfile
    {
        public Guid ProfileId { get; set; } = Guid.NewGuid();
    }
}
