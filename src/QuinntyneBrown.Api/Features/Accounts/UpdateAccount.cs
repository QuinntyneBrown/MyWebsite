using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using QuinntyneBrown.Core;
using QuinntyneBrown.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace QuinntyneBrown.Api.Features
{
    public class UpdateAccount
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Account).NotNull();
                RuleFor(request => request.Account).SetValidator(new AccountValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public AccountDto Account { get; set; }
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
                var account = await _context.Accounts.SingleAsync(x => x.AccountId == request.Account.AccountId);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Account = account.ToDto()
                };
            }

        }
    }
}
