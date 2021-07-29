using System;

namespace QuinntyneBrown.Api.Models
{
    public class Talk
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
    }
}
