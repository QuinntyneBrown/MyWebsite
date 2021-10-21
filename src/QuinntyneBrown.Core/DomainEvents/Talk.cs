using System;

namespace QuinntyneBrown.Core.DomainEvents
{
    public class CreateTalk
    {
        public Guid TalkId { get; private set; } = Guid.NewGuid();
    }
}
