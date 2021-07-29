using System;

namespace QuinntyneBrown.Api.Models
{
    public class BlogPost
    {
        public Guid BlogPostId { get; private set; }
        public string Title { get; private set; }
        public string Body { get; private set; }
        public DateTime Created { get; private set; } = DateTime.UtcNow;
        public DateTime? Publised { get; private set; }
        public BlogPost(string title, string body)
        {
            Title = title;
            Body = body;
        }

        private BlogPost()
        {

        }
    }
}
