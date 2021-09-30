using Newtonsoft.Json.Linq;

namespace QuinntyneBrown.Core.DomainEvents
{
    public class UpdateJsonContent: DomainEventBase
    {
        public JObject Json { get; set; }
    }
}
