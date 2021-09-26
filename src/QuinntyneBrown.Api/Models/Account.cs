using QuinntyneBrown.Api.Core;
using System;
using System.Collections.Generic;

namespace QuinntyneBrown.Api.Models
{
    public class Account: AggregateRoot
    {
        public Guid AccountId { get; private set; }
        public Guid UserId { get; private set; }
        public string AccountHolderFullname { get; private set; }
        public List<Profile> Profiles { get; private set; } = new List<Profile>();
        public Account(Guid userId, string accountHolderName)
        {
            UserId = userId;
            AccountHolderFullname = accountHolderName;
        }

        private Account()
        {

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
