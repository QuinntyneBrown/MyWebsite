using MediatR;
using Microsoft.EntityFrameworkCore;
using QuinntyneBrown.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QuinntyneBrown.Api.Features
{
    public class GetJsonContents
    {
        public class Request : IRequest<Response> { }

        public class Response
        {
            public List<JsonContentDto> JsonContents { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IQuinntyneBrownDbContext _context;

            public Handler(IQuinntyneBrownDbContext context){
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken) {
			    return new () { 
                    JsonContents = await _context.JsonContents.Select(x => x.ToDto()).ToListAsync()
                };
            }
        }
    }
}
