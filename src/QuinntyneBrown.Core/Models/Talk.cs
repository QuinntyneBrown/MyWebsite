using System;

namespace QuinntyneBrown.Core.Models
{
    public class Talk : AggregateRoot
    {
        public Guid TalkId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Guid PresentationDigitalAssetId { get; set; }

        public Talk(string title, string description, DateTime date)
        {
            Title = title;
            Description = description;
            Date = date;
        }

        private Talk()
        {

        }

        protected override void When(dynamic @event) => When(@event);
        protected override void EnsureValidState()
        {
        }
    }
}
