using System;

namespace QuinntyneBrown.Core.DomainEvents
{
    public class CreateBlogPost : BaseDomainEvent
    {
        public Guid BlogPostId { get; private set; } = Guid.NewGuid();
        public string Title { get; private set; }
        public string Body { get; private set; }
        public CreateBlogPost(string title, string body)
        {
            Title = title;
            Body = body;
        }
    }
}
