using Newtonsoft.Json.Linq;
using System;

namespace QuinntyneBrown.Core.DomainEvents
{
    public class CreateJsonContent: DomainEventBase
    {
        public Guid JsonContentId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public JObject Json { get; set; }
    }
}
