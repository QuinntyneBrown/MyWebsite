using MediatR;
using Microsoft.EntityFrameworkCore;
using QuinntyneBrown.Core.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QuinntyneBrown.Api.Features
{
    public class GetJsonContentById
    {
        public class Request : IRequest<Response>
        {
            public Guid JsonContentId { get; set; }
        }

        public class Response
        {
            public JsonContentDto JsonContent { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IQuinntyneBrownDbContext _context;

            public Handler(IQuinntyneBrownDbContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new()
                {
                    JsonContent = (await _context.JsonContents.SingleAsync(x => x.JsonContentId == request.JsonContentId)).ToDto()
                };
            }
        }
    }
}
