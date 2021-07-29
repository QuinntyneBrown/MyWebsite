using System;
using QuinntyneBrown.Api.Models;

namespace QuinntyneBrown.Api.Features
{
    public static class ProfileExtensions
    {
        public static ProfileDto ToDto(this Profile profile)
        {
            return new ()
            {
                ProfileId = profile.ProfileId
            };
        }
        
    }
}
