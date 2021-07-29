using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using QuinntyneBrown.Api.Core;
using QuinntyneBrown.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace QuinntyneBrown.Api.Features
{
    public class GetTalks
    {
        public class Request : IRequest<Response> { }

        public class Response : ResponseBase
        {
            public List<TalkDto> Talks { get; set; }
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
                    Talks = await _context.Talks.Select(x => x.ToDto()).ToListAsync()
                };
            }

        }
    }
}
