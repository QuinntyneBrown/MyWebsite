using System;

namespace QuinntyneBrown.Core.DomainEvents
{
    public class CreateVideo
    {
        public Guid VideoId { get; set; } = Guid.NewGuid();
    }
}
