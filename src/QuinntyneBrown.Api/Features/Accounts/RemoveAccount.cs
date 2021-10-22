using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using QuinntyneBrown.Core.Models;
using QuinntyneBrown.Core;
using QuinntyneBrown.Core.Interfaces;

namespace QuinntyneBrown.Api.Features
{
    public class RemoveAccount
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
                var account = await _context.Accounts.SingleAsync(x => x.AccountId == request.AccountId);

                _context.Accounts.Remove(account);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Account = account.ToDto()
                };
            }

        }
    }
}
