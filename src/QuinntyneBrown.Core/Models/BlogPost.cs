using QuinntyneBrown.Core.DomainEvents;
using System;

namespace QuinntyneBrown.Core.Models
{
    public class BlogPost: AggregateRoot
    {
        public Guid BlogPostId { get; private set; }
        public string Title { get; private set; }
        public string Body { get; private set; }
        public DateTime Created { get; private set; } = DateTime.UtcNow;
        public DateTime? Publised { get; private set; }
        public BlogPost(CreateBlogPost @event)
        {
            Apply(@event);
        }

        private BlogPost()
        {

        }

        protected override void When(dynamic @event) => When(@event);

        private void When(CreateBlogPost @event)
        {
            BlogPostId = @event.BlogPostId;
            Title = @event.Title;
            Body = @event.Body;
        }
        protected override void EnsureValidState()
        {

        }
    }
}
