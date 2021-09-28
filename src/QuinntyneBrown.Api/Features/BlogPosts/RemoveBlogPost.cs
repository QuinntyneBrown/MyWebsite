using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using QuinntyneBrown.Core.Models;
using QuinntyneBrown.Core;
using QuinntyneBrown.Core.Interfaces;

namespace QuinntyneBrown.Api.Features
{
    public class RemoveBlogPost
    {
        public class Request : IRequest<Response>
        {
            public Guid BlogPostId { get; set; }
        }

        public class Response : ResponseBase
        {
            public BlogPostDto BlogPost { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IQuinntyneBrownDbContext _context;

            public Handler(IQuinntyneBrownDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var blogPost = await _context.BlogPosts.SingleAsync(x => x.BlogPostId == request.BlogPostId);

                _context.BlogPosts.Remove(blogPost);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    BlogPost = blogPost.ToDto()
                };
            }

        }
    }
}
