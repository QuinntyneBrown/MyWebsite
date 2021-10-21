using Newtonsoft.Json.Linq;
using System;

namespace QuinntyneBrown.Core.DomainEvents
{
    public class CreateJsonContent: BaseDomainEvent
    {
        public Guid JsonContentId { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }
        public JObject Json { get; set; }
    }

    public class UpdateJsonContent : BaseDomainEvent
    {
        public JObject Json { get; set; }
    }
}
