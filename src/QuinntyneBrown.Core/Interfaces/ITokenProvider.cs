using System.Collections.Generic;
using System.Security.Claims;

namespace QuinntyneBrown.Core.Interfaces
{
    public interface ITokenProvider
    {
        string Get(string username, IEnumerable<Claim> customClaims = null);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        string GenerateRefreshToken();
    }
}