using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using QuinntyneBrown.Api.Core;
using QuinntyneBrown.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace QuinntyneBrown.Api.Features
{
    public class GetProfileByName
    {
        public class Request : IRequest<Response>
        {
            public string Fullname { get; set; }
        }

        public class Response : ResponseBase
        {
            public ProfileDto Profile { get; set; }
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
                    Profile = (await _context.Profiles
                    .SingleOrDefaultAsync(x => x.Fullname == request.Fullname)).ToDto()
                };
            }

        }
    }
}
