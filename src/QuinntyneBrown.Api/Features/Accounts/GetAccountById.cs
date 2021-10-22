using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using QuinntyneBrown.Core;
using QuinntyneBrown.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace QuinntyneBrown.Api.Features
{
    public class GetAccountById
    {
        public class Request : IRequest<Response>
        {
            public Guid AccountId { get; set; }
        }

        public class Response : ResponseBase
        {
            public AccountDto Account { get; set; }
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
                    Account = (await _context.Accounts.SingleOrDefaultAsync(x => x.AccountId == request.AccountId)).ToDto()
                };
            }

        }
    }
}
