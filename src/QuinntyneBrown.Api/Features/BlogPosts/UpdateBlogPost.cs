using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using QuinntyneBrown.Api.Core;
using QuinntyneBrown.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace QuinntyneBrown.Api.Features
{
    public class UpdateBlogPost
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.BlogPost).NotNull();
                RuleFor(request => request.BlogPost).SetValidator(new BlogPostValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public BlogPostDto BlogPost { get; set; }
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
                var blogPost = await _context.BlogPosts.SingleAsync(x => x.BlogPostId == request.BlogPost.BlogPostId);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    BlogPost = blogPost.ToDto()
                };
            }

        }
    }
}
