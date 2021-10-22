using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using QuinntyneBrown.Api.Extensions;
using QuinntyneBrown.Core;
using QuinntyneBrown.Core.Interfaces;
using QuinntyneBrown.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace QuinntyneBrown.Api.Features
{
    public class GetAccountsPage
    {
        public class Request : IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response : ResponseBase
        {
            public int Length { get; set; }
            public List<AccountDto> Entities { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IQuinntyneBrownDbContext _context;

            public Handler(IQuinntyneBrownDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from account in _context.Accounts
                            select account;

                var length = await _context.Accounts.CountAsync();

                var accounts = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();

                return new()
                {
                    Length = length,
                    Entities = accounts
                };
            }

        }
    }
}
