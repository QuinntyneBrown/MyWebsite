using QuinntyneBrown.Api.Core;
using QuinntyneBrown.Api.DomainEvents;
using System;
using System.Collections.Generic;

namespace QuinntyneBrown.Api.Models
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

        public Account(CreateAccount createAccount)
        {            
            AccountId = createAccount.AccountId;
            UserId = createAccount.UserId;
            AccountHolderFullname = createAccount.AccountHolderFullname;
            Firstname = createAccount.Firstname;
            Lastname = createAccount.Lastname;
            Profiles = new();            
        }

        protected override void When(dynamic @event)
        {
            throw new NotImplementedException();
        }

        protected override void EnsureValidState()
        {
            throw new NotImplementedException();
        }
    }
}
