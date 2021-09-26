using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using QuinntyneBrown.Api.Extensions;
using QuinntyneBrown.Api.Core;
using QuinntyneBrown.Api.Interfaces;
using QuinntyneBrown.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace QuinntyneBrown.Api.Features
{
    public class GetStoredEventsPage
    {
        public class Request: IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response: ResponseBase
        {
            public int Length { get; set; }
            public List<StoredEventDto> Entities { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IQuinntyneBrownDbContext _context;
        
            public Handler(IQuinntyneBrownDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from storedEvent in _context.StoredEvents
                    select storedEvent;
                
                var length = await _context.StoredEvents.CountAsync();
                
                var storedEvents = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();
                
                return new()
                {
                    Length = length,
                    Entities = storedEvents
                };
            }
            
        }
    }
}
