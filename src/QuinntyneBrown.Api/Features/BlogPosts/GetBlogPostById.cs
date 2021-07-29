using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using QuinntyneBrown.Api.Core;
using QuinntyneBrown.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace QuinntyneBrown.Api.Features
{
    public class GetBlogPostById
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
                return new()
                {
                    BlogPost = (await _context.BlogPosts.SingleOrDefaultAsync(x => x.BlogPostId == request.BlogPostId)).ToDto()
                };
            }

        }
    }
}
