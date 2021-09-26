using QuinntyneBrown.Api.Core;
using System;

namespace QuinntyneBrown.Api.DomainEvents
{
    public class CreateAccount: DomainEventBase
    {
        public Guid UserId { get; set; }
        public Guid AccountId { get; set; }
        public string AccountHolderFullname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
