using Newtonsoft.Json.Linq;
using QuinntyneBrown.Core.DomainEvents;
using System;

namespace QuinntyneBrown.Core.Models
{
    public class JsonContent: AggregateRoot
    {
        public Guid JsonContentId { get; private set; }
        public JObject Json { get; private set; }
        public string Name { get; private set; }

        public JsonContent(CreateJsonContent createJsonContent)
        {
            Apply(createJsonContent);
        }

        protected JsonContent() { }

        public void When(CreateJsonContent @event)
        {
            JsonContentId = @event.JsonContentId;
            Name = @event.Name;
            Json = @event.Json;
        }

        public void When(UpdateJsonContent @event)
        {
            Json = @event.Json;
        }

        protected override void When(dynamic @event) => When(@event);

        protected override void EnsureValidState()
        {
            if(string.IsNullOrEmpty(Name))
            {
                throw new Exception();
            }

            if (Json == null)
            {
                throw new Exception();
            }
        }
    }
}
