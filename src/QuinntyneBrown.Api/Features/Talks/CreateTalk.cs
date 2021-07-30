using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using QuinntyneBrown.Api.Models;
using QuinntyneBrown.Api.Core;
using QuinntyneBrown.Api.Interfaces;

namespace QuinntyneBrown.Api.Features
{
    public class CreateTalk
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
                var talk = new Talk(
                    request.Talk.Title,
                    request.Talk.Description,
                    request.Talk.Date);

                _context.Talks.Add(talk);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Talk = talk.ToDto()
                };
            }

        }
    }
}
