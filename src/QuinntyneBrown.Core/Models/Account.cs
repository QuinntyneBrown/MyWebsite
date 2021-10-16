using QuinntyneBrown.Core.DomainEvents;
using System;
using System.Collections.Generic;

namespace QuinntyneBrown.Core.Models
{
    public class Account: AggregateRoot
    {
        public Guid AccountId { get; private set; }
        public Guid UserId { get; private set; }
        public string AccountHolderFullname { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public List<Profile> Profiles { get; private set; }

        private Account()
        {

        }

        public Account(CreateAccount @event)
        {
            Apply(@event);           
        }

        protected override void When(dynamic @event) => When(@event);

        private void When(CreateAccount createAccount)
        {
            AccountId = createAccount.AccountId;
            UserId = createAccount.UserId;
            AccountHolderFullname = createAccount.AccountHolderFullname;
            Firstname = createAccount.Firstname;
            Lastname = createAccount.Lastname;
            Profiles = new();
        }

        protected override void EnsureValidState()
        {

        }
    }
}
