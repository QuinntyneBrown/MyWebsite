using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using QuinntyneBrown.Api.Core;
using QuinntyneBrown.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace QuinntyneBrown.Api.Features
{
    public class UpdateTalk
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Talk).NotNull();
                RuleFor(request => request.Talk).SetValidator(new TalkValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public TalkDto Talk { get; set; }
        }

        public class Response : ResponseBase
        {
            public TalkDto Talk { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IQuinntyneBrownDbContext _context;

            public Handler(IQuinntyneBrownDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var talk = await _context.Talks.SingleAsync(x => x.TalkId == request.Talk.TalkId);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Talk = talk.ToDto()
                };
            }

        }
    }
}
