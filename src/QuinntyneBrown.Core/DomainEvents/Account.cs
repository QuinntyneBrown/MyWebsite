using System;

namespace QuinntyneBrown.Core.DomainEvents
{
    public class CreateAccount: BaseDomainEvent
    {
        public Guid UserId { get; set; }
        public Guid AccountId { get; set; }
        public string AccountHolderFullname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
