﻿using System;

namespace QuinntyneBrown.Core.DomainEvents
{
    public class CreateContactRequest: BaseDomainEvent
    {
        public Guid ContactRequestId { get; set; }
        public string RequestedByEmail { get; set; }
        public string RequestedByName { get; set; }
        public string Details { get; set; }
    }
}