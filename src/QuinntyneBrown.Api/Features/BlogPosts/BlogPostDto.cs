using System;

namespace QuinntyneBrown.Api.Features
{
    public class BlogPostDto
    {
        public Guid BlogPostId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
