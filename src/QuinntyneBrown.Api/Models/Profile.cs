using System;

namespace QuinntyneBrown.Api.Models
{
    public class Profile
    {
        public Guid ProfileId { get; private set; }
        public string Fullname { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Email { get; private set; }
        public string GithubProfile { get; private set; }
        public string LinkedInProfile { get; private set; }
        public Guid AvatarDigitalAssetId { get; private set; }

        public Profile(string title, string fullname, string description)
        {
            Title = title;
            Fullname = fullname;
            Description = description;
        }

        private Profile()
        {

        }

        public void SetAvatarDigitalAssetId(Guid digitalAssetId)
        {
            AvatarDigitalAssetId = digitalAssetId;
        }

        public void SetLinkedInProfile(string profile)
        {
            LinkedInProfile = profile;
        }

        public void SetGithubProfile(string profile)
        {
            GithubProfile = profile;
        }
    }
}
