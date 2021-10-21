using System;

namespace QuinntyneBrown.Core.DomainEvents
{
    public class CreateAccount: BaseDomainEvent
    {
        public Guid AccountId { get; private set; } = Guid.NewGuid();
        public Guid UserId { get; private set; }
        public string AccountHolderFullname { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }

        public CreateAccount(Guid userId, string accountHolderFullname, string firstname, string lastname)
        {
            UserId = userId;
            AccountHolderFullname = accountHolderFullname;
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}
