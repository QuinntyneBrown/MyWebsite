using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using QuinntyneBrown.Core.Models;
using QuinntyneBrown.Core;
using QuinntyneBrown.Core.Interfaces;

namespace QuinntyneBrown.Api.Features
{
    public class CreateProfile
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Profile).NotNull();
                RuleFor(request => request.Profile).SetValidator(new ProfileValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public ProfileDto Profile { get; set; }
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
                var profile = new Profile(request.Profile.AccountId, request.Profile.Title, request.Profile.Fullname, request.Profile.Description);

                _context.Profiles.Add(profile);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Profile = profile.ToDto()
                };
            }

        }
    }
}
