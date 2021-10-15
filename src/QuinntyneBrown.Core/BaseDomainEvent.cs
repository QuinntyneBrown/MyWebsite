using QuinntyneBrown.Core.Interfaces;
using System;

namespace QuinntyneBrown.Core
{
    public class BaseDomainEvent : IDomainEvent
    {
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
