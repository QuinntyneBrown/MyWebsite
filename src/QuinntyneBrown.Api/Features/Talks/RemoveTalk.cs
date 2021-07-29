using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using QuinntyneBrown.Api.Models;
using QuinntyneBrown.Api.Core;
using QuinntyneBrown.Api.Interfaces;

namespace QuinntyneBrown.Api.Features
{
    public class RemoveTalk
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
                var talk = await _context.Talks.SingleAsync(x => x.TalkId == request.TalkId);

                _context.Talks.Remove(talk);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Talk = talk.ToDto()
                };
            }

        }
    }
}
