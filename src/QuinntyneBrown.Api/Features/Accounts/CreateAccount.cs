using FluentValidation;
using MediatR;
using QuinntyneBrown.Core;
using QuinntyneBrown.Core.Interfaces;
using QuinntyneBrown.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace QuinntyneBrown.Api.Features
{
    public class CreateAccount
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
                var account = new Account(new Core.DomainEvents.CreateAccount(
                    request.Account.UserId,
                    request.Account.AccountHolderFullname,
                    request.Account.Firstname,
                    request.Account.Lastname));

                _context.Accounts.Add(account);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Account = account.ToDto()
                };
            }

        }
    }
}
