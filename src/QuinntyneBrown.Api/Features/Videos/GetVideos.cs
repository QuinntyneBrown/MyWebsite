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
    public class GetVideos
    {
        public class Request : IRequest<Response> { }

        public class Response : ResponseBase
        {
            public List<VideoDto> Videos { get; set; }
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
                    Videos = await _context.Videos.Select(x => x.ToDto()).ToListAsync()
                };
            }

        }
    }
}
