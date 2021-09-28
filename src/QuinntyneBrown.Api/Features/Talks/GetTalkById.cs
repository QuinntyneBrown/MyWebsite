using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using QuinntyneBrown.Core;
using QuinntyneBrown.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace QuinntyneBrown.Api.Features
{
    public class GetTalkById
    {
        public class Request : IRequest<Response>
        {
            public Guid TalkId { get; set; }
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
                return new()
                {
                    Talk = (await _context.Talks.SingleOrDefaultAsync(x => x.TalkId == request.TalkId)).ToDto()
                };
            }

        }
    }
}
