using QuinntyneBrown.Api.Core;
using QuinntyneBrown.Api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace QuinntyneBrown.Api.Features
{
    public class Refresh
    {
        public record Request(string AccessToken, string RefreshToken) : IRequest<Response>;

        public record Response(string AccessToken, string RefreshToken);

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IQuinntyneBrownDbContext _context;
            private readonly ITokenProvider _tokenProvider;
            public Handler(IQuinntyneBrownDbContext context, ITokenProvider tokenProvider)
            {
                _context = context;
                _tokenProvider = tokenProvider;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {

                var principal = _tokenProvider.GetPrincipalFromExpiredToken(request.AccessToken);
                var username = principal.Identity.Name;
                var user = await _context.Users.SingleAsync(x => x.Username == username, cancellationToken);
                var refreshToken = user.RefreshToken;

                if (refreshToken != request.RefreshToken)
                {
                    return null;
                }

                var accessToken = _tokenProvider.Get(username);

                user.AddRefreshToken(_tokenProvider.GenerateRefreshToken());

                await _context.SaveChangesAsync(cancellationToken);

                return new(accessToken, user.RefreshToken);
            }
        }
    }
}
