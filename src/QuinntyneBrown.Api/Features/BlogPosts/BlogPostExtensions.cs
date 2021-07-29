using System;
using QuinntyneBrown.Api.Models;

namespace QuinntyneBrown.Api.Features
{
    public static class BlogPostExtensions
    {
        public static BlogPostDto ToDto(this BlogPost blogPost)
        {
            return new()
            {
                BlogPostId = blogPost.BlogPostId
            };
        }

    }
}
