using System;

namespace QuinntyneBrown.Core.DomainEvents
{
    public class CreateVideo
    {
        public Guid VideoId { get; set; } = Guid.NewGuid();
        public string Title { get; private set; }
        public string Description { get; private set; }

        public CreateVideo(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
