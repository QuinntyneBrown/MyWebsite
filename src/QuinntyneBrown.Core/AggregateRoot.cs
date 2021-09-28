using QuinntyneBrown.Core.Interfaces;
using QuinntyneBrown.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static Newtonsoft.Json.JsonConvert;

namespace QuinntyneBrown.Core
{
    public abstract class AggregateRoot : IAggregateRoot
    {
        internal List<StoredEvent> _storedEvents = new List<StoredEvent>();

        [NotMapped]
        public IReadOnlyCollection<StoredEvent> StoredEvents => _storedEvents.AsReadOnly();

        public AggregateRoot(IEnumerable<IDomainEvent> events)
        {
            foreach (var @event in events) { When(@event); }
        }

        protected AggregateRoot()
        {

        }

        public void StoreEvent(IDomainEvent @event)
        {
            var type = GetType();

            var storedEvent = new StoredEvent
            {
                StoredEventId = Guid.NewGuid(),
                Aggregate = GetType().Name,
                AggregateDotNetType = GetType().AssemblyQualifiedName,
                Data = SerializeObject(@event),
                StreamId = (Guid)type.GetProperty($"{type.Name}Id").GetValue(this, null),
                DotNetType = @event.GetType().BaseType.AssemblyQualifiedName,
                Type = @event.GetType().BaseType.Name,
                CreatedOn = @event.Created,
                CorrelationId = new Guid()
            };

            _storedEvents.Add(storedEvent);
        }

        public AggregateRoot Apply(IDomainEvent @event)
        {
            When(@event);
            EnsureValidState();
            StoreEvent(@event);
            return this;
        }
        protected abstract void When(dynamic @event);
        protected abstract void EnsureValidState();
    }
}