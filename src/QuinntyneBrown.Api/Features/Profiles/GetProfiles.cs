using MediatR;
using Microsoft.EntityFrameworkCore;
using QuinntyneBrown.Core;
using QuinntyneBrown.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuinntyneBrown.Api.Features
{
    public class GetProfiles
    {
        public class Request : IRequest<Response> { }

        public class Response : ResponseBase
        {
            public List<ProfileDto> Profiles { get; set; }
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
                    Profiles = await _context.Profiles.Select(x => x.ToDto()).ToListAsync()
                };
            }

        }
    }
}
