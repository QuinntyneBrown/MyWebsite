using System;

namespace QuinntyneBrown.Core.DomainEvents
{
    public class CreateUser
    {
        public Guid UserId { get; set; } = Guid.NewGuid();
    }
}
