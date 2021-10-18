using System;

namespace QuinntyneBrown.Core.DomainEvents
{
    public class CreateTalk
    {
        public Guid TalkId { get; set; } = Guid.NewGuid();
    }
}
