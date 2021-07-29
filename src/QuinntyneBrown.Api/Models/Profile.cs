using System;

namespace QuinntyneBrown.Api.Models
{
    public class Profile
    {
        public Guid ProfileId { get; private set; }
        public string Fullname { get; private set; }
        public string Description { get; private set; }
        public string Email { get; private set; }
        public string GithubProfile { get; private set; }
        public string LinkedInProfile { get; private set; }
        public Guid AvatarDigitalAssetId { get; private set; }

        public Profile(string fullname, string description)
        {
            Fullname = fullname;
            Description = description;
        }

        private Profile()
        {

        }
    }
}
