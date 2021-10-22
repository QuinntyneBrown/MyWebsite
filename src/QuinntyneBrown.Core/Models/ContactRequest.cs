using QuinntyneBrown.Core.DomainEvents;
using System;

namespace QuinntyneBrown.Core.Models
{
    public class ContactRequest : AggregateRoot
    {
        public Guid ContactRequestId { get; private set; }
        public string RequestedByEmail { get; private set; }
        public string RequestedByName { get; private set; }
        public string Details { get; private set; }

        protected override void EnsureValidState()
        {

        }

        protected override void When(dynamic @event)
            => When(@event);

        private void When(CreateContactRequest @event)
        {
            ContactRequestId = @event.ContactRequestId;
            RequestedByEmail = @event.RequestedByEmail;
            RequestedByName = @event.RequestedByName;
            Details = @event.Details;
        }
    }
}
