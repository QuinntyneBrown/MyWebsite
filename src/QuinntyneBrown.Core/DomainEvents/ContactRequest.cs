using System;

namespace QuinntyneBrown.Core.DomainEvents
{
    public class CreateContactRequest: BaseDomainEvent
    {
        public Guid ContactRequestId { get; private set; } = Guid.NewGuid();
        public string RequestedByEmail { get; private set; }
        public string RequestedByName { get; private set; }
        public string Details { get; private set; }

        public CreateContactRequest(string requestedByEmail, string requestedByName, string details)
        {
            RequestedByEmail = requestedByEmail;
            RequestedByName = requestedByName;
            Details = details;
        }
    }
}
