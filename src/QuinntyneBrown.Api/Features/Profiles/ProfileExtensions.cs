using QuinntyneBrown.Core.Models;

namespace QuinntyneBrown.Api.Features
{
    public static class ProfileExtensions
    {
        public static ProfileDto ToDto(this Profile profile)
        {
            return new()
            {
                ProfileId = profile.ProfileId,
                Title = profile.Title,
                Fullname = profile.Fullname,
                AvatarDigitalAssetId = profile.AvatarDigitalAssetId,
                Description = profile.Description,
                LinkedInProfile = profile.LinkedInProfile,
                GithubProfile = profile.GithubProfile
            };
        }

    }
}
