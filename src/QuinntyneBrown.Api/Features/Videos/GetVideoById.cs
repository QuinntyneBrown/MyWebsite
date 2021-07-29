using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using QuinntyneBrown.Api.Core;
using QuinntyneBrown.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace QuinntyneBrown.Api.Features
{
    public class GetVideoById
    {
        public class Request : IRequest<Response>
        {
            public Guid VideoId { get; set; }
        }

        public class Response : ResponseBase
        {
            public VideoDto Video { get; set; }
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
                    Video = (await _context.Videos.SingleOrDefaultAsync(x => x.VideoId == request.VideoId)).ToDto()
                };
            }

        }
    }
}
