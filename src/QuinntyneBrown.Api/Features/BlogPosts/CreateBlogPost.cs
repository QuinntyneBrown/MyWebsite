using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using QuinntyneBrown.Api.Models;
using QuinntyneBrown.Api.Core;
using QuinntyneBrown.Api.Interfaces;

namespace QuinntyneBrown.Api.Features
{
    public class CreateBlogPost
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
                var blogPost = new BlogPost(request.BlogPost.Title, request.BlogPost.Body);

                _context.BlogPosts.Add(blogPost);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    BlogPost = blogPost.ToDto()
                };
            }

        }
    }
}
