using QuinntyneBrown.Core.Interfaces;
using System;

namespace QuinntyneBrown.Core
{
    public class DomainEventBase : IDomainEvent
    {
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
